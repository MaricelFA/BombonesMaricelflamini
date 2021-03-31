using Bombones.BL;
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
    public class ServiciosTipodeRelleno : IServiciosTipodeRelleno

    {
        private ConexionBD _conexion;
        private IRepositorioTipodeRelleno _repositorio;

        public void Borrar(int id)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioTipodeRelleno(_conexion.AbrirConexion());
                _repositorio.Borrar(id);
                _conexion.CerrarConexion();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(TipodeRelleno tipodeRelleno)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioTipodeRelleno(_conexion.AbrirConexion());
                var bEstaRelacionado = _repositorio.EstaRelacionado(tipodeRelleno);
                _conexion.CerrarConexion();
                return bEstaRelacionado;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(TipodeRelleno tipodeRelleno)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioTipodeRelleno(_conexion.AbrirConexion());
                var bExiste = _repositorio.Existe(tipodeRelleno);
                _conexion.CerrarConexion();
                return bExiste;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<TipodeRelleno> GetLista()
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioTipodeRelleno(_conexion.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public TipodeRelleno GetTipodeRellenoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Guardar(TipodeRelleno tipodeRelleno)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioTipodeRelleno(_conexion.AbrirConexion());
                _repositorio.Guardar(tipodeRelleno);
                _conexion.CerrarConexion();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
