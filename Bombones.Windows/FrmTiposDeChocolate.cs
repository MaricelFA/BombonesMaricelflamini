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
    public partial class FrmTiposDeChocolate : Form
    {
        public FrmTiposDeChocolate()
        {
            InitializeComponent();
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private IServiciosTiposDeChocolate _servicio;
        private List<TipoChocolate> _lista;
        private void FrmTiposDeChocolateAE_load(object sender, EventArgs e)
        {

        }

        private void MostrarEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var tipoChocolate in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(tipoChocolate, r);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(TipoChocolate tipoChocolate, DataGridViewRow r)
        {
            r.Cells[cmnTipoDeChocolate.Index].Value = tipoChocolate.NombreTipoChocolate;
            r.Tag = tipoChocolate;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmTiposDeChocolateAE frm = new FrmTiposDeChocolateAE();
            frm.Text = "Agregar un Tipo de Chocolate";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    TipoChocolate tipoChocolate = frm.GetTipoChocolate();


                    if (!_servicio.Existe(tipoChocolate))
                    {
                        _servicio.Guardar(tipoChocolate);
                        DataGridViewRow r = ConstruirFila();
                        SetearFila(tipoChocolate, r);
                        AgregarFila(r);
                        MessageBox.Show("Registro Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Registro ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                catch (Exception exception)
                {

                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                TipoChocolate tipoChocolate = (TipoChocolate)r.Tag;
                TipoChocolate tipoChocolateAux = (TipoChocolate)tipoChocolate.Clone();
                FrmTiposDeChocolateAE frm = new FrmTiposDeChocolateAE();
                frm.Text = "Editar Tipo DE Chocolate";
                frm.SetTipoChocolate(tipoChocolate);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        tipoChocolate = frm.GetTipoChocolate();

                        if (!_servicio.Existe(tipoChocolate))
                        {
                            _servicio.Guardar(tipoChocolate);
                            SetearFila(tipoChocolate, r);
                            MessageBox.Show("Registro Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Registro ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    catch (Exception exception)
                    {
                        SetearFila(tipoChocolateAux, r);
                        MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                TipoChocolate tipoChocolate = (TipoChocolate)r.Tag;

                DialogResult dr = MessageBox.Show($"¿Desea dar de baja al tipo de Chocolate {tipoChocolate.NombreTipoChocolate}  ?",
                    "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    try
                    {

                        if (!_servicio.EstaRelacionado(tipoChocolate))
                        {
                            _servicio.Borrar(tipoChocolate.TipoChocolateId);
                            dgvDatos.Rows.Remove(r);
                            MessageBox.Show("Registro Borrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Registro relacionado... Baja denegada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                  


                }

            }
            else
            {
                MessageBox.Show("Acción cancelada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FrmTiposDeChocolate_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            try
            {
                _servicio = new ServiciosTiposDeChocolate();
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
