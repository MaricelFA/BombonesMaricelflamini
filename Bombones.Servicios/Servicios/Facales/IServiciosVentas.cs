using Bombones.BL.Dtos.DetalleVenta;
using Bombones.BL.Dtos.Venta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Servicios.Servicios.Facales
{
    public interface IServiciosVentas
    {
        List<VentaListDto> GetLista();
        void Guardar(VentaEditDto ventaEditDto);
        void Borrar(int ventaId);
  
        VentaEditDto GetVentaPorId(int id);

        List<DetalleVentaListDto> GetDetalle(int ventaDtoVentaId);
    }
}
