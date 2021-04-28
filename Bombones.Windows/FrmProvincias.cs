using Bombones.BL;
using Bombones.BL.Dtos.Provincia;
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
        private List<ProvinciaListDto> _lista;
 

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

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmProvinciasAE frm = new FrmProvinciasAE();
            frm.Text = "Agregar una Provincia";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    ProvinciaEditDto provinciaEditDto = frm.GetProvincia();
                    

                    if (!_servicio.Existe(provinciaEditDto))
                    {
                        _servicio.Guardar(provinciaEditDto);
                        DataGridViewRow r = ConstruirFila();
                        ProvinciaListDto provincia = new ProvinciaListDto
                        {
                            ProvinciaId = provinciaEditDto.ProvinciaId,
                            NombreProvincia = provinciaEditDto.NombreProvincia
                        };
                        SetearFila(provincia, r);
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

        private void SetearFila(ProvinciaListDto provincia, DataGridViewRow r)
        {
            r.Cells[cmnProvincia.Index].Value = provincia.NombreProvincia;
            r.Tag = provincia;
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                ProvinciaListDto provincia = (ProvinciaListDto)r.Tag;
                ProvinciaListDto provinciaAux = (ProvinciaListDto)provincia.Clone();
                ProvinciaEditDto provinciaEditDto = new ProvinciaEditDto
                {
                    ProvinciaId = provincia.ProvinciaId,
                    NombreProvincia = provincia.NombreProvincia
                };
                FrmProvinciasAE frm = new FrmProvinciasAE();
                frm.Text = "Editar Provincia";
                frm.SetProvincia(provinciaEditDto);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        provinciaEditDto = frm.GetProvincia();

                        if (!_servicio.Existe(provinciaEditDto))
                        {
                            _servicio.Guardar(provinciaEditDto);
                            provincia.NombreProvincia = provinciaEditDto.NombreProvincia;
                            SetearFila(provincia, r);
                            MessageBox.Show("Registro Editado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Registro ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    catch (Exception exception)
                    {
                        SetearFila(provinciaAux, r);
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
                ProvinciaListDto provincia = (ProvinciaListDto)r.Tag;

                DialogResult dr = MessageBox.Show($"¿Desea dar de baja a la provincia {provincia.NombreProvincia}?",
                    "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    try
                    {

                        if (!_servicio.EstaRelacionado(provincia))
                        {
                            _servicio.Borrar(provincia.ProvinciaId);
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
    }
    
}
