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
        public int VentaId { get; set; }
        public int BombonId { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
