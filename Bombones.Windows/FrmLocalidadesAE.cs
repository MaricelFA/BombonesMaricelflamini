using Bombones.BL;
using Bombones.BL.Dtos.Localidad;
using Bombones.BL.Dtos.Provincia;
using Bombones.Servicios.Servicios;
using Bombones.Servicios.Servicios.Facales;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Bombones.Windows.Helpers;

namespace Bombones.Windows
{
    public partial class FrmLocalidadesAE : Form
    {
        public FrmLocalidadesAE()
        {
            InitializeComponent();
        }



        private void FrmLocalidadesAE_Load(object sender, EventArgs e)
        {

        }
     
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.CargarDatosComboProvincias(ref ProvinciasComboBox);
          
            if (localidad != null)
            {
                LocalidadTextBox.Text = localidad.NombreLocalidad;
                ProvinciasComboBox.SelectedValue = localidad.ProvinciaId;
            }
        }
       


        private LocalidadEditDto localidad;

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (localidad == null)
                {
                    localidad = new LocalidadEditDto();
                }

                localidad.NombreLocalidad = LocalidadTextBox.Text;
                localidad.Provincia = (ProvinciaListDto)ProvinciasComboBox.SelectedItem;

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(LocalidadTextBox.Text) || string.IsNullOrWhiteSpace(LocalidadTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(LocalidadTextBox, "Nombre de Localidad requerido");
            }

            if (ProvinciasComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(ProvinciasComboBox, "Debe seleccionar una provincia");
            }

            return valido;
        }

        internal LocalidadEditDto GetLocalidad()
        {
            return localidad;
        }

        internal void SetLocalidad(LocalidadEditDto localidad)
        {
            this.localidad = localidad;
        }
    }
}
