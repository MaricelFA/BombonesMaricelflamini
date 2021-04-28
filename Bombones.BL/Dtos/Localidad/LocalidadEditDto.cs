using Bombones.BL.Dtos.Provincia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.BL.Dtos.Localidad
{
    public class LocalidadEditDto
    {
        public int LocalidadId { get; set; }
        public string NombreLocalidad { get; set; }
        public int ProvinciaId { get; set; }
        public string NombreProvincia { get; set; }
        public ProvinciaListDto Provincia { get; set; }
    }
}
