using Bombones.BL.Dtos.DetalleVenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Servicios.Servicios.Facales
{
    public interface IServiciosDetalleVentas
    {
        
        void Guardar(DetalleVentaEditDto detalleEditDto);
        void Borrar(int detalleId);
    }
}
