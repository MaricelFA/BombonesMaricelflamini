using Bombones.BL;
using Bombones.BL.Dtos.Bombon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Data.Repositorios.Facales
{
    public interface IRepositorioBombones
    {
        List<BombonListDto> GetLista();
        void Guardar(Bombon bombon);
        bool Existe(Bombon bombon);
        void Borrar(int bombonId);
        BombonEditDto GetBombonPorId(int bombonId);
        bool EstaRelacionado(BombonListDto bombonListDto);
        void ActualizarStock(Bombon bombon, int v);
    }
}
