using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.BL.Dtos.DetalleVenta
{
    public class DetalleVentaListDto : ICloneable
    {
        public int DetalleVentaId { get; set; }
        public int VentaId { get; set; }
        public int Clienteid { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreBombon { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
       
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
