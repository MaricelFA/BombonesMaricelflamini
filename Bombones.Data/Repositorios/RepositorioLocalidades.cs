using Bombones.BL;
using Bombones.BL.Dtos.Localidad;
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
            try
            {
                var cadenaComando = "DELETE FROM Localidades WHERE LocalidadId=@id";
                var comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Localidad localidad)
        {
            try
            {
                SqlCommand comando = null;
                SqlDataReader reader = null;

                if (localidad.LocalidadId == 0)
                {
                    var cadenaComando = "SELECT LocalidadId, ProvinciaId, NombreLocalidad FROM Localidades WHERE NombreLocalidad=@nom";
                    comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@nom", localidad.NombreLocalidad);
                    // SqlDataReader reader = comando.ExecuteReader();
                    //return reader.HasRows;
                }
                else
                {

                    var cadenaComando = "SELECT LocalidadId, ProvinciaId, NombreLocalidad FROM Localidades WHERE NombreLocalidad=@nom AND LocalidadId<>@id";
                    comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@nom", localidad.NombreLocalidad);
                    comando.Parameters.AddWithValue("@id", localidad.LocalidadId);
                    // SqlDataReader reader = comando.ExecuteReader();
                    //return reader.HasRows;

                }
                reader = comando.ExecuteReader();
                return reader.HasRows;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }   
        public List<LocalidadListDto> GetLista()
        {
            List<LocalidadListDto> lista = new List<LocalidadListDto>();
            try
            { 
                string cadenaComando = "SELECT LocalidadId, NombreProvincia, NombreLocalidad  FROM Localidades L inner join Provincias P on L.ProvinciaId=P.ProvinciaId ";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var localidadDto = ConstruirLocalidadDto(reader);
                    lista.Add(localidadDto);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private LocalidadListDto ConstruirLocalidadDto(SqlDataReader reader)
                 {
                    LocalidadListDto localidadDto = new LocalidadListDto();
                    localidadDto.LocalidadId = reader.GetInt32(0);
                localidadDto.NombreLocalidad = reader.GetString(2);
                    localidadDto.NombreProvincia = reader.GetString(1);
                    return localidadDto;

            
          
                  }

         public List<Localidad> GetLista(int provinciaId)
                  {
                   throw new NotImplementedException();
                  }

        public LocalidadEditDto GetLocalidadPorId(int id)
        {
            LocalidadEditDto localidad = null;
            try
            {
                string cadenaComando = "SELECT LocalidadId, ProvinciaId, NombreLocalidad  FROM Localidades WHERE LocalidadId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    localidad = ConstruirLocalidad(reader);
                }

                reader.Close();
                return localidad;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private LocalidadEditDto ConstruirLocalidad(SqlDataReader reader)
        {
            var localidad = new LocalidadEditDto();
            localidad.LocalidadId = reader.GetInt32(0);
            localidad.NombreLocalidad = reader.GetString(2);
            localidad.ProvinciaId = reader.GetInt32(1);
            return localidad;
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

        List<LocalidadListDto> IRepositorioLocalidades.GetLista(int provinciaId)
        {

            List<LocalidadListDto> lista = new List<LocalidadListDto>();
            try
            {
                string cadenaComando = "SELECT LocalidadId, NombreProvincia, NombreLocalidad  FROM Localidades L inner join Provincias P on L.ProvinciaId=P.ProvinciaId where P.ProvinciaId=@id ";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", provinciaId);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var localidadDto = ConstruirLocalidadDto(reader);
                    lista.Add(localidadDto);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(LocalidadListDto localidadListDto)
        {
            try
            {
                string cadenaComando = "SELECT * FROM Clientes WHERE LocalidadId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", localidadListDto.LocalidadId);
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
