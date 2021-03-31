using Bombones.BL;
using Bombones.Servicios.Servicios;
using Bombones.Servicios.Servicios.Facales;
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
    public partial class FrmLocalidadesAE : Form
    {
        public FrmLocalidadesAE()
        {
            InitializeComponent();
        }

        internal Localidad GetLocalidad()
        {
            return localidad;
        }

        private void FrmLocalidadesAE_Load(object sender, EventArgs e)
        {

        }
        private Localidad localidad;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarDatosComboProvincias(ref ProvinciasComboBox);
            if (localidad != null)
            {
                LocalidadTextBox.Text = localidad.NombreLocalidad;
                ProvinciasComboBox.SelectedValue = localidad.Provincia.ProvinciaId;
            }
        }

        private void CargarDatosComboProvincias(ref ComboBox provinciasComboBox )
        {
            IServiciosProvincias servicioProvincias = new Serviciosprovincias();
            List<Provincia> lista = servicioProvincias.GetLista();
            Provincia defaultProvincia = new Provincia
            {
                ProvinciaId = 0,
                NombreProvincia = "<Seleccionar Provincia>"
            };
            lista.Insert(0, defaultProvincia);
            provinciasComboBox.DisplayMember = "NombreProvincia";
            provinciasComboBox.ValueMember = "ProvinciaId";
            provinciasComboBox.DataSource = lista;
            provinciasComboBox.SelectedIndex = 0;
        }

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
                    localidad = new Localidad();
                }

                localidad.NombreLocalidad = LocalidadTextBox.Text;
                localidad.Provincia = ProvinciasComboBox.SelectedItem as Provincia;

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
    }
}
