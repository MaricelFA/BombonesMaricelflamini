using Bombones.BL;
using Bombones.BL.Dtos.Bombon;
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
    public partial class FrmBombonesAE : Form
    {
        public FrmBombonesAE()
        {
            InitializeComponent();
        }

        internal BombonEditDto GetBombon()
        {
            return bombon;
        }

        internal void SetBombon(BombonEditDto bombonEdit)
        {
            this.bombon = bombonEdit;
        }
        private BombonEditDto bombon;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.CargarDatosComboTipoChocolate(ref cbTipoChocolate);
            Helper.CargarDatosComboTipoNuez(ref cbTipoNuez);
            Helper.CargarDatosComboTipoRelleno(ref cbTipoRelleno);
            if (bombon != null)
            {
                txtNombreBombon.Text = bombon.NombreBombon;
                UpDownStock.Value = bombon.CantidadEnExistencia;
                txtCosto.Text = bombon.Costo.ToString();// decimal.Parse(txtCosto.Text);
                txtDescripcion.Text = bombon.Descripcion;
                cbTipoChocolate.SelectedValue = bombon.tipoChocolate.TipoChocolateId;
                cbTipoNuez.SelectedValue = bombon.tipodeNuez.TipoDeNuezId;
                cbTipoRelleno.SelectedValue = bombon.tipodeRelleno.TipoRellenoId;


            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (bombon == null)
                {
                    bombon = new BombonEditDto();
                }

                bombon.NombreBombon = txtNombreBombon.Text;
                bombon.Descripcion = txtDescripcion.Text;
                bombon.Costo = decimal.Parse(txtCosto.Text);
                bombon.CantidadEnExistencia = (int)UpDownStock.Value;
                bombon.tipoChocolate = (TipoChocolate)cbTipoChocolate.SelectedItem;
                bombon.tipodeNuez = (TipodeNuez)cbTipoNuez.SelectedItem;
                bombon.tipodeRelleno = (TipodeRelleno)cbTipoRelleno.SelectedItem;

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtNombreBombon.Text) || string.IsNullOrWhiteSpace(txtNombreBombon.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNombreBombon, "Nombre de Bombón requerido");
            }
            if ((int)UpDownStock.Value <= 0)
            {
                valido = false;
                errorProvider1.SetError(UpDownStock, "Cantidad mal ingresada");

            }
            if (cbTipoChocolate.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cbTipoChocolate, "Debe seleccionar un tipo de chocolate ");
            }
            if (string.IsNullOrEmpty(txtCosto.Text) || string.IsNullOrWhiteSpace(txtCosto.Text))
            {
                valido = false;
                errorProvider1.SetError(txtCosto, "Campo requerido");
            }
            if (cbTipoNuez.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cbTipoNuez, "Debe seleccionar un tipo de nuez ");
            }
            if (cbTipoRelleno.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cbTipoRelleno, "Debe seleccionar un tipo de relleno ");
            }


            return valido;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
    
}
