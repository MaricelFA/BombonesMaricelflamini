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
    public class ServiciosTiposDeChocolate : IServiciosTiposDeChocolate

    {

        private ConexionBD _conexion;
        private IRepositorioTiposDeChocolate _repositorio;
        public void Borrar(int id)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioTiposDeChocolate(_conexion.AbrirConexion());
                _repositorio.Borrar(id);
                _conexion.CerrarConexion();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(TipoChocolate tipoChocolate)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioTiposDeChocolate(_conexion.AbrirConexion());
                var bEstaRelacionado = _repositorio.EstaRelacionado(tipoChocolate);
                _conexion.CerrarConexion();
                return bEstaRelacionado;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(TipoChocolate tipoChocolate)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioTiposDeChocolate(_conexion.AbrirConexion());
                var bExiste = _repositorio.Existe(tipoChocolate);
                _conexion.CerrarConexion();
                return bExiste;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<TipoChocolate> GetLista()
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioTiposDeChocolate(_conexion.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public TipoChocolate GetTipoChocolatePorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Guardar(TipoChocolate tipoChocolate)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioTiposDeChocolate(_conexion.AbrirConexion());
                _repositorio.Guardar(tipoChocolate);
                _conexion.CerrarConexion();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
