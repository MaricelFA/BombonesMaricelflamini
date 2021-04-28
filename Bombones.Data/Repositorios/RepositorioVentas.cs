using Bombones.BL;
using Bombones.BL.Dtos.Venta;
using Bombones.Data.Repositorios.Facales;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Data.Repositorios
{
    public class RepositorioVentas : IRepositorioVentas
    {
        private readonly SqlConnection _conexion;
        private IRepositorioClientes _repositorioClientes;

        public RepositorioVentas (SqlConnection sqlConnection,IRepositorioClientes repositorioClientes)
        {
            _conexion = sqlConnection;
            _repositorioClientes = repositorioClientes;
        }

        public void Borrar(int ventaId)
        {
            try
            {
                var cadenaComando = "DELETE FROM Ventas WHERE VentaId=@id";
                var comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", ventaId);
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

        public bool EstaRelacionado(VentaListDto ventaListDto)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Venta venta)
        {
            throw new NotImplementedException();
        }

        public List<VentaListDto> GetLista()
        {
            List<VentaListDto> lista = new List<VentaListDto>();
            try
            {
                string cadenaComando = "select VentaId,C.Nombre,C.Apellido,V.Fecha FROM Ventas V INNER JOIN Clientes C on V.ClienteId = C.ClienteId";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var ventaDto = ConstruirVentaListDto(reader);
                    lista.Add(ventaDto);
                }

                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private VentaListDto ConstruirVentaListDto(SqlDataReader reader)
        {
            VentaListDto ventaListDto = new VentaListDto();
            {
                ventaListDto.VentaId = reader.GetInt32(0);
                ventaListDto.Nombre = reader.GetString(1);
                ventaListDto.Apellido = reader.GetString(2);
                ventaListDto.Fecha = reader.GetDateTime(3);
                return ventaListDto;
                 
            };

        }

        public VentaEditDto GetVentaPorId(int ventaId)
        {
            VentaEditDto venta = null;
            try
            {

                string cadenaComando = "select VentaId,C.Nombre,C.Apellido,V.Fecha FROM Ventas V INNER JOIN Clientes C on V.ClienteId = C.ClienteId Where VentaId=@Id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", ventaId);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    venta = ConstruirVentaEditDto(reader);
                }

                reader.Close();
                return venta;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private VentaEditDto ConstruirVentaEditDto(SqlDataReader reader)
        {
            throw new NotImplementedException();

        }

        public void Guardar(Venta venta)
        {
           if(venta.VentaId==0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO Ventas VALUES (@ventaId,@clienteId,@fecha)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@ventaId", venta.VentaId);
                    comando.Parameters.AddWithValue("@clienteId", venta.ClienteId);
                    comando.Parameters.AddWithValue("@fecha", venta.Fecha);
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
                    string cadenaComando = "UPDATE Ventas set ClienteId=@clienteid, Fecha=@fecha Where VentaId=@Id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@clienteId", venta.ClienteId);
                    comando.Parameters.AddWithValue("@fecha", venta.Fecha);
                    comando.Parameters.AddWithValue("@Id", venta.VentaId);

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
