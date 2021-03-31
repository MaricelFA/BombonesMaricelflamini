using Bombones.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Servicios.Servicios.Facales
{
    public interface IServiciosTiposDeChocolate
    {
        List<TipoChocolate> GetLista();
        void Guardar(TipoChocolate tipoChocolate);
        void Borrar(int id);
        TipoChocolate GetTipoChocolatePorId(int id);
        bool Existe(TipoChocolate tipoChocolate);
        bool EstaRelacionado(TipoChocolate tipoChocolate);
    }
}
