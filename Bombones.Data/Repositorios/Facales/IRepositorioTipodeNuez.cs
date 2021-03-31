using Bombones.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Data.Repositorios.Facales
{
    public interface IRepositorioTipodeNuez
    {
        List<TipodeNuez> GetLista();
        void Guardar(TipodeNuez tipoDeNuez);
        void Borrar(int id);
        TipodeNuez GetTipoDeNuezPorId(int id);
        bool Existe(TipodeNuez tipoDeNuez);
        bool EstaRelacionado(TipodeNuez tipodeNuez);

    }
}
