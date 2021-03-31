using Bombones.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Data.Repositorios.Facales
{
    public interface IRepositorioTipodeRelleno
    {
        List<TipodeRelleno> GetLista();
        void Guardar(TipodeRelleno tipodeRelleno);
        void Borrar(int id);
        TipodeRelleno GetTipoRellenoPorId(int id);
        bool Existe(TipodeRelleno tipodeRelleno);
        bool EstaRelacionado(TipodeRelleno tipodeRelleno);
    }
}
