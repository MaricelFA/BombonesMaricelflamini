using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.BL
{
    public class TipodeRelleno
    {
        public int TipoRellenoId { get; set; }
        public string NombreTipoRelleno { get; set; }

        public TipodeRelleno Clone()
        {
            return (TipodeRelleno)this.MemberwiseClone();
        }
    }
}
