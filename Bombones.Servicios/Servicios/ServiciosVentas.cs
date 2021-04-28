using Bombones.BL;
using Bombones.BL.Dtos.Venta;
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
    public class ServiciosVentas : IServiciosVentas
    {
        private ConexionBD _conexion;
        private IRepositorioVentas _repositorio;
        private IRepositorioClientes _repositorioClientes;

        public ServiciosVentas(ConexionBD conexion, IRepositorioVentas repositorio,
            IRepositorioClientes repositorioClientes)
        {
            _conexion = conexion;
            _repositorio = repositorio;
            _repositorioClientes = repositorioClientes;
            
        }

        public void Borrar(int ventaId)
        {
            try
            {
                _conexion = new ConexionBD();
                _conexion.AbrirConexion();
                _repositorio.Borrar(ventaId);
                _conexion.CerrarConexion();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<VentaListDto> GetLista()
        {
            try
            {
                _conexion = new ConexionBD();
                _conexion.AbrirConexion();
                var lista = _repositorio.GetLista();
                _conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(VentaEditDto ventaEditDto)
        {
            try
            {
                _conexion = new ConexionBD();
                _conexion.AbrirConexion();
                Venta venta = new Venta
                {
                    VentaId = ventaEditDto.VentaId,
                    ClienteId = ventaEditDto.cliente.ClienteId,
                    Fecha = ventaEditDto.Fecha,

                };
                _repositorio.Guardar(venta);
                _conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
