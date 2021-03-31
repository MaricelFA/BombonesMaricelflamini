using Bombones.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Data.Repositorios.Facales
{
    public interface IRepositorioLocalidades
    {
        List<Localidad> GetLista();
        void Guardar(Localidad localidad);
        void Borrar(int id);
        Localidad GetLocalidadPorId(int id);
        bool Existe(Localidad localidad);
        List<Localidad> GetLista(int provinciaId);
    }
}
