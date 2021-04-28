using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.BL
{
    public class TipoDeDocumento 
    {
        public int TipoDeDocumentoId { get; set; }
        public string Descripcion { get; set; }
        public object Clone()
        {
            return (TipoDeDocumento) this.MemberwiseClone();
        }
    }
}
