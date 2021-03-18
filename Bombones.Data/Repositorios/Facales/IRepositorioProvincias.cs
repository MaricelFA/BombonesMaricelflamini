using Bombones.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Data.Repositorios.Facales
{
    public interface IRepositorioProvincias
    {
        List<Provincia> GetLista();
        void Guardar(Provincia provincia);
        void Borrar(int id);
        Provincia GetProvinciaPorId(int id);
        bool Existe(Provincia provincia);
    }
}
