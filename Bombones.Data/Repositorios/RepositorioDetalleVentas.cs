using Bombones.BL;
using Bombones.BL.Dtos.DetalleVenta;
using Bombones.Data.Repositorios.Facales;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Data.Repositorios
{
    public class RepositorioDetalleVentas : IRepositorioDetalleVentas
    {


        private readonly SqlConnection _conexion;
        private IRepositorioVentas _repositorioVentas;
        private SqlTransaction _tran;


        public RepositorioDetalleVentas(SqlConnection sqlConnection)
        {
            _conexion = sqlConnection;
        }

        public RepositorioDetalleVentas(SqlConnection sqlConnection, SqlTransaction tran) : this(sqlConnection)
        {
            this._tran = tran;
        }





        public DetalleVentaEditDto GetDetalleVentaPorId(int detalleVentaId)
        {
            throw new NotImplementedException();
        }

        public List<DetalleVentaListDto> GetLista(int ventaId)
        {
            List<DetalleVentaListDto> lista = new List<DetalleVentaListDto>();
            try
            {
                string cadenaComando = "SELECT DV.DetalleVentaId, V.VentaId, B.NombreBombon, DV.Precio, DV.Cantidad" +
                    " FROM DetallesVentas DV INNER JOIN Bombones B on DV.BombonId=B.BombonId INNER JOIN Ventas V on DV.VentaId=V.VentaId " +
                    "WHERE VentaId=@Id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", ventaId);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var detalleVentaDto = ConstruirDetalleVentaListDto(reader);
                    lista.Add(detalleVentaDto);
                }

                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



        private DetalleVentaListDto ConstruirDetalleVentaListDto(SqlDataReader reader)
        {
            DetalleVentaListDto detalleVentaListDto = new DetalleVentaListDto();
            {
                detalleVentaListDto.DetalleVentaId = reader.GetInt32(0);
                detalleVentaListDto.VentaId = reader.GetInt32(1);
                detalleVentaListDto.NombreBombon = reader.GetString(2);
                detalleVentaListDto.Precio = reader.GetDecimal(3);
                detalleVentaListDto.Cantidad = reader.GetInt32(4);

                return detalleVentaListDto;

            };
        }


        public void Guardar(DetalleVenta detalleVenta)
        {


            try
            {
                string cadenaComando = "INSERT INTO DetallesVentas (VentaId, BombonId, Precio, Cantidad) VALUES (@venta,@bombon, @precio, @cantidad)";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@venta", detalleVenta.venta.VentaId);
                comando.Parameters.AddWithValue("@bombon", detalleVenta.bombon.NombreBombon);
                comando.Parameters.AddWithValue("@precio", detalleVenta.Costo);
                comando.Parameters.AddWithValue("@cantidad", detalleVenta.Cantidad);
            }
            catch (Exception e)
            {
                throw new Exception("Error al guardar un Detalle de venta");
            }







        }

        public void Borrar(int detalleId)
        {
            try
            {
                var cadenaComando = "DELETE FROM DetallesVentas WHERE DetalleVentaId=@id";
                var comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", detalleId);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                if (e.Message.Contains("REFERENCE"))
                {
                    throw new Exception("Registro con datos asociados... Baja denegada");
                }

            }
        }
    }
    
}
