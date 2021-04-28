using Bombones.BL;
using Bombones.BL.Dtos.Provincia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Servicios.Servicios.Facales
{
    public interface IServiciosProvincias
    {
        List<ProvinciaListDto> GetLista();
        void Guardar(ProvinciaEditDto provincia);
        void Borrar(int id);
        ProvinciaEditDto GetProvinciaPorId(int id);
        bool Existe(ProvinciaEditDto provincia);
        bool EstaRelacionado(ProvinciaListDto provincia);
    }
}
