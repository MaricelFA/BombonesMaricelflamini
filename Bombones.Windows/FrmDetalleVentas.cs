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

        private List<DetalleVentaListDto> _listadetalle;
        private List<VentaListDto> _listaventa;

        private void FrmDetalleVentas_Load(object sender, EventArgs e)
        {
            try
            {
                _servicioDetalle = new ServiciosDetalleVentas();
                _listadetalle = _servicioDetalle.GetLista();
                MostrarEnGrilla();
                _
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
