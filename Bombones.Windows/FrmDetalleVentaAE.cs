using Bombones.BL;
using Bombones.BL.Dtos;
using Bombones.BL.Dtos.Bombon;
using Bombones.BL.Dtos.Cliente;
using Bombones.BL.Dtos.DetalleVenta;
using Bombones.BL.Dtos.Venta;
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
    public partial class FrmDetalleVentaAE : Form
    {

        private VentaEditDto ventaEdit;
        private DetalleVentaEditDto detalleVenta;

        private CarritoDto carrito;
        private BombonListDto bombonListDto;
        private ClienteListDto clienteListDto;
        private ClienteEditDto clienteEdit;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.CargarDatosComboClientes(ref cboCliente);

            Helper.CargarDatosComboBombones(ref cbBombon);
            carrito = new CarritoDto();

        }

            public FrmDetalleVentaAE()
        {
            InitializeComponent();
        }

        private DetalleVentaEditDto detalleEdit;
        private VentaEditDto ventaEditDto;

        public object FechaPedidoDatePicker { get; private set; }

        internal DetalleVentaEditDto GetDetalleVenta()
        {
            return detalleEdit;
        }

        internal VentaEditDto GetVenta()
        {
           return ventaEditDto;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
              

                ventaEditDto = new VentaEditDto();
                
                ventaEditDto.cliente.NombreCompleto = clienteListDto.ClienteId;

                foreach (var item in carrito.GetItems())
                {
                    var itemEditDto = new DetalleVentaEditDto()
                    {
                        bombon = item.bombon,
                        Cantidad = item.Cantidad,
                        Costo = item.Costo,
                    };
                    ventaEditDto.DetalleVentas.Add(itemEditDto);
                }
            }

            DialogResult = DialogResult.OK;
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cboCliente.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboCliente, "Debe seleccionar un cliente");
            }

            if (carrito.GetItems().Count == 0)
            {
                valido = false;
                errorProvider1.SetError(PedidoDataGridView, "Debe tener al menos un item");
            }
            return valido;
        }

        internal void SetVenta(VentaEditDto ventaEdit)
        {
            this.ventaEdit = ventaEdit;
        }

        private void cbBombon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBombon.SelectedIndex > 0)
            {
     
                bombonListDto = (BombonListDto)cbBombon.SelectedItem;
                TxtStock.Enabled = true;
                TxtPrecioUnidad.Enabled = true;
                TxtStock.Text = bombonListDto.CantidadEnExistencia.ToString();
                TxtPrecioUnidad.Text = bombonListDto.Costo.ToString();

            }
            else
            {
                TxtStock.Enabled = false;
                TxtPrecioUnidad.Enabled = false;
            }
        }

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCliente.SelectedIndex > 0)
            {
     
                clienteListDto = (ClienteListDto)cboCliente.SelectedItem;

                txtDireccion.Text = clienteListDto.Direccion;
                txtLocalidad.Text = clienteListDto.NombreLocalidad;

            }
            else
            {
                txtDireccion.Enabled = false;
                txtLocalidad.Enabled = false;
            }
        }

        private void UpDownCantidad_ValueChanged(object sender, EventArgs e)
        {
            if (UpDownCantidad.Value > 0)
            {
               txtSubTotal.Text = ((decimal)UpDownCantidad.Value * bombonListDto.Costo).ToString();
     
            }
            else
            {
                txtSubTotal.Text = "0";
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (ValidarDatosBombones())
            {
                if ( detalleVenta== null)
                {
                    detalleVenta = new DetalleVentaEditDto();
                }

                detalleVenta.bombon = bombonListDto;
                detalleVenta.Cantidad = (int)UpDownCantidad.Value;
                detalleVenta.Costo = decimal.Parse(txtSubTotal.Text);

                carrito.AgregarAlCarrito(detalleVenta);
                MostrarDatosEnGrilla();
                MostrarTotalDeVenta();
                InicializarControlesItemVenta();
            }

        }

        private void InicializarControlesItemVenta()
        {
            cbBombon.SelectedIndex = 0;
            TxtStock.Clear();
            txtSubTotal.Clear();
            TxtPrecioUnidad.Clear();
            TxtPrecioUnidad.Clear();
            UpDownCantidad.Value = 0;
            bombonListDto = null;
            detalleVenta = null;
        }

        private void MostrarTotalDeVenta()
        {
            TxtTotal.Text = carrito.InformarTotal().ToString();
        }

        private void MostrarDatosEnGrilla()
        {
            PedidoDataGridView.Rows.Clear();
            foreach (var item in carrito.GetItems())
            {
                var r = ConstruirFila();
                SetearFila(r, item);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            PedidoDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, DetalleVentaEditDto item)
        {
            r.Cells[cmnBombon.Index].Value = item.bombon.NombreBombon;
            r.Cells[cmnPrecioUnidad.Index].Value = item.Costo;
            r.Cells[cmnCantidad.Index].Value = item.Cantidad;
            r.Cells[cmnTotal.Index].Value = item.Total;

            r.Tag = item;
        }

        private DataGridViewRow ConstruirFila()
        {
            var r = new DataGridViewRow();
            r.CreateCells(PedidoDataGridView);
            return r;
        }

        private bool ValidarDatosBombones()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cbBombon.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cbBombon, "Debe seleccionar un tipo de bombón");
            }
            if (cboCliente.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboCliente, "Debe seleccionar un cliente");
            }

            if (UpDownCantidad.Value == 0)
            {
                valido = false;
                errorProvider1.SetError(UpDownCantidad, "Debe llevar al menos un bombón");
            }
           else if ((double)UpDownCantidad.Value > bombonListDto.CantidadEnExistencia)
           {
                valido = false;
                errorProvider1.SetError(UpDownCantidad, "Cantidad superior al stock del producto");

            }


            return valido;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            InicializarControlesItemVenta();
        }

        private void CancelarButton_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
