using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.BL
{
    public class TipodeNuez
    {
        public int TipoDeNuezId { get; set; }
        public string NombreTipoDeNuez { get; set; }
        public TipodeNuez Clone()
        {
            return (TipodeNuez)this.MemberwiseClone();
        }
    }
}
