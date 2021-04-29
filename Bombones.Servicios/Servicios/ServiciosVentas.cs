using Bombones.BL;
using Bombones.BL.Dtos.DetalleVenta;
using Bombones.BL.Dtos.Venta;
using Bombones.Data;
using Bombones.Data.Repositorios;
using Bombones.Data.Repositorios.Facales;
using Bombones.Servicios.Servicios.Facales;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        private IRepositorioDetalleVentas _repositoriodetalle;
        private IRepositorioBombones _repositoriobombones;

        public ServiciosVentas()
        {
        }

        public ServiciosVentas(ConexionBD conexion, IRepositorioVentas repositorio,
            IRepositorioClientes repositorioClientes, IRepositorioBombones repositorioBombones)
        {
            _conexion = conexion;
            _repositorio = repositorio;
            _repositorioClientes = repositorioClientes;
            _repositoriobombones = repositorioBombones;
            
        }

        public void Borrar(int ventaId)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioVentas(_conexion.AbrirConexion());
                _repositorio.Borrar(ventaId);
                _conexion.CerrarConexion();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<DetalleVentaListDto> GetDetalle(int ventaDtoVentaId)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositoriodetalle = new RepositorioDetalleVentas(_conexion.AbrirConexion());
                var lista = _repositoriodetalle.GetLista(ventaDtoVentaId);
                _conexion.CerrarConexion();
                return lista;

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
                _repositoriodetalle = new RepositorioDetalleVentas(_conexion.AbrirConexion());
                _repositorio = new RepositorioVentas(_conexion.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        

        public VentaEditDto GetVentaPorId(int id)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorioClientes = new RepositorioClientes(_conexion.AbrirConexion());
                _repositoriodetalle = new RepositorioDetalleVentas(_conexion.AbrirConexion());
                _repositoriobombones = new RepositorioBombones(_conexion.AbrirConexion());
                _repositorio = new RepositorioVentas(_conexion.AbrirConexion(), _repositorioClientes, _repositoriodetalle, _repositoriobombones);

                var Bombon = _repositorio.GetVentaPorId(id);
                _conexion.CerrarConexion();
                return Bombon;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(VentaEditDto ventaEditDto)
        {
            #region Pasar de Dto a Entidad

            var listaDetalles = new List<DetalleVenta>();
            foreach (var itemDto in ventaEditDto.DetalleVentas)
            {
                var item = new DetalleVenta()
                {
                    DetalleVentaId = itemDto.DetalleVentaId,
                    bombon = new Bombon
                    {
                        BombonId = itemDto.bombon.BombonId,
                        NombreBombon = itemDto.bombon.NombreBombon
                    },
                    Cantidad = itemDto.Cantidad,
                    Costo = itemDto.Costo
                };
                listaDetalles.Add(item);
            }

            var venta = new Venta
            {
                VentaId = ventaEditDto.VentaId,
                cliente = new Cliente
                {
                    ClienteId = ventaEditDto.cliente.ClienteId,
                    Nombre = ventaEditDto.cliente.Nombre,
                    Apellido=ventaEditDto.cliente.Apellido,
                },
                Fecha = ventaEditDto.Fecha,
                DetalleVentas = listaDetalles

            };


            #endregion

            #region Guardar la Venta

            _conexion = new ConexionBD();
            SqlTransaction tran = null;
            try
            {
                SqlConnection cn = _conexion.AbrirConexion();
                tran = cn.BeginTransaction();
                _repositorio = new RepositorioVentas(cn, tran);
                //_repositoriobombones = new RepositorioBombones (cn, tran);
                _repositoriodetalle = new RepositorioDetalleVentas(cn, tran);

                _repositorio.Guardar(venta);
                #region Recorrer los detalles de la venta

                foreach (var detalleVenta in venta.DetalleVentas)
                {
                    detalleVenta.venta = venta;
                    _repositoriodetalle.Guardar(detalleVenta);
                    //_repositoriobombones.ActualizarStock(detalleVenta.bombon,                        detalleVenta.Cantidad);

                }
                #endregion
                tran.Commit();
                ventaEditDto.VentaId = venta.VentaId;
            }
            catch (Exception e)
            {
                tran.Rollback();
                throw new Exception(e.Message);
            }


            #endregion

        }
    }
}
