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
    }
}
