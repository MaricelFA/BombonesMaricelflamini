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
    public class ServiciosTiposDeDocumentos : IServiciosTiposDedocumentos
    {
        private ConexionBD _conexion;
        private IRepositorioTipoDeDocumento _repositorio;


        public void Borrar(TipoDeDocumento documento)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioTipoDeDoc(_conexion.AbrirConexion());
                _repositorio.Borrar(documento);
                _conexion.CerrarConexion();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Editar(TipoDeDocumento documento)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioTipoDeDoc(_conexion.AbrirConexion());
                _repositorio.Editar(documento);
                _conexion.CerrarConexion();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(TipoDeDocumento documento)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioTipoDeDoc(_conexion.AbrirConexion());
                var estaRelacionado = _repositorio.EstaRelacionado(documento);
                _conexion.CerrarConexion();
                return estaRelacionado;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(TipoDeDocumento documento)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioTipoDeDoc(_conexion.AbrirConexion());
                var existe = _repositorio.Existe(documento);
                _conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<TipoDeDocumento> GetLista()
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioTipoDeDoc(_conexion.AbrirConexion());
                var lista = _repositorio.GetTipoDeDeDocumentos();
                _conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public TipoDeDocumento GetTipodeDocumentoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Guardar(TipoDeDocumento documento)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioTipoDeDoc(_conexion.AbrirConexion());
                _repositorio.Guardar(documento);
                _conexion.CerrarConexion();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
