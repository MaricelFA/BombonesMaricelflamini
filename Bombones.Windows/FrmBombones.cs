using Bombones.BL.Dtos.Bombon;
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
    public partial class FrmBombones : Form
    {
        public FrmBombones()
        {
            InitializeComponent();
        }

        private IServiciosBombones _servicio;

        private List<BombonListDto> _lista;

        private void FrmBombones_Load(object sender, EventArgs e)
        {
            try
            {
                _servicio = new ServiciosBombones();
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
            foreach (var bombonListDto in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, bombonListDto);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, BombonListDto bombonListDto)
        {
            r.Cells[cmnBombon.Index].Value = bombonListDto.NombreBombon;
            r.Cells[CmnTipoChocolate.Index].Value = bombonListDto.NombreTipoChocolate;
            r.Cells[CmnTipoNuez.Index].Value = bombonListDto.NombreTipoDeNuez;
            r.Cells[CmnTipoRelleno.Index].Value = bombonListDto.NombreTipoRelleno;
            r.Cells[CmnPrecioUnidad.Index].Value = bombonListDto.Costo;
            r.Cells[CmnStock.Index].Value = bombonListDto.CantidadEnExistencia;
            r.Tag = bombonListDto;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmBombonesAE frm = new FrmBombonesAE();
            frm.Text = "Agregar Nuevo Bombón";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    BombonEditDto bombonEditDto = frm.GetBombon();


                    if (!_servicio.Existe(bombonEditDto))
                    {
                        _servicio.Guardar(bombonEditDto);
                        BombonListDto bombonList = new BombonListDto
                        {
                            BombonId = bombonEditDto.BombonId,
                            NombreBombon = bombonEditDto.NombreBombon,
                            NombreTipoChocolate = bombonEditDto.tipoChocolate.NombreTipoChocolate,
                            NombreTipoDeNuez = bombonEditDto.tipodeNuez.NombreTipoDeNuez,
                            NombreTipoRelleno = bombonEditDto.tipodeRelleno.NombreTipoRelleno,
                            Costo = bombonEditDto.Costo,
                            CantidadEnExistencia = bombonEditDto.CantidadEnExistencia,

                        };

                        DataGridViewRow r = ConstruirFila();
                        SetearFila(r, bombonList);
                        AgregarFila(r);
                        MessageBox.Show("Registro agregado con exito", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    else
                    {
                        MessageBox.Show("Registro duplicado... Alta denegada", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            try
            {
                _servicio = new ServiciosBombones();
                _lista = _servicio.GetLista();
                MostrarEnGrilla();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                BombonListDto bombonList = (BombonListDto)r.Tag;

                DialogResult dr = MessageBox.Show($"¿Desea dar de baja al bombón {bombonList.NombreBombon}?",
                    "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    if (!_servicio.EstaRelacionado(bombonList))
                    {
                        _servicio.Borrar(bombonList.BombonId);
                        dgvDatos.Rows.Remove(r);
                        MessageBox.Show("Registro Borrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Registro relacionado, baja denegada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Acción cancelada");
                }
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                BombonListDto bombonListDto = (BombonListDto)r.Tag;
                BombonListDto bombon = (BombonListDto)bombonListDto.Clone();
                FrmBombonesAE frm = new FrmBombonesAE();
                BombonEditDto bombonEdit = _servicio.GetBombonPorId(bombonListDto.BombonId);
                frm.Text = "Editar Bombón";
                frm.SetBombon(bombonEdit);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        bombonEdit = frm.GetBombon();

                        if (!_servicio.Existe(bombonEdit))
                        {
                            _servicio.Guardar(bombonEdit);
                            bombonListDto.BombonId = bombonEdit.BombonId;
                            bombonListDto.NombreBombon = bombonEdit.NombreBombon;
                            bombonListDto.NombreTipoChocolate = bombonEdit.tipoChocolate.NombreTipoChocolate;
                            bombonListDto.NombreTipoDeNuez = bombonEdit.tipodeNuez.NombreTipoDeNuez;
                            bombonListDto.NombreTipoRelleno = bombonEdit.tipodeRelleno.NombreTipoRelleno;
                            bombonListDto.Costo = bombonEdit.Costo;
                            bombonListDto.CantidadEnExistencia = bombonEdit.CantidadEnExistencia;

                            SetearFila(r, bombonListDto);
                            MessageBox.Show("Registro Editado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Registro ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    catch (Exception exception)
                    {
                        SetearFila(r, bombon);
                        MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();

        }
    }
}