using Bombones.BL;
using Bombones.Servicios.Servicios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bombones.Windows
{
    public partial class FrmProvincias : Form
    {
        public FrmProvincias()
        {
            InitializeComponent();
        }
        private Serviciosprovincias _servicio;
        private List<Provincia> _lista;
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
       

        private void MostrarEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var provincia in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(provincia, r);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(Provincia provincia, DataGridViewRow r)
        {
            r.Cells[cmnProvincia.Index].Value = provincia.NombreProvincia;
            r.Tag = provincia;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void FrmProvincias_Load_1(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            try
            {
                _servicio = new Serviciosprovincias();
                _lista = _servicio.GetLista();
                MostrarEnGrilla();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }
    }
}
