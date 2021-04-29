using Bombones.BL.Dtos.Cliente;
using Bombones.BL.Dtos.DetalleVenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.BL.Dtos.Venta
{
    public class VentaEditDto
    {
        public int VentaId { get; set; }
        public ClienteListDto cliente { get; set; }
        public DateTime Fecha { get; set; }
        public List<DetalleVentaEditDto> DetalleVentas { get; set; } = new List<DetalleVentaEditDto>();
    }
}
