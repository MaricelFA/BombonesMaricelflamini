using Bombones.BL;
using Bombones.BL.Dtos.Localidad;
using Bombones.BL.Dtos.Provincia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Servicios.Servicios.Facales
{
    public interface IServiciosLocalidades
    {
        List<LocalidadListDto> GetLista();
        List<LocalidadListDto> GetLista(int provinciaId);
        void Guardar(LocalidadEditDto localidadEditDto);
        void Borrar(int LocalidadDtoLocalidadId);
        LocalidadEditDto GetLocalidadPorId(int id);
        bool Existe(LocalidadEditDto localidad);
        bool EstaRelacionado(LocalidadListDto localidadListDto);
        List<LocalidadListDto> GetLista(ProvinciaListDto provincia);
    }
}
