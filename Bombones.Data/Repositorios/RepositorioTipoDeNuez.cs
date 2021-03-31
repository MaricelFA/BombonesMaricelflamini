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
    public class RepositorioTipoDeNuez : IRepositorioTipodeNuez
    {
        private readonly SqlConnection _conexion;
        public RepositorioTipoDeNuez(SqlConnection conexion)
        {
            _conexion = conexion;
        }

      

        public void Borrar(int id)
        {
            try
            {
                string cadenaComando = "DELETE FROM TipoDeNuez WHERE TipoDeNuezId=@id"; 
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(TipodeNuez tipodeNuez)
        {
            try
            {
                string cadenaComando = "SELECT * FROM Bombones WHERE TipoDeNuezId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", tipodeNuez.TipoDeNuezId);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(TipodeNuez tipoDeNuez)
        {
            if (tipoDeNuez.TipoDeNuezId == 0)
            {
                string cadenaComando = "SELECT TipoDeNuezId, NombreTipoDeNuez FROM TipoDeNuez  WHERE NombreTipoDeNuez=@nom";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@nom", tipoDeNuez.NombreTipoDeNuez);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            else
            {
                string cadenaComando = "SELECT TipoDeNuezId, NombreTipoDeNuez FROM TipoDeNuez WHERE NombreTipoDeNuez=@nom AND TipoDeNuezId<>@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@nom", tipoDeNuez.NombreTipoDeNuez);
                comando.Parameters.AddWithValue("@id", tipoDeNuez.TipoDeNuezId);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;

            }
        }

        public List<TipodeNuez> GetLista()
        {
            List<TipodeNuez> lista = new List<TipodeNuez>();
            try
            {

                string cadenaComando = "SELECT TipoDeNuezId, NombreTipoDeNuez FROM TipoDeNuez ORDER BY NombreTipoDeNuez";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    TipodeNuez tipodeNuez = ConstruirTipodeNuez(reader);
                    lista.Add(tipodeNuez);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            };
        }

        private TipodeNuez ConstruirTipodeNuez(SqlDataReader reader)
        {
            return new TipodeNuez()
            {
                TipoDeNuezId = reader.GetInt32(0),
                NombreTipoDeNuez = reader.GetString(1)
            };
        }

        public TipodeNuez GetTipoDeNuezPorId(int id)
        {
            TipodeNuez p = null;
            try
            {
                string cadenaComando = "SELECT TipoDeNuezId, NombreTipoDeNuez FROM TipoDeNuez WHERE TipoDeNuezId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    p = ConstruirTipodeNuez(reader);
                }

                reader.Close();
                return p;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(TipodeNuez tipoDeNuez)
        {
            try
            {
                string cadenaComando = "INSERT INTO TipoDeNuez VALUES( @desc)";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@desc", tipoDeNuez.NombreTipoDeNuez);
                comando.ExecuteNonQuery();
                cadenaComando = "SELECT @@IDENTITY";
                comando = new SqlCommand(cadenaComando, _conexion);
                int id = (int)(decimal)comando.ExecuteScalar();
                tipoDeNuez.TipoDeNuezId = id;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
