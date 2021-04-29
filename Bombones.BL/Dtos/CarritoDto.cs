using Bombones.BL.Dtos.DetalleVenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.BL.Dtos
{
    public class CarritoDto
    {
        public List<DetalleVentaEditDto> ItemsVenta { get; set; } = new List<DetalleVentaEditDto>();

       

        public void AgregarAlCarrito(DetalleVentaEditDto item)
        {
            
            var itemEnCarrito = ItemsVenta
                .SingleOrDefault(iv => iv.bombon.BombonId == item.bombon.BombonId);
            if (itemEnCarrito == null)
            {
               
                ItemsVenta.Add(item);
            }
            else
            {

                itemEnCarrito.Cantidad += item.Cantidad;
            }
        }

        public void BorrarDelCarrito(DetalleVentaEditDto item)
        {

            ItemsVenta.RemoveAll(i => i.bombon.BombonId == item.bombon.BombonId);
        }

        public List<DetalleVentaEditDto> GetItems()
        {
            return ItemsVenta;
        }

        public void VaciarCarrito()
        {
            ItemsVenta.Clear();
        }

        public decimal InformarTotal()
        {
            return ItemsVenta.Sum(i => (decimal)i.Cantidad * i.Costo);
        }


    }
}
