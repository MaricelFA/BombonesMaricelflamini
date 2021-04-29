using Bombones.BL;
using Bombones.BL.Dtos.Venta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Data.Repositorios.Facales
{
    public interface IRepositorioVentas
    {
        List<VentaListDto> GetLista();
        void Guardar(Venta venta);
        void Borrar(int ventaId);
        VentaEditDto GetVentaPorId(int ventaId);
     
    }
}
