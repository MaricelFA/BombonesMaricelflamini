using Bombones.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Servicios.Servicios.Facales
{
    public interface IServiciosTiposDedocumentos
    {
        List<TipoDeDocumento> GetLista();
        void Guardar(TipoDeDocumento documento);
        void Borrar(TipoDeDocumento documento);
        TipoDeDocumento GetTipodeDocumentoPorId(int id);
        bool Existe(TipoDeDocumento documento);
        bool EstaRelacionado(TipoDeDocumento documento);
        void Editar(TipoDeDocumento documento);
    }
}
