using Bombones.BL;
using Bombones.BL.Dtos.Localidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Data.Repositorios.Facales
{
    public interface IRepositorioLocalidades
    {
        List<LocalidadListDto> GetLista();
        void Guardar(Localidad localidad);
        void Borrar(int id);
        LocalidadEditDto GetLocalidadPorId(int id);
        bool Existe(Localidad localidad);
        List<LocalidadListDto> GetLista(int provinciaId);
        bool EstaRelacionado(LocalidadListDto localidadListDto);
    }
}
