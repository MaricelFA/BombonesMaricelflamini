using Bombones.BL.Dtos.Localidad;
using Bombones.BL.Dtos.Provincia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.BL.Dtos.Cliente
{
    public class ClienteEditDto
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public TipoDeDocumento documento { get; set; }
        public string NroDocumento { get; set; }
        public string Direccion { get; set; }
        public LocalidadListDto Localidad { get; set; }
        public ProvinciaListDto Provincia { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
    }
}
