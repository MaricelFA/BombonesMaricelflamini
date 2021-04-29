using Bombones.BL;
using Bombones.BL.Dtos.DetalleVenta;
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
    public class ServiciosDetalleVentas : IServiciosDetalleVentas
    {


        private ConexionBD _conexion;
        private IRepositorioDetalleVentas _repositorio;
        private IRepositorioVentas _repositorioVentas;
        private IRepositorioBombones _repositorioBombones;

        public ServiciosDetalleVentas(ConexionBD conexion,IRepositorioDetalleVentas repositorio,  IRepositorioVentas repositorioventas,
            IRepositorioBombones repositorioBombones)
        {
            _conexion = conexion;
            _repositorio = repositorio;
            _repositorioVentas = repositorioventas;
            _repositorioBombones = repositorioBombones;

        }

        public void Borrar(int detalleId)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioDetalleVentas(_conexion.AbrirConexion());
                _repositorio.Borrar(detalleId);
                _conexion.CerrarConexion();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<DetalleVentaListDto> GetLista()
        {
            throw new NotImplementedException();
        }

        public void Guardar(DetalleVentaEditDto detalleEditDto)
        {
            throw new NotImplementedException();
        }

        //public void Borrar(int detalleId)
        //{
        //    try
        //    {
        //        _conexion = new ConexionBD();
        //        _conexion.AbrirConexion();
        //        _repositorio.Borrar(detalleId);
        //        _conexion.CerrarConexion();
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        //public List<DetalleVentaListDto> GetLista(int ventaid)
        //{
        //    try
        //    {
        //        _conexion = new ConexionBD();
        //        _conexion.AbrirConexion();
        //        var lista = _repositorio.GetLista(int ventaid);
        //        _conexion.CerrarConexion();
        //        return lista;
        //    }
        //    catch (Exception e)
        //    {

        //        throw new Exception(e.Message);
        //    }
        //}

        //public void Guardar(DetalleVentaEditDto detalleEditDto)
        //{
        //    try
        //    {
        //        _conexion = new ConexionBD();
        //        _conexion.AbrirConexion();
        //        DetalleVenta venta = new DetalleVenta
        //        {
        //            DetalleVentaId = detalleEditDto.DetalleVentaId,
        //            VentaId = detalleEditDto.venta.VentaId,

        //            BombonId=detalleEditDto.bombon.BombonId,
        //            Precio=detalleEditDto.Precio,
        //            Cantidad=detalleEditDto.Cantidad

        //        };
        //        _repositorio.Guardar(venta);
        //        _conexion.CerrarConexion();

        //    }
        //    catch (Exception e)
        //    {

        //        throw new Exception(e.Message);
        //    }

    }
}
