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
    public class RepositorioTipoDeDoc : IRepositorioTipoDeDocumento
    {
        private readonly SqlConnection _conexion;
        public RepositorioTipoDeDoc(SqlConnection conexion)
        {
            _conexion = conexion;
        }

        public void Borrar(TipoDeDocumento documento)
        {
            try
            {
                string cadenaComando = "DELETE FROM TiposDeDocumentos WHERE TipoDeDocumentoId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", documento.TipoDeDocumentoId);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Editar(TipoDeDocumento documento)
        {
            try
            {
                string cadenaComando = "UPDATE TiposDeDocumentos SET Descripcion=@desc WHERE TipoDeDocumentoId=@Id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@desc", documento.Descripcion);
                comando.Parameters.AddWithValue("@id", documento.TipoDeDocumentoId);
                
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(TipoDeDocumento documento)
        {
            try
            {
                string cadenaComando = "SELECT * FROM Clientes WHERE TipoDeDocumentoId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", documento.TipoDeDocumentoId);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(TipoDeDocumento documento)
        {
            if (documento.TipoDeDocumentoId == 0)
            {
                string cadenaComando = "SELECT TipoDeDocumentoId, Descripcion FROM TiposDeDocumentos  WHERE Descripcion=@desc";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@desc", documento.Descripcion);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            else
            {
                string cadenaComando = "SELECT TipoDeDocumentoId, Descripcion FROM TiposDeDocumentos WHERE Descripcion=@desc AND TipoDeDocumentoId<>@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@desc", documento.Descripcion);
                comando.Parameters.AddWithValue("@id", documento.TipoDeDocumentoId);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;

            }
        }

        public List<TipoDeDocumento> GetTipoDeDeDocumentos()
        {
            List<TipoDeDocumento> lista = new List<TipoDeDocumento>();
            try
            {

                string cadenaComando = "SELECT TipoDeDocumentoId, Descripcion FROM TiposDeDocumentos ";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    TipoDeDocumento documento = ConstruirTipodeDocumento(reader);
                    lista.Add(documento);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            };
        }

        private TipoDeDocumento ConstruirTipodeDocumento(SqlDataReader reader)
        {
            return new TipoDeDocumento()
            {
                TipoDeDocumentoId= reader.GetInt32(0),
                Descripcion = reader.GetString(1)
            };
        }

        public TipoDeDocumento GetTipoDeDocumentoPorId(int id)
        {
            TipoDeDocumento tipo = null;
            try
            {
                string cadenaComando = "SELECT TipoDeDocumentoId, Descripcion FROM TiposDeDocumentos WHERE TipoDeDocumentoId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    tipo = ConstruirTipodeDocumento(reader);
                }

                reader.Close();
                return tipo;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(TipoDeDocumento documento)
        {
            try
            {
                string cadenaComando = "INSERT INTO TiposDeDocumentos VALUES( @tipo)";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@tipo", documento.Descripcion);
                comando.ExecuteNonQuery();
                cadenaComando = "SELECT @@IDENTITY";
                comando = new SqlCommand(cadenaComando, _conexion);
                int id = (int)(decimal)comando.ExecuteScalar();
                documento.TipoDeDocumentoId = id;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
