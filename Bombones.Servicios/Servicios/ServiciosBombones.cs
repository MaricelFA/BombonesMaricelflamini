using Bombones.BL;
using Bombones.BL.Dtos.Bombon;
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
    public class ServiciosBombones : IServiciosBombones
    {
        private ConexionBD _conexion;
        private IRepositorioBombones _repositorio;
        private IRepositorioTipodeNuez _repositorioTipoNuez;
        private IRepositorioTipodeRelleno _repositorioTipoRelleno;
        private IRepositorioTiposDeChocolate _repositorioTiposDeChocolate;

        public ServiciosBombones()
        {
        }

        public ServiciosBombones(ConexionBD conexion, IRepositorioBombones repositorio,
            IRepositorioTipodeNuez repositorioTipodeNuez, IRepositorioTipodeRelleno repositorioTipodeRelleno,
            IRepositorioTiposDeChocolate repositorioTiposDeChocolate)
        {
            _conexion = conexion;
            _repositorio = repositorio;
            _repositorioTipoNuez = repositorioTipodeNuez;
            _repositorioTipoRelleno = repositorioTipodeRelleno;
            _repositorioTiposDeChocolate = repositorioTiposDeChocolate;

        }


        public void Borrar(int bombonId)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioBombones(_conexion.AbrirConexion());
                _repositorio.Borrar(bombonId);
                _conexion.CerrarConexion();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(BombonListDto bombonListDto)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioBombones(_conexion.AbrirConexion());

                var estaRelacionado = _repositorio.EstaRelacionado(bombonListDto);
                _conexion.CerrarConexion();
                return estaRelacionado;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(BombonEditDto bombonEditDto)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioBombones(_conexion.AbrirConexion());
                Bombon bombon = new Bombon
                {
                    BombonId = bombonEditDto.BombonId,
                    NombreBombon = bombonEditDto.NombreBombon,
                    TipoChocolateId = bombonEditDto.tipoChocolate.TipoChocolateId,
                    TipodeNuezId = bombonEditDto.tipodeNuez.TipoDeNuezId,
                    TipodeRellenoId = bombonEditDto.tipodeRelleno.TipoRellenoId,
                    Descripcion = bombonEditDto.Descripcion,
                    Costo = bombonEditDto.Costo,
                    CantidadEnExistencia = bombonEditDto.CantidadEnExistencia


                };
                var existe = _repositorio.Existe(bombon);
                _conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public BombonEditDto GetBombonPorId(int bombonId)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorioTipoNuez = new RepositorioTipoDeNuez(_conexion.AbrirConexion());
                _repositorioTipoRelleno = new RepositorioTipodeRelleno(_conexion.AbrirConexion());
                _repositorioTiposDeChocolate = new RepositorioTiposDeChocolate(_conexion.AbrirConexion());
                _repositorio = new RepositorioBombones(_conexion.AbrirConexion(), _repositorioTipoNuez, _repositorioTipoRelleno, _repositorioTiposDeChocolate);

                var Bombon = _repositorio.GetBombonPorId(bombonId);
                _conexion.CerrarConexion();
                return Bombon;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<BombonListDto> GetLista()
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioBombones(_conexion.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(BombonEditDto bombonEditDto)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioBombones(_conexion.AbrirConexion());
                Bombon bombon = new Bombon
                {
                    BombonId = bombonEditDto.BombonId,
                    NombreBombon = bombonEditDto.NombreBombon,
                    TipoChocolateId = bombonEditDto.tipoChocolate.TipoChocolateId,
                    TipodeNuezId = bombonEditDto.tipodeNuez.TipoDeNuezId,
                    TipodeRellenoId = bombonEditDto.tipodeRelleno.TipoRellenoId,
                    Descripcion = bombonEditDto.Descripcion,
                    Costo = bombonEditDto.Costo,
                    CantidadEnExistencia = bombonEditDto.CantidadEnExistencia

                };
                _repositorio.Guardar(bombon);
                _conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
