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
    public partial class FrmTipodeRelleno : Form
    {
        public FrmTipodeRelleno()
        {
            InitializeComponent();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private IServiciosTipodeRelleno _servicio;
        private List<TipodeRelleno> _lista;

        private void MostrarEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var tipodeRelleno in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(tipodeRelleno, r);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(TipodeRelleno tipodeRelleno, DataGridViewRow r)
        {
            r.Cells[cmnTipoDeRelleno.Index].Value = tipodeRelleno.NombreTipoRelleno;
            r.Tag = tipodeRelleno;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmTipodeRellenoAE frm = new FrmTipodeRellenoAE();
            frm.Text = "Agregar un Tipo de Relleno";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    TipodeRelleno tipodeRelleno = frm.GetTipoRelleno();


                    if (!_servicio.Existe(tipodeRelleno))
                    {
                        _servicio.Guardar(tipodeRelleno);
                        DataGridViewRow r = ConstruirFila();
                        SetearFila(tipodeRelleno, r);
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
                TipodeRelleno tipodeRelleno = (TipodeRelleno)r.Tag;
                TipodeRelleno tipoRellenoAux = (TipodeRelleno)tipodeRelleno.Clone();
                FrmTipodeRellenoAE frm = new FrmTipodeRellenoAE();
                frm.Text = "Editar Tipo DE Relleno";
                frm.SetTipoRelleno(tipodeRelleno);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        tipodeRelleno = frm.GetTipoRelleno();

                        if (!_servicio.Existe(tipodeRelleno))
                        {
                            _servicio.Guardar(tipodeRelleno);
                            SetearFila(tipodeRelleno, r);
                            MessageBox.Show("Registro Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Registro ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    catch (Exception exception)
                    {
                        SetearFila(tipoRellenoAux, r);
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
                TipodeRelleno tipodeRelleno = (TipodeRelleno)r.Tag;

                DialogResult dr = MessageBox.Show($"¿Desea dar de baja al tipo de Relleno {tipodeRelleno.NombreTipoRelleno}  ?",
                    "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    try
                    {

                        if (!_servicio.EstaRelacionado(tipodeRelleno))
                        {
                            _servicio.Borrar(tipodeRelleno.TipoRellenoId);
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

        private void FrmTipodeRelleno_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            try
            {
                _servicio = new ServiciosTipodeRelleno();
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