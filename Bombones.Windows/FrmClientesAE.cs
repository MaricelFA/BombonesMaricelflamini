using Bombones.BL;
using Bombones.BL.Dtos.Cliente;
using Bombones.BL.Dtos.Localidad;
using Bombones.BL.Dtos.Provincia;
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
    public partial class FrmClientesAE : Form
    {
        public FrmClientesAE()
        {
            InitializeComponent();
        }

        internal ClienteEditDto GetCliente()
        {
            return cliente;
        }

        internal void SetCliente(ClienteEditDto clienteEdit)
        {
            this.cliente = clienteEdit;
        }

        private void FrmClientesAE_Load(object sender, EventArgs e)
        {

        }
        private ClienteEditDto cliente;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.CargarDatosComboProvincias(ref cboProvincia);
            
            Helper.CargarDatosComboTipoDni(ref comboBoxTipoDeDni);
            if (cliente != null)
            {
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtDNI.Text = cliente.NroDocumento;
                txtDomicilio.Text = cliente.Direccion;
                txtEmail.Text = cliente.CorreoElectronico;
                cboProvincia.SelectedValue = cliente.Provincia.ProvinciaId;
                Helper.CargarDatosComboLocalidad(ref cboLocalidad, cliente.Provincia);
                cboLocalidad.SelectedValue = cliente.Localidad;
                
                comboBoxTipoDeDni.SelectedValue = cliente.documento;
                txtTelefonoFijo.Text = cliente.TelefonoFijo;
                txtTelefonoMovil.Text = cliente.TelefonoMovil;


            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (cliente == null)
                {
                    cliente = new ClienteEditDto();
                }

                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.NroDocumento = txtDNI.Text;
                cliente.Direccion = txtDomicilio.Text;
                cliente.CorreoElectronico = txtEmail.Text;
                cliente.Provincia = (ProvinciaListDto)cboProvincia.SelectedItem;

                cliente.Localidad = (LocalidadListDto)cboLocalidad.SelectedItem;
               
                cliente.documento = (TipoDeDocumento)comboBoxTipoDeDni.SelectedItem;
                cliente.TelefonoFijo = txtTelefonoFijo.Text;
                cliente.TelefonoMovil = txtTelefonoMovil.Text;
                cliente.FechaDeNacimiento = txtFechaNacimiento.Value;

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNombre, "Nombre requerido");
            }
            if (string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                valido = false;
                errorProvider1.SetError(txtApellido, "Nombre requerido");

            }
            if (cboProvincia.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboProvincia, "Debe seleccionar una provincia");
            }
            if (cboLocalidad.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboLocalidad, "Debe seleccionar una localidad");
            }
            if (comboBoxTipoDeDni.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(comboBoxTipoDeDni, "Debe seleccionar un tipo de documento");
            }
            if (string.IsNullOrEmpty(txtDNI.Text) || string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                valido = false;
                errorProvider1.SetError(txtDNI, "Campo requerido");
            }
            if (string.IsNullOrEmpty(txtDomicilio.Text) || string.IsNullOrWhiteSpace(txtDomicilio.Text))
            {
                valido = false;
                errorProvider1.SetError(txtDNI, "Campo requerido");
            }

            return valido;
        }

        private void cboLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvincia.SelectedIndex != 0)
            {

                ProvinciaListDto provincia = (ProvinciaListDto)cboProvincia.SelectedItem;
                Helper.CargarDatosComboLocalidad(ref cboLocalidad, provincia );
            }
            else
            {
                cboLocalidad.DataSource = null;
            }
        }
    }
}