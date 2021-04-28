using Bombones.BL.Dtos.DetalleVenta;
using Bombones.BL.Dtos.Venta;
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
        private ServiciosDetalleVentas ServiciosDetalle;
        private ServiciosVentas ServiciosVentas;

        private List<DetalleVentaListDto> _listadetalle;
        

        private void FrmDetalleVentas_Load(object sender, EventArgs e)
        {
            try
            {
                 
                _listadetalle = _servicioDetalle.GetLista();
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
            foreach (var detallelistDto in _listadetalle)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, detallelistDto);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, DetalleVentaListDto detallelistDto)
        {
            r.Cells[cmnVenta.Index].Value = detallelistDto.VentaId;
            r.Cells[cmnClienteApellido.Index].Value = detallelistDto.Apellido;
            r.Cells[CmnCliente.Index].Value = detallelistDto.Nombre;
            r.Cells[CmnFecha.Index].Value = detallelistDto.Fecha;
            r.Cells[CmnTotal.Index].Value = detallelistDto.Total;
            r.Tag = detallelistDto;
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
            frm.Text = "Agregar Venta";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    DetalleVentaEditDto detalleVentaEdit = frm.GetDetalleVenta();

                    _servicioDetalle.Guardar(detalleVentaEdit);

                    DetalleVentaListDto detalleVenta = new DetalleVentaListDto
                    {
                        DetalleVentaId = detalleVentaEdit.DetalleVentaId,
                        VentaId = detalleVentaEdit.venta.VentaId,
                        
                        NombreBombon = detalleVentaEdit.bombon.NombreBombon,
                        Precio = detalleVentaEdit.Precio,
                        Cantidad = detalleVentaEdit.Cantidad,

                        
                    };


                    DataGridViewRow r = ConstruirFila();
                    SetearFila(r, detalleVenta);
                    AgregarFila(r);
                    


                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                try
                {
            
                    VentaEditDto ventaEditDto = frm.GetVenta();

                    ServiciosVentas.Guardar(ventaEditDto);
     

                    VentaListDto ventaListDto= new VentaListDto
                    {
                        VentaId= ventaEditDto.VentaId,
                        Apellido=ventaEditDto.cliente.Apellido,
                        Nombre=ventaEditDto.cliente.Nombre,
                        Fecha=ventaEditDto.Fecha,


                    };
                    DataGridViewRow r = ConstruirFila();
                    SetearFila2(r, ventaListDto);
                    AgregarFila(r);


                    MessageBox.Show("Registro agregado con exito", "Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }

                
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void SetearFila2(DataGridViewRow r, VentaListDto ventaListDto)
        {
            throw new NotImplementedException();
        }
    }
}
