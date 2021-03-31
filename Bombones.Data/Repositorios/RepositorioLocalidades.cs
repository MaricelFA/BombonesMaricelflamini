using Bombones.BL;
using Bombones.Data.Repositorios.Facales;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Data.Repositorios
{
    public class RepositorioLocalidades : IRepositorioLocalidades
    {
        private readonly SqlConnection _conexion;
        private readonly IRepositorioProvincias _repoProvincias;

        public RepositorioLocalidades(SqlConnection conexion)
        {
            _conexion = conexion;
        }
        public RepositorioLocalidades(SqlConnection conexion, IRepositorioProvincias repoProvincias)
        {
            _conexion = conexion;
            _repoProvincias = repoProvincias;
        }

        public void Borrar(int id)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Localidad localidad)
        {
            if (localidad.LocalidadId == 0)
            {
                string cadenaComando = "SELECT LocalidadId, ProvinciaId, NombreLocalidad FROM Localidades WHERE NombreLocalidad=@nom";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@nom", localidad.NombreLocalidad);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            else
            {
                //Edicion de provincia
                string cadenaComando = "SELECT LocalidadId, ProvinciaId, NombreLocalidad FROM Localidades WHERE NombreLocalidad=@nom AND LocalidadId<>@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@nom", localidad.NombreLocalidad);
                comando.Parameters.AddWithValue("@id", localidad.LocalidadId);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;

            }
        }

        public List<Localidad> GetLista()
        {
            List<Localidad> lista = new List<Localidad>();
            try
            { 
                string cadenaComando = "SELECT LocalidadId, ProvinciaId, NombreLocalidad  FROM Localidades";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Localidad localidad = ConstruirLocalidad(reader);
                    lista.Add(localidad);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private Localidad ConstruirLocalidad(SqlDataReader reader)
        {
            return new Localidad()
            {
                LocalidadId = reader.GetInt32(0),
                NombreLocalidad = reader.GetString(2),
                Provincia = _repoProvincias.GetProvinciaPorId(reader.GetInt32(1))
            };
        }

        public List<Localidad> GetLista(int provinciaId)
        {
            throw new NotImplementedException();
        }

        public Localidad GetLocalidadPorId(int id)
        {
            Localidad l = null;
            try
            {
                string cadenaComando = "SELECT LocalidadId, ProvinciaId, NombreLocalidad  FROM Localidades WHERE LocalidadId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    l = ConstruirLocalidad(reader);
                }

                reader.Close();
                return l;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(Localidad localidad)
        {
            if (localidad.LocalidadId == 0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO Localidades VALUES(@provId, @nombre)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@provId", localidad.Provincia.ProvinciaId);
                    comando.Parameters.AddWithValue("@nombre", localidad.NombreLocalidad);

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _conexion);
                    localidad.LocalidadId = (int)(decimal)comando.ExecuteScalar();

                }
                catch (Exception e)
                {
                    if (e.Message.Contains("IX_"))
                    {
                        throw new Exception("Registro duplicado...");
                    }
                    throw new Exception("Error");
                }

            }
            else
            {
                try
                {
                    string cadenaComando = "UPDATE Localidades SET ProvinciaId=@provId,  NombreLocalidad=@nombre WHERE LocalidadId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@provId", localidad.Provincia.ProvinciaId);
                    comando.Parameters.AddWithValue("@nombre", localidad.NombreLocalidad);
                    comando.Parameters.AddWithValue("@id", localidad.LocalidadId);

                    comando.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    if (e.Message.Contains("IX_"))
                    {
                        throw new Exception("Registro duplicado...");
                    }
                    throw new Exception("Error");
                }

            }
        }
    }
}
