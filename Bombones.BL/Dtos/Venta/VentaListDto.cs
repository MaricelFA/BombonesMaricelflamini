using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.BL.Dtos.Venta
{
    public class VentaListDto : ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public int VentaId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Fecha { get; set; }
    }
}
