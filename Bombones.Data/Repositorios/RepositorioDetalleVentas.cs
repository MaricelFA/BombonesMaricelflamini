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
        private IRepositorioBombones _repositorioBombones;

        public RepositorioDetalleVentas(SqlConnection sqlConnection, IRepositorioVentas repositorioVentas, IRepositorioBombones repositorioBombones)
        {
            _conexion = sqlConnection;
            _repositorioVentas = repositorioVentas;
            _repositorioBombones = repositorioBombones;
        }


        public void Borrar(int DetalleVentaId)
        {
            try
            {
                var cadenaComando = "DELETE FROM DetallesVentas WHERE DetalleVentaId=@id";
                var comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", DetalleVentaId);
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

        public bool EstaRelacionado(DetalleVentaListDto detalleVentaListDto)
        {
            throw new NotImplementedException();
        }

        public bool Existe(DetalleVenta detalleVenta)
        {
            throw new NotImplementedException();
        }

        public DetalleVentaEditDto GetDetalleVentaPorId(int detalleVentaId)
        {
            throw new NotImplementedException();
        }

        public List<DetalleVentaListDto> GetLista()
        {
            List<DetalleVentaListDto> lista = new List<DetalleVentaListDto>();
            try
            {
                string cadenaComando = "select DetalleVentaId,VentaId, B.NombreBombon, Precio, Cantidad FROM from DetallesVentas DV INNER JOIN Bombones B on DV.BombonId=B.BombonId";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
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
            if (detalleVenta.DetalleVentaId == 0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO Ventas VALUES (@detalle,@venta,@bombon, @precio, @cantidad)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@detalle", detalleVenta.DetalleVentaId);
                    comando.Parameters.AddWithValue("@venta", detalleVenta.VentaId);
                    comando.Parameters.AddWithValue("@bombon", detalleVenta.BombonId);
                    comando.Parameters.AddWithValue("@precio", detalleVenta.Precio);
                    comando.Parameters.AddWithValue("@cantidad", detalleVenta.Cantidad);
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
                    string cadenaComando = "UPDATE DetallesVentas set VentaId=@venta, BombonId=@bom, " +
                        "Precio=@precio, Cantidad=@cant Where DetalleVentaId=@Id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@VentaId", detalleVenta.VentaId);
                    comando.Parameters.AddWithValue("@bom", detalleVenta.BombonId);
                    comando.Parameters.AddWithValue("@precio", detalleVenta.Precio);
                    comando.Parameters.AddWithValue("@cant", detalleVenta.Cantidad);
                    comando.Parameters.AddWithValue("@Id", detalleVenta.DetalleVentaId);

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
