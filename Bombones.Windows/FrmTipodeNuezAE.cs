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
    public partial class FrmTipodeNuezAE : Form
    {
        public FrmTipodeNuezAE()
        {
            InitializeComponent();
        }
        private TipodeNuez TipodeNuez;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (TipodeNuez != null)
            {
                TipoNuezTextBox.Text = TipodeNuez.NombreTipoDeNuez;
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        internal TipodeNuez GetTipoNuez()
        {
            return TipodeNuez;
        }

        internal void SetTipoNuez(TipodeNuez tipodeNuez)
        {
            this.TipodeNuez = tipodeNuez;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (TipodeNuez == null)
                {
                    TipodeNuez = new TipodeNuez();
                }

                TipodeNuez.NombreTipoDeNuez = TipoNuezTextBox.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(TipoNuezTextBox.Text) || string.IsNullOrWhiteSpace(TipoNuezTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(TipoNuezTextBox, "El nombre de el tipo de nuez es requerido");
            }

            return valido;
        }
    }
}
