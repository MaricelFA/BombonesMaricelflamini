using Bombones.BL;
using Bombones.BL.Dtos.Provincia;
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

        public bool Existe(ProvinciaEditDto provinciaDto)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioProvincias(_conexion.AbrirConexion());
                var provincia = new Provincia
                {
                    ProvinciaId = provinciaDto.ProvinciaId,
                    NombreProvincia = provinciaDto.NombreProvincia
                };
                var existe = _repositorio.Existe(provincia);
                _conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<ProvinciaListDto> GetLista()
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

        public ProvinciaEditDto GetProvinciaPorId(int id)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioProvincias(_conexion.AbrirConexion());
                var provincia = _repositorio.GetProvinciaPorId(id);
                _conexion.CerrarConexion();
                return provincia;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        

        public void Guardar(ProvinciaEditDto provinciaDto)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioProvincias(_conexion.AbrirConexion());
                 var  provincia  =  new  Provincia
                {
                    ProvinciaId  =  provinciaDto . ProvinciaId ,
                    NombreProvincia  =  provinciaDto . NombreProvincia
                };
                _repositorio.Guardar(provincia);
                _conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(ProvinciaListDto provincia)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioProvincias(_conexion.AbrirConexion());

                var estaRelacionado = _repositorio.EstaRelacionado(provincia);
                _conexion.CerrarConexion();
                return estaRelacionado;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    
    }
}
