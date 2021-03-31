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
    public partial class FrmTipodeRellenoAE : Form
    {
        public FrmTipodeRellenoAE()
        {
            InitializeComponent();
        }
        private TipodeRelleno TipodeRelleno;

        internal TipodeRelleno GetTipoRelleno()
        {
            return TipodeRelleno;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (TipodeRelleno != null)
            {
                TipodeRellenoTextBox.Text = TipodeRelleno.NombreTipoRelleno;
            }
        }

        internal void SetTipoRelleno(TipodeRelleno tipodeRelleno)
        {
            this.TipodeRelleno = tipodeRelleno;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (TipodeRelleno == null)
                {
                    TipodeRelleno = new TipodeRelleno();
                }

                TipodeRelleno.NombreTipoRelleno = TipodeRellenoTextBox.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(TipodeRellenoTextBox.Text) || string.IsNullOrWhiteSpace(TipodeRellenoTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(TipodeRellenoTextBox, "El nombre de el tipo de relleno es requerido");
            }

            return valido;
        }

        private void FrmTipodeRellenoAE_Load(object sender, EventArgs e)
        {

        }

        
    }
}
