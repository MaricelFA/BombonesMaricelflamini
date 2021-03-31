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
    public class ServiciosLocalidades : IServiciosLocalidades
    {
        private IRepositorioLocalidades _repositorioLocalidades;
        private IRepositorioProvincias _repositorioProvincias;
        private ConexionBD _conexion;

        public void Borrar(int id)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Localidad localidad)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorioLocalidades = new RepositorioLocalidades(_conexion.AbrirConexion());
                var bExiste = _repositorioLocalidades.Existe(localidad);
                _conexion.CerrarConexion();
                return bExiste;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Localidad> GetLista()
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorioProvincias = new RepositorioProvincias(_conexion.AbrirConexion());
                _repositorioLocalidades = new RepositorioLocalidades(_conexion.AbrirConexion(), _repositorioProvincias);
                var lista = _repositorioLocalidades.GetLista();
                _conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<Localidad> GetLista(int provinciaId)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorioProvincias = new RepositorioProvincias(_conexion.AbrirConexion());
                _repositorioLocalidades = new RepositorioLocalidades(_conexion.AbrirConexion(), _repositorioProvincias);
                var lista = _repositorioLocalidades.GetLista(provinciaId);
                _conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public Localidad GetLocalidadPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Guardar(Localidad localidad)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorioLocalidades = new RepositorioLocalidades(_conexion.AbrirConexion());
                _repositorioLocalidades.Guardar(localidad);
                _conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
