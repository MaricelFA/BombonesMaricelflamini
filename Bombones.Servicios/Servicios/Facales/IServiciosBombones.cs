using Bombones.BL.Dtos.Bombon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Servicios.Servicios.Facales
{
    public interface IServiciosBombones
    {
        List<BombonListDto> GetLista();
        void Guardar(BombonEditDto bombonEditDto);
        bool Existe(BombonEditDto bombonEditDto);
        BombonEditDto GetBombonPorId(int bombonId);
        bool EstaRelacionado(BombonListDto bombonListDto);
        void Borrar(int bombonId);
    }
}
