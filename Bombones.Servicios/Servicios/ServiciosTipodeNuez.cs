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
    public class ServiciosTipodeNuez : IServiciosTipodeNuez
    {
        private ConexionBD _conexion;
        private IRepositorioTipodeNuez _repositorio;

        public void Borrar(int id)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioTipoDeNuez(_conexion.AbrirConexion());
                _repositorio.Borrar(id);
                _conexion.CerrarConexion();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(TipodeNuez tipodeNuez)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioTipoDeNuez(_conexion.AbrirConexion());
                var bEstaRelacionado = _repositorio.EstaRelacionado(tipodeNuez);
                _conexion.CerrarConexion();
                return bEstaRelacionado;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(TipodeNuez tipodeNuez)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioTipoDeNuez(_conexion.AbrirConexion());
                var bExiste = _repositorio.Existe(tipodeNuez);
                _conexion.CerrarConexion();
                return bExiste;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<TipodeNuez> GetLista()
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioTipoDeNuez(_conexion.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public TipodeNuez GetTipodeNuezPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Guardar(TipodeNuez tipodeNuez)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioTipoDeNuez(_conexion.AbrirConexion());
                _repositorio.Guardar(tipodeNuez);
                _conexion.CerrarConexion();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
