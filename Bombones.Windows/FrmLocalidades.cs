using Bombones.BL;
using Bombones.BL.Dtos.Localidad;
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

        private IServiciosProvincias _serviciosProvincia;
        private IServiciosLocalidades _servicio;
        private List<LocalidadListDto> _lista;

        private void FrmLocalidades_Load(object sender, EventArgs e)
        {
            try
            {
                _servicio = new ServiciosLocalidades();
                _serviciosProvincia = new Serviciosprovincias();
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
            foreach (var localidadListDto in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, localidadListDto);
                AgregarFila(r);
            }
        }

        private void SetearFila(DataGridViewRow r, LocalidadListDto localidadListDto)
        {
            r.Cells[cmnProvincia.Index].Value = localidadListDto.NombreProvincia;
            r.Cells[CmnLocalidad.Index].Value = localidadListDto.NombreLocalidad;
            r.Tag = localidadListDto;
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

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmLocalidadesAE frm = new FrmLocalidadesAE();
            frm.Text = "Agregar Localidad";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    LocalidadEditDto localidadEditDto = frm.GetLocalidad();


                    if (!_servicio.Existe(localidadEditDto))
                    {
                        _servicio.Guardar(localidadEditDto);
                        LocalidadListDto localidadListDto = new LocalidadListDto();

                        localidadListDto.LocalidadId = localidadEditDto.LocalidadId;
                        localidadListDto.NombreLocalidad = localidadEditDto.NombreLocalidad;
                        localidadListDto.NombreProvincia = localidadEditDto.Provincia.NombreProvincia;

                        DataGridViewRow r = ConstruirFila();
                        SetearFila(r, localidadListDto);
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
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                LocalidadListDto localidadListDto = (LocalidadListDto)r.Tag;

                DialogResult dr = MessageBox.Show($"¿Desea dar de baja a la localidad {localidadListDto.NombreLocalidad}?",
                    "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    if (!_servicio.EstaRelacionado(localidadListDto))
                    {

                        _servicio.Borrar(localidadListDto.LocalidadId);
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
                LocalidadListDto localidadListDto = (LocalidadListDto)r.Tag;
                LocalidadListDto localidadlistdtoAux = (LocalidadListDto)localidadListDto.Clone();
                FrmLocalidadesAE frm = new FrmLocalidadesAE();
                LocalidadEditDto localidadEditDto = _servicio.GetLocalidadPorId(localidadListDto.LocalidadId);
                frm.Text = "Editar localidad";
                frm.SetLocalidad(localidadEditDto);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        localidadEditDto = frm.GetLocalidad();

                        if (!_servicio.Existe(localidadEditDto))
                        {
                            _servicio.Guardar(localidadEditDto);
                            localidadListDto.LocalidadId = localidadEditDto.LocalidadId;
                            localidadListDto.NombreLocalidad = localidadEditDto.NombreLocalidad;
                            localidadListDto.NombreProvincia = (_serviciosProvincia.GetProvinciaPorId(localidadEditDto.ProvinciaId)).NombreProvincia;
                            
                            SetearFila(r, localidadListDto);
                            MessageBox.Show("Registro Editado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Registro ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    catch (Exception exception)
                    {
                        SetearFila(r, localidadlistdtoAux);
                        MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}





   
    
