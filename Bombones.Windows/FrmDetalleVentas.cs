using Bombones.BL.Dtos.DetalleVenta;
using Bombones.BL.Dtos.Venta;
using Bombones.Servicios.Servicios;
using Bombones.Servicios.Servicios.Facales;
using Bombones.Windows.Helpers;
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
    public partial class FrmDetalleVentas : Form
    {
        public FrmDetalleVentas()
        {
            InitializeComponent();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private IServiciosDetalleVentas _servicioDetalle;
        private IServiciosventas _serviciosVentas;
        //private ServiciosDetalleVentas ServiciosDetalle;
        private ServiciosVentas ServiciosVentas;
        
       

        private List<DetalleVentaListDto> _listadetalle;
        private List<VentaListDto> _listaventa;
        

        private void FrmDetalleVentas_Load(object sender, EventArgs e)
        {
            try
            {
                ServiciosVentas = new ServiciosVentas();
                _listaventa = ServiciosVentas.GetLista();
                MostrarEnGrilla();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

     

        //private void MostrarEnGrilla2()
        //{
        //    dgvDatos.Rows.Clear();
        //    foreach (var ventaListDto in _listaventa)
        //    {
        //        DataGridViewRow r = ConstruirFila();
        //        SetearFila2(r, ventaListDto);
        //        AgregarFila(r);
        //    }
        //}
        private void SetearFila(DataGridViewRow r, VentaListDto ventaListDto)
        {
            r.Cells[cmnVenta.Index].Value = ventaListDto.VentaId;
            r.Cells[CmnTotal.Index].Value = ventaListDto.TotalVenta.ToString("C");
            r.Cells[cmnClienteApellido.Index].Value = ventaListDto.Apellido;
            r.Cells[CmnCliente.Index].Value = ventaListDto.Nombre;
            r.Cells[CmnFecha.Index].Value = ventaListDto.Fecha;
            r.Tag = ventaListDto;
        }
        private void MostrarEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var ventaListDto in _listaventa)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, ventaListDto);
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

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmDetalleVentaAE frm = new FrmDetalleVentaAE();
            frm.Text = "Nueva Venta";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    var ventaDto = frm.GetVenta();
                    _serviciosVentas.Guardar(ventaDto);
                    var ventaListDto = new VentaListDto
                    {
                        VentaId = ventaDto.VentaId,
                        Nombre = ventaDto.cliente.Nombre,
                        Fecha = ventaDto.Fecha,
                        ItemsVenta = Helper.ConstruirListaItemsListDto(ventaDto.DetalleVentas)

                    };
                    var r = ConstruirFila();
                    SetearFila(r, ventaListDto);
                    AgregarFila(r);
                    MessageBox.Show("Venta agregada", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }








        }

        

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                VentaListDto venta = (VentaListDto)r.Tag;

                DialogResult dr = MessageBox.Show($"¿Desea dar de baja a la venta número: {venta.VentaId}?",
                    "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    
                   
                        _serviciosVentas.Borrar(venta.VentaId);
                        dgvDatos.Rows.Remove(r);
                        MessageBox.Show("Registro Borrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   

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
                VentaListDto ventaListDto = (VentaListDto)r.Tag;
                FrmDetalleVentaAE frm = new FrmDetalleVentaAE();
                VentaEditDto ventaEdit = _serviciosVentas.GetVentaPorId(ventaListDto.VentaId);
                frm.Text = "Editar Venta";
                frm.SetVenta(ventaEdit);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        ventaEdit = frm.GetVenta();

                       
                        
                            _serviciosVentas.Guardar(ventaEdit);
                            ventaListDto.VentaId = ventaEdit.VentaId;
                            ventaListDto.Nombre = ventaEdit.cliente.Nombre;
                            ventaListDto.Apellido = ventaEdit.cliente.Apellido;
                            ventaListDto.Fecha = ventaEdit.Fecha;
                            
                           

                            SetearFila(r, ventaListDto);
                            MessageBox.Show("Registro Editado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                       
                    }
                    catch (Exception exception)
                    {
                        SetearFila(r, ventaListDto);
                        MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
