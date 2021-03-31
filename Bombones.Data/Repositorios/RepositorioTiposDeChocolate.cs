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
    public class RepositorioTiposDeChocolate : IRepositorioTiposDeChocolate
    {
        private readonly SqlConnection _conexion;
        public RepositorioTiposDeChocolate(SqlConnection conexion)
        {
            _conexion = conexion;
        }

        public void Borrar(int id)
        {
            try
            {
                string cadenaComando = "DELETE FROM TiposDeChocolate WHERE TipoChocolateId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(TipoChocolate tipoChocolate)
        {
            if (tipoChocolate.TipoChocolateId == 0)
            {
                string cadenaComando = "SELECT TipoChocolateId, NombreTipoChocolate FROM TiposDeChocolate  WHERE NombreTipoChocolate=@nom";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@nom", tipoChocolate.NombreTipoChocolate);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            else
            {
                string cadenaComando = "SELECT TipoChocolateId, NombreTipoChocolate FROM TiposDeChocolate WHERE NombreTipoChocolate=@nom AND TipoChocolateId<>@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@nom", tipoChocolate.NombreTipoChocolate);
                comando.Parameters.AddWithValue("@id", tipoChocolate.TipoChocolateId);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;

            }
        }

        public List<TipoChocolate> GetLista()
        {
            List<TipoChocolate> lista = new List<TipoChocolate>();
            try
            {

                string cadenaComando = "SELECT TipoChocolateId, NombreTipoChocolate FROM TiposDeChocolate ORDER BY NombreTipoChocolate";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    TipoChocolate TipoChocolate = ConstruirTipoChocolate(reader);
                    lista.Add(TipoChocolate);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            };
        }


        private TipoChocolate ConstruirTipoChocolate(SqlDataReader reader)
        {
            return new TipoChocolate()
            {
                TipoChocolateId = reader.GetInt32(0),
                NombreTipoChocolate = reader.GetString(1)
            };

        }
        public TipoChocolate GetTipoChocolatePorId(int id)
        {
            TipoChocolate p = null;
            try
            {
                string cadenaComando = "SELECT TipoChocolateId, NombreTipoChocolate FROM TiposDeChocolate WHERE TipoChocolateId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    p = ConstruirTipoChocolate(reader);
                }

                reader.Close();
                return p;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(TipoChocolate tipoChocolate)
        {
            try
            {
                string cadenaComando = "INSERT INTO TiposDeChocolate VALUES( @desc)";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@desc", tipoChocolate.NombreTipoChocolate);
                comando.ExecuteNonQuery();
                cadenaComando = "SELECT @@IDENTITY";
                comando = new SqlCommand(cadenaComando, _conexion);
                int id = (int)(decimal)comando.ExecuteScalar();
                tipoChocolate.TipoChocolateId = id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionado(TipoChocolate tipoChocolate)
        {
            try
            {
                string cadenaComando = "SELECT * FROM Bombones WHERE TipoChocolateId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", tipoChocolate.TipoChocolateId);
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
