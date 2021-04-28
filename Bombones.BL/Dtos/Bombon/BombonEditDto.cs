using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.BL.Dtos.Bombon
{
    public class BombonEditDto
    {
        public int BombonId { get; set; }
        public string NombreBombon { get; set; }
        public TipoChocolate tipoChocolate { get; set; }
        public TipodeNuez tipodeNuez { get; set; }
        public TipodeRelleno tipodeRelleno { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public int CantidadEnExistencia { get; set; }

    }
}
