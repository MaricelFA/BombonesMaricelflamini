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
    public partial class FrmTiposDeDocumentosAE : Form
    {
        public FrmTiposDeDocumentosAE()
        {
            InitializeComponent();
        }

        private TipoDeDocumento documento;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (documento != null)
            {
                TipoDocTextBox.Text = documento.Descripcion;
            }
        }

        internal TipoDeDocumento GetTipoDeDocumento()
        {
            return documento;
        }

        internal void SetTipoDeDocumento(TipoDeDocumento documento)
        {
            this.documento = documento;
        }

        private void FrmTiposDeDocumentosAE_Load(object sender, EventArgs e)
        {

        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (documento == null)
                {
                    documento = new TipoDeDocumento();
                }

                documento.Descripcion = TipoDocTextBox.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(TipoDocTextBox.Text) )
            {
                valido = false;
                errorProvider1.SetError(TipoDocTextBox, "El nombre de el tipo de documento es requerido");
            }

            return valido;
        }
    }
}
