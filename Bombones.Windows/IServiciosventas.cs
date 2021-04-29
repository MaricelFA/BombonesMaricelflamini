using Bombones.BL.Dtos.Venta;

namespace Bombones.Windows
{
    internal interface IServiciosventas
    {
        VentaEditDto GetVentaPorId(int ventaId);
        void Guardar(VentaEditDto ventaEdit);
        void Borrar(int ventaId);
    }
}