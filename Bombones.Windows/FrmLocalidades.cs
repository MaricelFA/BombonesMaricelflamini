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
    public partial class FrmLocalidades : Form
    {
        public FrmLocalidades()
        {
            InitializeComponent();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private IServiciosLocalidades _servicio;
        private List<Localidad> _lista;
        private void FrmLocalidades_Load(object sender, EventArgs e)
        {
            try
            {
                _servicio = new ServiciosLocalidades();
                _lista = _servicio.GetLista();
                MostrarEnGrilla();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
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

        private void SetearFila(Localidad localidad, DataGridViewRow r)
        {
            r.Cells[cmnProvincia.Index].Value = localidad.Provincia.NombreProvincia;
            r.Cells[CmnLocalidad.Index].Value = localidad.NombreLocalidad;
            r.Tag = localidad;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmLocalidadesAE frm = new FrmLocalidadesAE();
            frm.Text = "Agregar una Localidad";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Localidad localidad = frm.GetLocalidad();
                    _servicio.Guardar(localidad);
                    DataGridViewRow r = ConstruirFila();
                    SetearFila(localidad, r);
                    AgregarFila(r);
                    MessageBox.Show("Registro Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception exception)
                {

                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}