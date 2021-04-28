using Bombones.BL;
using Bombones.BL.Dtos.Provincia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Data.Repositorios.Facales
{
    public interface IRepositorioProvincias
    {
        List<ProvinciaListDto> GetLista();
        void Guardar(Provincia provincia);
        void Borrar(int id);
        ProvinciaEditDto GetProvinciaPorId(int id);
        bool Existe(Provincia provincia);
        bool EstaRelacionado(ProvinciaListDto provincia);
    }
}
