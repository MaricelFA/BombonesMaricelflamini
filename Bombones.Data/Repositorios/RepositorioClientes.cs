using Bombones.BL;
using Bombones.BL.Dtos.Cliente;
using Bombones.BL.Dtos.Localidad;
using Bombones.BL.Dtos.Provincia;
using Bombones.Data.Repositorios.Facales;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Data.Repositorios
{
    public class RepositorioClientes : IRepositorioClientes
    {
        private readonly SqlConnection _conexion;
        private readonly IRepositorioProvincias _repositorioProvincias;
        private readonly IRepositorioLocalidades _repositorioLocalidades;
        private  IRepositorioTipoDeDocumento _repositorioTipoDeDocumento;

        public RepositorioClientes(SqlConnection sqlConnection, IRepositorioProvincias repositorioProvincias, IRepositorioLocalidades repositorioLocalidades)
        {
            _conexion = sqlConnection;
            _repositorioProvincias = repositorioProvincias;
            _repositorioLocalidades = repositorioLocalidades;
        }

        public RepositorioClientes(SqlConnection sqlConnection)
        {
            _conexion = sqlConnection;
        }

        public void Borrar(int clienteId)
        {
            try
            {
                var cadenaComando = "DELETE FROM Clientes WHERE ClienteId=@id";
                var comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", clienteId);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Cliente cliente)
        {
            if (cliente.ClienteId == 0)
            {
                string cadenaComando = "SELECT * FROM Clientes WHERE TipoDeDocumentoId=@tipodocid AND NroDocumento=@nrodoc";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@tipodocid", cliente.TipoDeDocumentoId);
                comando.Parameters.AddWithValue("@nrodoc", cliente.NroDocumento);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            else
            {

                string cadenaComando = "SELECT * FROM Clientes WHERE TipoDeDocumentoId=@tipodocid AND NroDocumento=@nrodoc  AND ClienteId<>@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@tipodocid", cliente.TipoDeDocumentoId);
                comando.Parameters.AddWithValue("@nrodoc", cliente.NroDocumento);
                comando.Parameters.AddWithValue("@id", cliente.ClienteId);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;

            }
        }

        public ClienteEditDto GetClientePorId(int clienteid)
        {
            ClienteEditDto cliente = null;
            try
            { 
            
                string cadenaComando = "SELECT ClienteId, Nombre, Apellido, TipoDeDocumentoId, NroDocumento,Direccion, LocalidadId, ProvinciaId, TelefonoFijo, TelefonoMovil, CorreoElectronico, FechaDeNacimiento FROM Clientes WHERE ClienteId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", clienteid);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                   cliente = ConstruirClienteEditDto (reader);
                }

                reader.Close();
                return cliente;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private ClienteEditDto ConstruirClienteEditDto(SqlDataReader reader)
        {
            _repositorioTipoDeDocumento = new RepositorioTipoDeDoc(_conexion);
            var provinciaEditDto = _repositorioProvincias.GetProvinciaPorId(reader.GetInt32(7));
            var localidadEditDto = _repositorioLocalidades.GetLocalidadPorId(reader.GetInt32(6));
            return new ClienteEditDto
            {
                ClienteId = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                Apellido = reader.GetString(2),
                documento = _repositorioTipoDeDocumento.GetTipoDeDocumentoPorId(reader.GetInt32(3)),
                NroDocumento = reader.GetString(4),
                Direccion= reader.GetString(5),
                Localidad = new LocalidadListDto { LocalidadId = localidadEditDto.LocalidadId, NombreLocalidad = localidadEditDto.NombreLocalidad, NombreProvincia= localidadEditDto.NombreProvincia },
                Provincia = new ProvinciaListDto { ProvinciaId = provinciaEditDto.ProvinciaId, NombreProvincia = provinciaEditDto.NombreProvincia },
                TelefonoFijo = reader.GetString(8),
                TelefonoMovil= reader.GetString(9),
                CorreoElectronico = reader.GetString(10),
                FechaDeNacimiento= reader.GetDateTime(11)
            };
        }

        public List<ClienteListDto> GetLista()
        {
            List<ClienteListDto> lista = new List<ClienteListDto>();
            try
            {
                string cadenaComando = "SELECT ClienteId, Nombre, Apellido, NombreLocalidad, NombreProvincia, Direccion  FROM Clientes C INNER JOIN Provincias P ON C.ProvinciaId = P.ProvinciaId INNER JOIN Localidades L ON C.LocalidadId = L.LocalidadId ";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var clienteDto = ConstruirClienteDto(reader);
                    lista.Add(clienteDto);
                }

                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private ClienteListDto ConstruirClienteDto(SqlDataReader reader)
        {

            ClienteListDto clienteListDto = new ClienteListDto();
            clienteListDto.ClienteId = reader.GetInt32(0);
            clienteListDto.Nombre = reader.GetString(1);
            clienteListDto.Apellido = reader.GetString(2);
            clienteListDto.NombreLocalidad = reader.GetString(3);
            clienteListDto.NombreProvincia = reader.GetString(4);
            clienteListDto.Direccion= reader.GetString(5);
            return clienteListDto;
        }

        public void Guardar(Cliente cliente)
        {
            if (cliente.ClienteId == 0)
            {

                try
                {
                    string cadenaComando = "INSERT INTO Clientes VALUES(@nombre,@Apellido, @TipoDocId, @NroDoc,@direccion, @LocId, @ProvId, @TelFijo, @TelMov, @CorreoE, @FN)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
                    comando.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                    comando.Parameters.AddWithValue("@TipoDocId", cliente.TipoDeDocumentoId);
                    comando.Parameters.AddWithValue("@NroDoc", cliente.NroDocumento);
                    comando.Parameters.AddWithValue("@direccion", cliente.Direccion);
                    comando.Parameters.AddWithValue("@LocId", cliente.LocalidadId);
                    comando.Parameters.AddWithValue("@ProvId", cliente.ProvinciaId);
                    comando.Parameters.AddWithValue("@TelFijo", cliente.TelefonoFijo);
                    comando.Parameters.AddWithValue("@TelMov", cliente.TelefonoMovil);
                    comando.Parameters.AddWithValue("@CorreoE", cliente.CorreoElectronico);
                    comando.Parameters.AddWithValue("@FN", cliente.FechaDeNacimiento);
                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _conexion);
                    cliente.ClienteId = (int)(decimal)comando.ExecuteScalar();

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
                    string cadenaComando = "UPDATE Clientes SET Nombre=@nombre,Apellido=@Apellido, TipoDeDocumentoId=@TipoDocId,NroDocumento= @NroDoc,Direccion=@direccion, LocalidadId= @LocId,ProvinciaId= @ProvId,TelefonoFijo= @TelFijo,TelefonoMovil=@TelMov,CorreoElectronico= @CorreoE,FechaDeNacimiento= @FN WHERE ClienteId = @id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
                    comando.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                    comando.Parameters.AddWithValue("@TipoDocId", cliente.TipoDeDocumentoId);
                    comando.Parameters.AddWithValue("@NroDoc", cliente.NroDocumento);
                    comando.Parameters.AddWithValue("@direccion", cliente.Direccion);
                    comando.Parameters.AddWithValue("@LocId", cliente.LocalidadId);
                    comando.Parameters.AddWithValue("@ProvId", cliente.ProvinciaId);
                    comando.Parameters.AddWithValue("@TelFijo", cliente.TelefonoFijo);
                    comando.Parameters.AddWithValue("@TelMov", cliente.TelefonoMovil);
                    comando.Parameters.AddWithValue("@CorreoE", cliente.CorreoElectronico);
                    comando.Parameters.AddWithValue("@FN", cliente.FechaDeNacimiento);
                    comando.Parameters.AddWithValue("@id", cliente.ClienteId);
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

    
        

        public bool EstaRelacionado(ClienteListDto clienteListDto)
        {
            try
            {
                var cadenaComando = "SELECT * From Ventas WHERE ClienteId=@Id";
                var comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@Id", clienteListDto.ClienteId );
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
