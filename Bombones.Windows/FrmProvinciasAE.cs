using Bombones.BL;
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
    public partial class FrmProvinciasAE : Form
    {
        public FrmProvinciasAE()
        {
            InitializeComponent();
        }
        private Provincia provincia;
        internal Provincia GetProvincia()
        {
            return provincia;
        }

        internal void SetProvincia(Provincia provincia)
        {
            this.provincia = provincia;
        }

        private void FrmProvinciasAE_Load(object sender, EventArgs e)
        {

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (provincia != null)
            {
                ProvinciaTextBox.Text = provincia.NombreProvincia;
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (provincia == null)
                {
                    provincia = new Provincia();
                }

                provincia.NombreProvincia = ProvinciaTextBox.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(ProvinciaTextBox.Text) || string.IsNullOrWhiteSpace(ProvinciaTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(ProvinciaTextBox, "El nombre de la provincia es requerido");
            }

            return valido;
        }
    }
}
