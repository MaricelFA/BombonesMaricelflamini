using Bombones.BL;
using Bombones.Data;
using Bombones.Data.Repositorios;
using Bombones.Servicios.Servicios.Facales;
using System;
using System.Collections.Generic;

namespace Bombones.Servicios.Servicios
{
    public class Serviciosprovincias: IServiciosProvincias
    {
        private ConexionBD _conexion;
        private RepositorioProvincias _repositorio;

        public void Borrar(int id)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioProvincias(_conexion.AbrirConexion());
                _repositorio.Borrar(id);
                _conexion.CerrarConexion();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Provincia provincia)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioProvincias(_conexion.AbrirConexion());
                var bExiste = _repositorio.Existe(provincia);
                _conexion.CerrarConexion();
                return bExiste;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Provincia> GetLista()
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioProvincias(_conexion.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public Provincia GetProvinciaPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Guardar(Provincia provincia)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioProvincias(_conexion.AbrirConexion());
                _repositorio.Guardar(provincia);
                _conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Provincia provincia)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioProvincias(_conexion.AbrirConexion());
                var bEstaRelacionado = _repositorio.EstaRelacionado(provincia);
                _conexion.CerrarConexion();
                return bEstaRelacionado;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
