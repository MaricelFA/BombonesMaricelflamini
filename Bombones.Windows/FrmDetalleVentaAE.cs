using Bombones.BL.Dtos.DetalleVenta;
using Bombones.BL.Dtos.Venta;
using Bombones.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bombones.Windows
{
    public partial class FrmDetalleVentaAE : Form
    {

        private VentaEditDto ventaEdit;
        private DetalleVentaEditDto DetalleVentaEdit;


        //protected override void OnLoad(EventArgs e)
        //{
        //    base.OnLoad(e);
        //    Helper.CargarDatosComboClientes(ref cboCliente);

        //    Helper.CargarDatosComboBombones(ref cbBombon);
            //if (DetalleVentaEdit != null)
            //{
            //    txtNombre.Text = cliente.Nombre;
            //    txtApellido.Text = cliente.Apellido;
            //    txtDNI.Text = cliente.NroDocumento;
            //    txtDomicilio.Text = cliente.Direccion;
            //    txtEmail.Text = cliente.CorreoElectronico;
            //    cboProvincia.SelectedValue = cliente.Provincia;

            //    cboLocalidad.SelectedValue = cliente.Localidad;

            //    comboBoxTipoDeDni.SelectedValue = cliente.documento;
            //    txtTelefonoFijo.Text = cliente.TelefonoFijo;
            //    txtTelefonoMovil.Text = cliente.TelefonoMovil;


            //}


        public FrmDetalleVentaAE()
        {
            InitializeComponent();
        }

        internal DetalleVentaEditDto GetDetalleVenta()
        {
            throw new NotImplementedException();
        }

        internal VentaEditDto GetVenta()
        {
            throw new NotImplementedException();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
