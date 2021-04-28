using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.BL.Dtos.Provincia
{
    public class ProvinciaListDto : ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public int ProvinciaId { get; set; }
        public string NombreProvincia { get; set; }
    }
}
