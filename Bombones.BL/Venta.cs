using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.BL
{
    public class Venta
    {
        public int VentaId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
    }
}
