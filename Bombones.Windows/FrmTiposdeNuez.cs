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
    public partial class FrmTiposdeNuez : Form
    {
        public FrmTiposdeNuez()
        {
            InitializeComponent();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }


        private IServiciosTipodeNuez _servicio;
        private List<TipodeNuez> _lista;

        private void MostrarEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var tipodeNuez in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(tipodeNuez, r);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(TipodeNuez tipodeNuez, DataGridViewRow r)
        {
            r.Cells[cmnTipoDeNuez.Index].Value = tipodeNuez.NombreTipoDeNuez;
            r.Tag = tipodeNuez;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmTipodeNuezAE frm = new FrmTipodeNuezAE();
            frm.Text = "Agregar un Tipo de Nuez";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    TipodeNuez tipodeNuez = frm.GetTipoNuez();


                    if (!_servicio.Existe(tipodeNuez))
                    {
                        _servicio.Guardar(tipodeNuez);
                        DataGridViewRow r = ConstruirFila();
                        SetearFila(tipodeNuez, r);
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
                TipodeNuez tipodeNuez = (TipodeNuez)r.Tag;
                TipodeNuez tipoNuezAux = (TipodeNuez)tipodeNuez.Clone();
                FrmTipodeNuezAE frm = new FrmTipodeNuezAE();
                frm.Text = "Editar Tipo DE Nuez";
                frm.SetTipoNuez(tipodeNuez);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        tipodeNuez = frm.GetTipoNuez();

                        if (!_servicio.Existe(tipodeNuez))
                        {
                            _servicio.Guardar(tipodeNuez);
                            SetearFila(tipodeNuez, r);
                            MessageBox.Show("Registro Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Registro ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    catch (Exception exception)
                    {
                        SetearFila(tipoNuezAux, r);
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
                TipodeNuez tipodeNuez = (TipodeNuez)r.Tag;

                DialogResult dr = MessageBox.Show($"¿Desea dar de baja al tipo de Nuez {tipodeNuez.NombreTipoDeNuez}  ?",
                    "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    try
                    {

                        if (!_servicio.EstaRelacionado(tipodeNuez))
                        {
                            _servicio.Borrar(tipodeNuez.TipoDeNuezId);
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

        private void FrmTiposdeNuez_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            try
            {
                _servicio = new ServiciosTipodeNuez();
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
