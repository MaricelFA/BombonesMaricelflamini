using Bombones.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Servicios.Servicios.Facales
{
    public interface IServiciosTipodeNuez
    {
        List<TipodeNuez> GetLista();
        void Guardar(TipodeNuez tipodeNuez);
        void Borrar(int id);
        TipodeNuez GetTipodeNuezPorId(int id);
        bool Existe(TipodeNuez tipodeNuez);
        bool EstaRelacionado(TipodeNuez tipodeNuez);
    }
}
