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
    public class RepositorioProvincias : IRepositorioProvincias
    {
        private readonly SqlConnection _conexion;

        public RepositorioProvincias(SqlConnection conexion)
        {
            _conexion = conexion;

        }
        public void Borrar(int id)
        {
            try
            {
                string cadenaComando = "DELETE FROM Provincias WHERE ProvinciaId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                if (e.Message.Contains("REFERENCE"))
                {
                    throw new Exception("Registro con datos asociados... Baja denegada");
                }
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Provincia provincia)
        {
            if (provincia.ProvinciaId == 0)
            {
                string cadenaComando = "SELECT ProvinciaId, NombreProvincia FROM Provincias WHERE NombreProvincia=@nom";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@nom", provincia.NombreProvincia);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            else
            {
                string cadenaComando = "SELECT ProvinciaId, NombreProvincia FROM Provincias WHERE NombreProvincia=@nom AND ProvinciaId<>@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@nom", provincia.NombreProvincia);
                comando.Parameters.AddWithValue("@id", provincia.ProvinciaId);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;

            }
        }

        public List<Provincia> GetLista()
        {
            List<Provincia> lista = new List<Provincia>();
            try
            {
                string cadenaComando = "SELECT Provinciaid, NombreProvincia FROM Provincias ORDER BY NombreProvincia";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Provincia provincia = ConstruirProvincia(reader);
                    lista.Add(provincia);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        private Provincia ConstruirProvincia(SqlDataReader reader)
        {
            return new Provincia()
            {
                ProvinciaId = reader.GetInt32(0),
                NombreProvincia = reader.GetString(1)
            };

        }

        public Provincia GetProvinciaPorId(int id)
        {
            Provincia p = null;
            try
            {
                string cadenaComando = "SELECT Provinciaid, NombreProvincia FROM Provincias WHERE ProvinciaId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    p = ConstruirProvincia(reader);
                }

                reader.Close();
                return p;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(Provincia provincia)
        {
            if (provincia.ProvinciaId == 0)
            {
               
                try
                {
                    string cadenaComando = "INSERT INTO Provincias VALUES(@nombre)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@nombre", provincia.NombreProvincia);

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _conexion);
                    provincia.ProvinciaId = (int)(decimal)comando.ExecuteScalar();

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
                    string cadenaComando = "UPDATE Provincias SET NombreProvincia=@nombre WHERE ProvinciaId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@nombre", provincia.NombreProvincia);
                    comando.Parameters.AddWithValue("@id", provincia.ProvinciaId);
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

        public bool EstaRelacionado(Provincia provincia)
        {
            try
            {
                string cadenaComando = "SELECT * FROM Localidades WHERE ProvinciaId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", provincia.ProvinciaId);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
