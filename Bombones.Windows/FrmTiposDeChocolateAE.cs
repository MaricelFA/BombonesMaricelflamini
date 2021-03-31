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
    public partial class FrmTiposDeChocolateAE : Form
    {
        public FrmTiposDeChocolateAE()
        {
            InitializeComponent();
        }
        private TipoChocolate TipoChocolate;



        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (TipoChocolate != null)
            {
                TipoChocolateTextBox.Text = TipoChocolate.NombreTipoChocolate;
            }
        }
        internal TipoChocolate GetTipoChocolate()
        {
            return TipoChocolate;
        }

        internal void SetTipoChocolate(TipoChocolate tipoChocolate)
        {
            this.TipoChocolate = tipoChocolate;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (TipoChocolate == null)
                {
                    TipoChocolate = new TipoChocolate();
                }

                TipoChocolate.NombreTipoChocolate = TipoChocolateTextBox.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(TipoChocolateTextBox.Text) || string.IsNullOrWhiteSpace(TipoChocolateTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(TipoChocolateTextBox, "El nombre de el tipo de chocolate es requerido");
            }

            return valido;
        }

    }
}
