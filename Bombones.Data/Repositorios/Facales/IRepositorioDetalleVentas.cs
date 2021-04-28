using Bombones.BL;
using Bombones.BL.Dtos.DetalleVenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Data.Repositorios.Facales
{
    public interface IRepositorioDetalleVentas
    {
        List<DetalleVentaListDto> GetLista();
        void Guardar(DetalleVenta detalleVenta);
        bool Existe(DetalleVenta detalleVenta);
        void Borrar(int DetalleVentaId);
        DetalleVentaEditDto GetDetalleVentaPorId(int detalleVentaId);
        bool EstaRelacionado(DetalleVentaListDto detalleVentaListDto);
    }
}
