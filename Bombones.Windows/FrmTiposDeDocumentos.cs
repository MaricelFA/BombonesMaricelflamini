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
    public partial class FrmTiposDeDocumentos : Form
    {
        public FrmTiposDeDocumentos()
        {
            InitializeComponent();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private IServiciosTiposDedocumentos _servicio;
        private List<TipoDeDocumento> _lista;

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmTiposDeDocumentosAE frm = new FrmTiposDeDocumentosAE();
            frm.Text = "Agregar un Tipo de Documento";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    TipoDeDocumento documento = frm.GetTipoDeDocumento();


                    if (!_servicio.Existe(documento))
                    {
                        _servicio.Guardar(documento);
                        DataGridViewRow r = ConstruirFila();
                        SetearFila(documento, r);
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

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(TipoDeDocumento documento, DataGridViewRow r)
        {
            r.Cells[cmnTiposDeDocumentos.Index].Value = documento.Descripcion;
            r.Tag = documento;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                TipoDeDocumento documento = (TipoDeDocumento)r.Tag;
                TipoDeDocumento documento1 = (TipoDeDocumento)documento.Clone();
                FrmTiposDeDocumentosAE frm = new FrmTiposDeDocumentosAE();
                frm.Text = "Editar Tipo DE Documento";
                frm.SetTipoDeDocumento(documento);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        documento = frm.GetTipoDeDocumento();

                        if (!_servicio.Existe(documento))
                        {
                            _servicio.Editar(documento);
                            SetearFila(documento, r);
                            MessageBox.Show("Registro Editado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Registro ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    catch (Exception exception)
                    {
                        SetearFila(documento1, r);
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
                TipoDeDocumento documento = (TipoDeDocumento)r.Tag;

                DialogResult dr = MessageBox.Show($"¿Desea dar de baja al tipo de Documento {documento.Descripcion}  ?",
                    "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    try
                    {

                        if (!_servicio.EstaRelacionado(documento))
                        {
                            _servicio.Borrar(documento);
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
        }

        private void FrmTiposDeDocumentos_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            _servicio = new ServiciosTiposDeDocumentos();
            try
            {
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
            foreach (var documento in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(documento, r);
                AgregarFila(r);
            }
        }
    }
}
