using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.BL.Dtos.Bombon
{
    public class BombonListDto : ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public int BombonId { get; set; }
        public string NombreBombon { get; set; }
        public string NombreTipoDeNuez { get; set; }
        public string NombreTipoChocolate { get; set; }
        public string NombreTipoRelleno { get; set; }
        public int CantidadEnExistencia { get; set; }
        public decimal Costo { get; set; }
    }
}
