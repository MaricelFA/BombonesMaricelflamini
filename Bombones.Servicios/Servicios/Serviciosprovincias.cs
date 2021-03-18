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
            throw new NotImplementedException();
        }

        public bool Existe(Provincia provincia)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
