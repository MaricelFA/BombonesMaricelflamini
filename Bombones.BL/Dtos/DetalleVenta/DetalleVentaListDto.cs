using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.BL.Dtos.DetalleVenta
{
    public class DetalleVentaListDto 
    {
        public int DetalleVentaId { get; set; }
        public int VentaId { get; set; }
       
        public string NombreBombon { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Total => Precio * (decimal)Cantidad;


    }
}


