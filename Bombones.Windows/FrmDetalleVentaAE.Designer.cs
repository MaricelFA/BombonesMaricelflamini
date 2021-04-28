
namespace Bombones.Windows
{
    partial class FrmDetalleVentaAE
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDetalleVentaAE));
            this.txtFechaVenta = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cbBombon = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.UpDownCantidad = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TxtPrecioUnidad = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.TxtStock = new System.Windows.Forms.TextBox();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.PedidoDataGridView = new System.Windows.Forms.DataGridView();
            this.cmnBombon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnPrecioUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnok = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownCantidad)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PedidoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFechaVenta
            // 
            this.txtFechaVenta.Checked = false;
            this.txtFechaVenta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFechaVenta.Location = new System.Drawing.Point(113, 19);
            this.txtFechaVenta.Name = "txtFechaVenta";
            this.txtFechaVenta.Size = new System.Drawing.Size(122, 20);
            this.txtFechaVenta.TabIndex = 185;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 184;
            this.label5.Text = "Fecha de Venta:";
            // 
            // cbBombon
            // 
            this.cbBombon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBombon.FormattingEnabled = true;
            this.cbBombon.Location = new System.Drawing.Point(55, 13);
            this.cbBombon.Name = "cbBombon";
            this.cbBombon.Size = new System.Drawing.Size(239, 21);
            this.cbBombon.TabIndex = 183;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboCliente);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtLocalidad);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(22, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 114);
            this.groupBox1.TabIndex = 171;
            this.groupBox1.TabStop = false;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(67, 45);
            this.txtDireccion.MaxLength = 100;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(262, 20);
            this.txtDireccion.TabIndex = 146;
            this.txtDireccion.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Direccion:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 144;
            this.label7.Text = "Localidad:";
            // 
            // cboCliente
            // 
            this.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(67, 16);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(263, 21);
            this.cboCliente.TabIndex = 145;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(435, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 0;
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(68, 71);
            this.txtLocalidad.MaxLength = 100;
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.ReadOnly = true;
            this.txtLocalidad.Size = new System.Drawing.Size(262, 20);
            this.txtLocalidad.TabIndex = 0;
            this.txtLocalidad.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cliente:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 178;
            this.label1.Text = "Bombon:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtFechaVenta);
            this.groupBox2.Location = new System.Drawing.Point(418, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(258, 52);
            this.groupBox2.TabIndex = 186;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // UpDownCantidad
            // 
            this.UpDownCantidad.Enabled = false;
            this.UpDownCantidad.Location = new System.Drawing.Point(71, 45);
            this.UpDownCantidad.Name = "UpDownCantidad";
            this.UpDownCantidad.Size = new System.Drawing.Size(120, 20);
            this.UpDownCantidad.TabIndex = 187;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 188;
            this.label8.Text = "Cantidad:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TxtPrecioUnidad);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.TxtStock);
            this.groupBox3.Controls.Add(this.UpDownCantidad);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cbBombon);
            this.groupBox3.Location = new System.Drawing.Point(418, 78);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(300, 111);
            this.groupBox3.TabIndex = 189;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // TxtPrecioUnidad
            // 
            this.TxtPrecioUnidad.Location = new System.Drawing.Point(208, 76);
            this.TxtPrecioUnidad.Name = "TxtPrecioUnidad";
            this.TxtPrecioUnidad.ReadOnly = true;
            this.TxtPrecioUnidad.Size = new System.Drawing.Size(86, 20);
            this.TxtPrecioUnidad.TabIndex = 189;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(110, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 13);
            this.label12.TabIndex = 191;
            this.label12.Text = "Precio por Unidad:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 80);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 13);
            this.label15.TabIndex = 192;
            this.label15.Text = "Stock:";
            // 
            // TxtStock
            // 
            this.TxtStock.Location = new System.Drawing.Point(53, 76);
            this.TxtStock.Name = "TxtStock";
            this.TxtStock.ReadOnly = true;
            this.TxtStock.Size = new System.Drawing.Size(51, 20);
            this.TxtStock.TabIndex = 190;
            this.TxtStock.TabStop = false;
            this.TxtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TxtTotal
            // 
            this.TxtTotal.Location = new System.Drawing.Point(626, 412);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.ReadOnly = true;
            this.TxtTotal.Size = new System.Drawing.Size(76, 20);
            this.TxtTotal.TabIndex = 194;
            this.TxtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(589, 415);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(34, 13);
            this.label16.TabIndex = 193;
            this.label16.Text = "Total:";
            // 
            // PedidoDataGridView
            // 
            this.PedidoDataGridView.AllowUserToAddRows = false;
            this.PedidoDataGridView.AllowUserToDeleteRows = false;
            this.PedidoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PedidoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnBombon,
            this.cmnPrecioUnidad,
            this.cmnCantidad,
            this.cmnTotal});
            this.PedidoDataGridView.Location = new System.Drawing.Point(12, 219);
            this.PedidoDataGridView.MultiSelect = false;
            this.PedidoDataGridView.Name = "PedidoDataGridView";
            this.PedidoDataGridView.ReadOnly = true;
            this.PedidoDataGridView.RowHeadersVisible = false;
            this.PedidoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PedidoDataGridView.Size = new System.Drawing.Size(785, 190);
            this.PedidoDataGridView.TabIndex = 192;
            // 
            // cmnBombon
            // 
            this.cmnBombon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnBombon.HeaderText = "Bombones";
            this.cmnBombon.Name = "cmnBombon";
            this.cmnBombon.ReadOnly = true;
            // 
            // cmnPrecioUnidad
            // 
            this.cmnPrecioUnidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cmnPrecioUnidad.DefaultCellStyle = dataGridViewCellStyle1;
            this.cmnPrecioUnidad.HeaderText = "Precio Por Unidad";
            this.cmnPrecioUnidad.Name = "cmnPrecioUnidad";
            this.cmnPrecioUnidad.ReadOnly = true;
            // 
            // cmnCantidad
            // 
            this.cmnCantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cmnCantidad.DefaultCellStyle = dataGridViewCellStyle2;
            this.cmnCantidad.HeaderText = "Cantidad";
            this.cmnCantidad.Name = "cmnCantidad";
            this.cmnCantidad.ReadOnly = true;
            // 
            // cmnTotal
            // 
            this.cmnTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cmnTotal.DefaultCellStyle = dataGridViewCellStyle3;
            this.cmnTotal.HeaderText = "Total";
            this.cmnTotal.Name = "cmnTotal";
            this.cmnTotal.ReadOnly = true;
            // 
            // CancelarButton
            // 
            this.CancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelarButton.Image = global::Bombones.Windows.Properties.Resources.cancelar;
            this.CancelarButton.Location = new System.Drawing.Point(460, 415);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(81, 63);
            this.CancelarButton.TabIndex = 191;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CancelarButton.UseVisualStyleBackColor = true;

            // 
            // OkButton
            // 
            this.OkButton.Image = global::Bombones.Windows.Properties.Resources.Ok;
            this.OkButton.Location = new System.Drawing.Point(184, 415);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(81, 63);
            this.OkButton.TabIndex = 190;
            this.OkButton.Text = "OK";
            this.OkButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::Bombones.Windows.Properties.Resources.cancelar;
            this.btnCancel.Location = new System.Drawing.Point(300, 132);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 65);
            this.btnCancel.TabIndex = 167;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnok
            // 
            this.btnok.Image = ((System.Drawing.Image)(resources.GetObject("btnok.Image")));
            this.btnok.Location = new System.Drawing.Point(90, 132);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(81, 65);
            this.btnok.TabIndex = 181;
            this.btnok.Text = "Aceptar";
            this.btnok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnok.UseVisualStyleBackColor = true;
            // 
            // FrmDetalleVentaAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 509);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.TxtTotal);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.PedidoDataGridView);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(847, 548);
            this.MinimumSize = new System.Drawing.Size(847, 548);
            this.Name = "FrmDetalleVentaAE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDetalleVentaAE";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownCantidad)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PedidoDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker txtFechaVenta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbBombon;
        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown UpDownCantidad;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TxtPrecioUnidad;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox TxtStock;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.TextBox TxtTotal;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView PedidoDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnBombon;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnPrecioUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnTotal;
    }
}