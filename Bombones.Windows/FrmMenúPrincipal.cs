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
    public partial class FrmMenúPrincipal : Form
    {
        public FrmMenúPrincipal()
        {
            InitializeComponent();
        }

        private void provinciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProvincias frm = new FrmProvincias();
            frm.MdiParent = this;
            frm.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void localidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLocalidades frm = new FrmLocalidades();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tiposDeChocolatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTiposDeChocolate frm = new FrmTiposDeChocolate();
            frm.MdiParent = this;
            frm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void rellenosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTipodeRelleno frm = new FrmTipodeRelleno();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tiposDeNuecesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTiposdeNuez frm = new FrmTiposdeNuez();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tsbProvincias_Click(object sender, EventArgs e)
        {
            FrmProvincias frm = new FrmProvincias();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tsbLocalidad_Click(object sender, EventArgs e)
        {
            FrmLocalidades frm = new FrmLocalidades();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tsbTipoChocolate_Click(object sender, EventArgs e)
        {
            FrmTiposDeChocolate frm = new FrmTiposDeChocolate();
            frm.MdiParent = this;
            frm.Show();

        }

        private void tsbTipoRelleno_Click(object sender, EventArgs e)
        {
            FrmTipodeRelleno frm = new FrmTipodeRelleno();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tsbTipoNuez_Click(object sender, EventArgs e)
        {
            FrmTiposdeNuez frm = new FrmTiposdeNuez();
            frm.MdiParent = this;
            frm.Show();
        }

        private void FrmMenúPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void TipodeDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTiposDeDocumentos frm = new FrmTiposDeDocumentos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientes frm = new FrmClientes();
            frm.MdiParent = this;
            frm.Show();

        }

        private void toolStripButtonClientes_Click(object sender, EventArgs e)
        {
            FrmClientes frm = new FrmClientes();
            frm.MdiParent = this;
            frm.Show();

        }

        private void toolStripButtonTiposDoc_Click(object sender, EventArgs e)
        {
            FrmTiposDeDocumentos frm = new FrmTiposDeDocumentos();
            frm.MdiParent = this;
            frm.Show();

        }

        private void toolStripButtonBombon_Click(object sender, EventArgs e)
        {
            FrmBombones frm = new FrmBombones();
            frm.MdiParent = this;
            frm.Show();
        }

        private void bombonesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBombones frm = new FrmBombones();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripButtonVentas_Click(object sender, EventArgs e)
        {
            FrmDetalleVentas frm = new FrmDetalleVentas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDetalleVentas frm = new FrmDetalleVentas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tiposDeDocumentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTiposDeDocumentos frm = new FrmTiposDeDocumentos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tiposDeChocolateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTiposDeChocolate frm = new FrmTiposDeChocolate();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tiposDeRellenosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTipodeRelleno frm = new FrmTipodeRelleno();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tiposDeNuecesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmTiposdeNuez frm = new FrmTiposdeNuez();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
