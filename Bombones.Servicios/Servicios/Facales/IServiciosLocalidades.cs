using Bombones.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Servicios.Servicios.Facales
{
    public interface IServiciosLocalidades
    {
        List<Localidad> GetLista();
        List<Localidad> GetLista(int provinciaId);
        void Guardar(Localidad localidad);
        void Borrar(int id);
        Localidad GetLocalidadPorId(int id);
        bool Existe(Localidad localidad);
    }
}
