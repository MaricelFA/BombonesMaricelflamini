using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.BL
{
    public class Bombon
    {
        public int BombonId { get; set; }
        public string NombreBombon { get; set; }
        public int TipoChocolateId  { get; set; }
        public int TipodeNuezId { get; set; }
        public int TipodeRellenoId { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public int CantidadEnExistencia { get; set; }
    }
}
