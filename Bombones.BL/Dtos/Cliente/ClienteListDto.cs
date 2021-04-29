using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.BL.Dtos.Cliente
{
    public class ClienteListDto : ICloneable
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        private string nombreCompleto;
        public string NombreCompleto
        {
            get { return Nombre + "" + Apellido; }
            set { nombreCompleto = value; }
        }
            


        public string NombreLocalidad { get; set; }
        public string NombreProvincia { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

}
