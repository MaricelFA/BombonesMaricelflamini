using Bombones.BL.Dtos.Cliente;
using Bombones.Servicios.Servicios;
using Bombones.Servicios.Servicios.Facales;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bombones.Windows
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private IServiciosClientes _servicio;
     
        private List<ClienteListDto> _lista;



        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            try
            {
                _servicio = new ServiciosClientes();
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
            foreach (var clienteListDto in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, clienteListDto);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, ClienteListDto clienteListDto)
        {

            r.Cells[cmnNombre.Index].Value = clienteListDto.Nombre;
            r.Cells[CmnApellido.Index].Value = clienteListDto.Apellido;
            r.Cells[CmnLocalidad.Index].Value = clienteListDto.NombreLocalidad;
            r.Cells[CmnProvincia.Index].Value = clienteListDto.NombreProvincia;
            r.Tag = clienteListDto;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmClientesAE frm = new FrmClientesAE();
            frm.Text = "Agregar Cliente";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    ClienteEditDto clienteEditDto = frm.GetCliente();


                    if (!_servicio.Existe(clienteEditDto))
                    {
                        _servicio.Guardar(clienteEditDto);
                        ClienteListDto cliente = new ClienteListDto
                        {
                            ClienteId = clienteEditDto.ClienteId,
                            Nombre = clienteEditDto.Nombre,
                            Apellido = clienteEditDto.Apellido,
                            NombreLocalidad = clienteEditDto.Localidad.NombreLocalidad,
                            NombreProvincia = clienteEditDto.Provincia.NombreProvincia,

                        };

                        DataGridViewRow r = ConstruirFila();
                        SetearFila(r, cliente);
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
                ClienteListDto cliente = (ClienteListDto)r.Tag;

                DialogResult dr = MessageBox.Show($"¿Desea dar de baja al cliente {cliente.Nombre} {cliente.Apellido}?",
                    "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    try
                    {

                        if (!_servicio.EstaRelacionado(cliente))
                        {
                            _servicio.Borrar(cliente.ClienteId);
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
                ClienteListDto cliente = (ClienteListDto)r.Tag;
                ClienteListDto clienteList = (ClienteListDto)cliente.Clone();
                FrmClientesAE frm = new FrmClientesAE();
                ClienteEditDto clienteEdit = _servicio.GetClientePorId(cliente.ClienteId);
                frm.Text = "Editar cliente";
                frm.SetCliente(clienteEdit);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        clienteEdit = frm.GetCliente();

                        if (!_servicio.Existe(clienteEdit))
                        {
                            _servicio.Guardar(clienteEdit);
                            cliente.ClienteId = clienteEdit.ClienteId;
                            cliente.Apellido = clienteEdit.Apellido;
                            cliente.Nombre = clienteEdit.Nombre;
                            cliente.NombreLocalidad = clienteEdit.Localidad.NombreLocalidad;
                            cliente.NombreProvincia = clienteEdit.Provincia.NombreProvincia;

                            SetearFila(r, cliente);
                            MessageBox.Show("Registro Editado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Registro ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    catch (Exception exception)
                    {
                        SetearFila(r, clienteList);
                        MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}