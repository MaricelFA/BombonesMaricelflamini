using Bombones.BL.Dtos.DetalleVenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.BL.Dtos.Venta
{
    public class VentaListDto 
    {
        
        public int VentaId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime Fecha { get; set; }
        public List<DetalleVentaListDto> ItemsVenta { get; set; } = new List<DetalleVentaListDto>();
        public decimal TotalVenta => ItemsVenta.Sum(i => i.Precio * (decimal)i.Cantidad);

    }
}
