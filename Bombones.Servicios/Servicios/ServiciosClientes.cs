using Bombones.BL;
using Bombones.BL.Dtos.Cliente;
using Bombones.Data;
using Bombones.Data.Repositorios;
using Bombones.Data.Repositorios.Facales;
using Bombones.Servicios.Servicios.Facales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Servicios.Servicios
{
    public class ServiciosClientes : IServiciosClientes
    {
        private ConexionBD _conexion;
        private IRepositorioClientes _repositorio;
        private IRepositorioLocalidades _repositorioLocalidades;
        private IRepositorioProvincias _repositorioProvincias;

        public ServiciosClientes()
        {
           
        }

        public  ServiciosClientes  (ConexionBD conexion, IRepositorioClientes repositorioClientes, 
            IRepositorioLocalidades repositorioLocalidades, IRepositorioProvincias repositorioProvincias)
        {
            _conexion = conexion;
            _repositorio = repositorioClientes;
            _repositorioLocalidades = repositorioLocalidades;
            _repositorioProvincias = repositorioProvincias;
        }






        public void Borrar(int clienteId)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioClientes(_conexion.AbrirConexion());
                _repositorio.Borrar(clienteId);
                _conexion.CerrarConexion();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(ClienteListDto clienteListDto)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioClientes(_conexion.AbrirConexion());

                var estaRelacionado = _repositorio.EstaRelacionado(clienteListDto);
                _conexion.CerrarConexion();
                return estaRelacionado;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(ClienteEditDto clienteEditDto)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioClientes(_conexion.AbrirConexion());
                Cliente cliente = new Cliente
                {
                    ClienteId= clienteEditDto.ClienteId,
                    Nombre= clienteEditDto.Nombre,
                    Apellido= clienteEditDto.Apellido,
                    TipoDeDocumentoId= clienteEditDto.documento.TipoDeDocumentoId,
                    NroDocumento= clienteEditDto.NroDocumento,
                    Direccion= clienteEditDto.Direccion,
                    LocalidadId=clienteEditDto.Localidad.LocalidadId,
                    ProvinciaId=clienteEditDto.Provincia.ProvinciaId,
                    TelefonoFijo=clienteEditDto.TelefonoFijo,
                    TelefonoMovil=clienteEditDto.TelefonoMovil,
                    CorreoElectronico=clienteEditDto.CorreoElectronico,
                    FechaDeNacimiento=clienteEditDto.FechaDeNacimiento

                };
                var existe = _repositorio.Existe(cliente);
                _conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ClienteEditDto GetClientePorId(int clienteId)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorioLocalidades = new RepositorioLocalidades(_conexion.AbrirConexion(), _repositorioProvincias);
                _repositorioProvincias = new RepositorioProvincias(_conexion.AbrirConexion());
                _repositorio = new RepositorioClientes(_conexion.AbrirConexion(), _repositorioProvincias, _repositorioLocalidades);

                var Cliente = _repositorio.GetClientePorId(clienteId);
                _conexion.CerrarConexion();
                return Cliente;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<ClienteListDto> GetLista()
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioClientes(_conexion.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(ClienteEditDto clienteEditDto)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioClientes(_conexion.AbrirConexion());
                Cliente cliente = new Cliente
                {
                    ClienteId = clienteEditDto.ClienteId,
                    Nombre = clienteEditDto.Nombre,
                    Apellido = clienteEditDto.Apellido,
                    TipoDeDocumentoId = clienteEditDto.documento.TipoDeDocumentoId,
                    NroDocumento = clienteEditDto.NroDocumento,
                    Direccion = clienteEditDto.Direccion,
                    LocalidadId = clienteEditDto.Localidad.LocalidadId,
                    ProvinciaId = clienteEditDto.Provincia.ProvinciaId,
                    TelefonoFijo = clienteEditDto.TelefonoFijo,
                    TelefonoMovil = clienteEditDto.TelefonoMovil,
                    CorreoElectronico = clienteEditDto.CorreoElectronico,
                    FechaDeNacimiento = clienteEditDto.FechaDeNacimiento

                };
                _repositorio.Guardar(cliente);
                _conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
