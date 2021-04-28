
using Bombones.BL.Dtos.Bombon;
using Bombones.BL.Dtos.Venta;

namespace Bombones.BL.Dtos.DetalleVenta
{
    public class DetalleVentaEditDto
    {
        public int DetalleVentaId { get; set; }
        public VentaListDto venta { get; set; }
        public BombonListDto bombon { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
