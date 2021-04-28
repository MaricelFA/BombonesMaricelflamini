using Bombones.BL;
using Bombones.BL.Dtos.Localidad;
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
            try
            {
                _conexion = new ConexionBD();
                _repositorioLocalidades = new RepositorioLocalidades(_conexion.AbrirConexion());
                _repositorioLocalidades.Borrar(id);
                _conexion.CerrarConexion();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public bool EstaRelacionado(LocalidadListDto localidadListDto)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorioLocalidades = new RepositorioLocalidades(_conexion.AbrirConexion());

                var estaRelacionado = _repositorioLocalidades.EstaRelacionado(localidadListDto);
                _conexion.CerrarConexion();
                return estaRelacionado;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(LocalidadEditDto localidadDto)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorioLocalidades = new RepositorioLocalidades(_conexion.AbrirConexion());
                Localidad localidad = new Localidad
                {
                    LocalidadId = localidadDto.LocalidadId,
                    NombreLocalidad= localidadDto.NombreLocalidad,
                    Provincia= new Provincia
                    {
                        ProvinciaId=localidadDto.ProvinciaId,
                        NombreProvincia=localidadDto.NombreProvincia
                    }
                };
                var bExiste = _repositorioLocalidades.Existe(localidad);

                _conexion.CerrarConexion();
                return bExiste;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<LocalidadListDto> GetLista()
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

        public List<LocalidadListDto> GetLista(int provinciaId)
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

        public LocalidadEditDto GetLocalidadPorId(int id)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorioProvincias = new RepositorioProvincias(_conexion.AbrirConexion());
                _repositorioLocalidades = new RepositorioLocalidades(_conexion.AbrirConexion(), _repositorioProvincias);
                var localidad = _repositorioLocalidades.GetLocalidadPorId(id);
                _conexion.CerrarConexion();
                return localidad;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(LocalidadEditDto localidadDto)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorioLocalidades = new RepositorioLocalidades(_conexion.AbrirConexion());
               // _repositorioProvincias = new RepositorioProvincias(_conexion.AbrirConexion());
                Localidad localidad = new Localidad
                {
                    LocalidadId = localidadDto.LocalidadId,
                    NombreLocalidad = localidadDto.NombreLocalidad,
                    // Provincia=localidad.Provincia
                    // Provincia = _repositorioProvincias.GetProvinciaPorId(localidadDto.ProvinciaId)
                    Provincia = new Provincia
                    {
                        ProvinciaId = localidadDto.Provincia.ProvinciaId,
                        NombreProvincia = localidadDto.Provincia.NombreProvincia
                    }
                };
                _repositorioLocalidades.Guardar(localidad);

                localidadDto.LocalidadId = localidad.LocalidadId;

                _conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
