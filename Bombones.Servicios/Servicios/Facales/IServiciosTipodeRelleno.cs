using Bombones.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Servicios.Servicios.Facales
{
    public interface IServiciosTipodeRelleno
    {
        List<TipodeRelleno> GetLista();
        void Guardar(TipodeRelleno tipodeRelleno);
        void Borrar(int id);
        TipodeRelleno GetTipodeRellenoPorId(int id);
        bool Existe(TipodeRelleno tipodeRelleno);
        bool EstaRelacionado(TipodeRelleno tipodeRelleno);
    }
}
