
namespace Bombones.Windows
{
    partial class FrmBombonesAE
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBombonesAE));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbTipoRelleno = new System.Windows.Forms.ComboBox();
            this.cbTipoChocolate = new System.Windows.Forms.ComboBox();
            this.cbTipoNuez = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNombreBombon = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.UpDownStock = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnok = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDescripcion);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(31, 146);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(607, 78);
            this.groupBox2.TabIndex = 193;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(9, 35);
            this.txtDescripcion.MaxLength = 50;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(592, 20);
            this.txtDescripcion.TabIndex = 199;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 184;
            this.label5.Text = "Descripcion:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbTipoRelleno);
            this.groupBox1.Controls.Add(this.cbTipoChocolate);
            this.groupBox1.Controls.Add(this.cbTipoNuez);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(22, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 106);
            this.groupBox1.TabIndex = 191;
            this.groupBox1.TabStop = false;
            // 
            // cbTipoRelleno
            // 
            this.cbTipoRelleno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoRelleno.FormattingEnabled = true;
            this.cbTipoRelleno.Location = new System.Drawing.Point(109, 74);
            this.cbTipoRelleno.Name = "cbTipoRelleno";
            this.cbTipoRelleno.Size = new System.Drawing.Size(286, 21);
            this.cbTipoRelleno.TabIndex = 148;
            // 
            // cbTipoChocolate
            // 
            this.cbTipoChocolate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoChocolate.FormattingEnabled = true;
            this.cbTipoChocolate.Location = new System.Drawing.Point(109, 11);
            this.cbTipoChocolate.Name = "cbTipoChocolate";
            this.cbTipoChocolate.Size = new System.Drawing.Size(286, 21);
            this.cbTipoChocolate.TabIndex = 147;
            // 
            // cbTipoNuez
            // 
            this.cbTipoNuez.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoNuez.FormattingEnabled = true;
            this.cbTipoNuez.Location = new System.Drawing.Point(109, 42);
            this.cbTipoNuez.Name = "cbTipoNuez";
            this.cbTipoNuez.Size = new System.Drawing.Size(286, 21);
            this.cbTipoNuez.TabIndex = 146;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Tipo de Nuez:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 144;
            this.label7.Text = "Tipo de Relleno:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(435, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tipo de Chocolate:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 178;
            this.label1.Text = "Nombre del Bombon:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 13);
            this.label15.TabIndex = 192;
            this.label15.Text = "Stock:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 62);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 13);
            this.label12.TabIndex = 191;
            this.label12.Text = "Precio por Unidad:";
            // 
            // txtNombreBombon
            // 
            this.txtNombreBombon.Location = new System.Drawing.Point(131, 12);
            this.txtNombreBombon.MaxLength = 50;
            this.txtNombreBombon.Name = "txtNombreBombon";
            this.txtNombreBombon.Size = new System.Drawing.Size(286, 20);
            this.txtNombreBombon.TabIndex = 195;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtCosto);
            this.groupBox3.Controls.Add(this.UpDownStock);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(460, 33);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(193, 104);
            this.groupBox3.TabIndex = 196;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(107, 59);
            this.txtCosto.MaxLength = 50;
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(71, 20);
            this.txtCosto.TabIndex = 198;
            // 
            // UpDownStock
            // 
            this.UpDownStock.Location = new System.Drawing.Point(63, 20);
            this.UpDownStock.Name = "UpDownStock";
            this.UpDownStock.Size = new System.Drawing.Size(65, 20);
            this.UpDownStock.TabIndex = 193;
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::Bombones.Windows.Properties.Resources.cancelar;
            this.btnCancel.Location = new System.Drawing.Point(407, 255);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 65);
            this.btnCancel.TabIndex = 190;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnok
            // 
            this.btnok.Image = ((System.Drawing.Image)(resources.GetObject("btnok.Image")));
            this.btnok.Location = new System.Drawing.Point(131, 255);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(81, 65);
            this.btnok.TabIndex = 192;
            this.btnok.Text = "Aceptar";
            this.btnok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmBombonesAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 348);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtNombreBombon);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(692, 387);
            this.MinimumSize = new System.Drawing.Size(692, 387);
            this.Name = "FrmBombonesAE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBombonesAE";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNombreBombon;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.NumericUpDown UpDownStock;
        private System.Windows.Forms.ComboBox cbTipoRelleno;
        private System.Windows.Forms.ComboBox cbTipoChocolate;
        private System.Windows.Forms.ComboBox cbTipoNuez;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}