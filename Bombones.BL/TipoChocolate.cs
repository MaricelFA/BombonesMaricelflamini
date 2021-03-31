using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.BL
{
    public class TipoChocolate
    {
        public int TipoChocolateId { get; set; }
        public string NombreTipoChocolate { get; set; }

        public TipoChocolate Clone()
        {
            return (TipoChocolate)this.MemberwiseClone();
        }
    }
}
