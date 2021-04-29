using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.BL
{
    public class DetalleVenta
    {
        public int DetalleVentaId { get; set; }
        public Venta venta { get; set; }
        public Bombon bombon { get; set; }
        public decimal Costo { get; set; }
        public int Cantidad { get; set; }
    }
}
