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
    public class RepositorioTipodeRelleno : IRepositorioTipodeRelleno
    {
        //SELECT TipoRellenoId, NombreTipoRelleno FROM TiposDeRelleno


        private readonly SqlConnection _conexion;
        public RepositorioTipodeRelleno(SqlConnection conexion)
        {
            _conexion = conexion;
        }

        public void Borrar(int id)
        {
            try
            {
                string cadenaComando = "DELETE FROM TiposDeRelleno WHERE TipoRellenoId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(TipodeRelleno tipodeRelleno)
        {
            try
            {
                string cadenaComando = "SELECT * FROM Bombones WHERE TipoRellenoId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", tipodeRelleno.TipoRellenoId);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(TipodeRelleno tipodeRelleno)
        {
            if (tipodeRelleno.TipoRellenoId == 0)
            {
                string cadenaComando = "SELECT TipoRellenoId, NombreTipoRelleno FROM TiposDeRelleno  WHERE NombreTipoRelleno=@nom";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@nom", tipodeRelleno.NombreTipoRelleno);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            else
            {
                string cadenaComando = "SELECT TipoRellenoId, NombreTipoRelleno FROM TiposDeRelleno WHERE NombreTipoRelleno=@nom AND TipoRellenoId<>@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@nom", tipodeRelleno.NombreTipoRelleno);
                comando.Parameters.AddWithValue("@id", tipodeRelleno.TipoRellenoId);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;

            }
        }

        public List<TipodeRelleno> GetLista()
        {
            List<TipodeRelleno> lista = new List<TipodeRelleno>();
            try
            {

                string cadenaComando = "SELECT TipoRellenoId, NombreTipoRelleno FROM TiposDeRelleno ORDER BY NombreTipoRelleno";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    TipodeRelleno tipodeRelleno = ConstruirTipodeRelleno(reader);
                    lista.Add(tipodeRelleno);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            };
        }

        private TipodeRelleno ConstruirTipodeRelleno(SqlDataReader reader)
        {
            return new TipodeRelleno()
            {
                TipoRellenoId = reader.GetInt32(0),
                NombreTipoRelleno = reader.GetString(1)
            };
        }

        public TipodeRelleno GetTipoRellenoPorId(int id)
        {
            TipodeRelleno p = null;
            try
            {
                string cadenaComando = "SELECT TipoRellenoId, NombreTipoRelleno FROM TiposDeRelleno WHERE TipoRellenoId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    p = ConstruirTipodeRelleno(reader);
                }

                reader.Close();
                return p;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(TipodeRelleno tipodeRelleno)
        {
            try
            {
                string cadenaComando = "INSERT INTO TiposDeRelleno VALUES( @desc)";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@desc", tipodeRelleno.NombreTipoRelleno);
                comando.ExecuteNonQuery();
                cadenaComando = "SELECT @@IDENTITY";
                comando = new SqlCommand(cadenaComando, _conexion);
                int id = (int)(decimal)comando.ExecuteScalar();
                tipodeRelleno.TipoRellenoId = id;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
