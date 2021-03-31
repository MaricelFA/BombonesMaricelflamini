
namespace Bombones.Windows
{
    partial class FrmMenúPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.provinciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tiposDeChocolatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rellenosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeNuecesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bombonesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cajasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbProvincias = new System.Windows.Forms.ToolStripButton();
            this.tsbLocalidad = new System.Windows.Forms.ToolStripButton();
            this.tsbTipoChocolate = new System.Windows.Forms.ToolStripButton();
            this.tsbTipoRelleno = new System.Windows.Forms.ToolStripButton();
            this.tsbTipoNuez = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivosToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1370, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivosToolStripMenuItem
            // 
            this.archivosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.provinciasToolStripMenuItem,
            this.localidadesToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.toolStripSeparator1,
            this.tiposDeChocolatesToolStripMenuItem,
            this.rellenosToolStripMenuItem,
            this.tiposDeNuecesToolStripMenuItem,
            this.bombonesToolStripMenuItem,
            this.cajasToolStripMenuItem});
            this.archivosToolStripMenuItem.Name = "archivosToolStripMenuItem";
            this.archivosToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.archivosToolStripMenuItem.Text = "Archivos";
            // 
            // provinciasToolStripMenuItem
            // 
            this.provinciasToolStripMenuItem.Name = "provinciasToolStripMenuItem";
            this.provinciasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.provinciasToolStripMenuItem.Text = "Provincias";
            this.provinciasToolStripMenuItem.Click += new System.EventHandler(this.provinciasToolStripMenuItem_Click);
            // 
            // localidadesToolStripMenuItem
            // 
            this.localidadesToolStripMenuItem.Name = "localidadesToolStripMenuItem";
            this.localidadesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.localidadesToolStripMenuItem.Text = "Localidades";
            this.localidadesToolStripMenuItem.Click += new System.EventHandler(this.localidadesToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // tiposDeChocolatesToolStripMenuItem
            // 
            this.tiposDeChocolatesToolStripMenuItem.Name = "tiposDeChocolatesToolStripMenuItem";
            this.tiposDeChocolatesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tiposDeChocolatesToolStripMenuItem.Text = "Tipos de Chocolates";
            this.tiposDeChocolatesToolStripMenuItem.Click += new System.EventHandler(this.tiposDeChocolatesToolStripMenuItem_Click);
            // 
            // rellenosToolStripMenuItem
            // 
            this.rellenosToolStripMenuItem.Name = "rellenosToolStripMenuItem";
            this.rellenosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rellenosToolStripMenuItem.Text = "Rellenos";
            this.rellenosToolStripMenuItem.Click += new System.EventHandler(this.rellenosToolStripMenuItem_Click);
            // 
            // tiposDeNuecesToolStripMenuItem
            // 
            this.tiposDeNuecesToolStripMenuItem.Name = "tiposDeNuecesToolStripMenuItem";
            this.tiposDeNuecesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tiposDeNuecesToolStripMenuItem.Text = "Tipos de Nueces";
            this.tiposDeNuecesToolStripMenuItem.Click += new System.EventHandler(this.tiposDeNuecesToolStripMenuItem_Click);
            // 
            // bombonesToolStripMenuItem
            // 
            this.bombonesToolStripMenuItem.Name = "bombonesToolStripMenuItem";
            this.bombonesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bombonesToolStripMenuItem.Text = "Bombones";
            // 
            // cajasToolStripMenuItem
            // 
            this.cajasToolStripMenuItem.Name = "cajasToolStripMenuItem";
            this.cajasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cajasToolStripMenuItem.Text = "Cajas";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbProvincias,
            this.tsbLocalidad,
            this.toolStripSeparator3,
            this.tsbTipoChocolate,
            this.tsbTipoRelleno,
            this.tsbTipoNuez});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1370, 58);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 58);
            // 
            // tsbProvincias
            // 
            this.tsbProvincias.Image = global::Bombones.Windows.Properties.Resources.world_map_36px;
            this.tsbProvincias.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbProvincias.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbProvincias.Name = "tsbProvincias";
            this.tsbProvincias.Size = new System.Drawing.Size(65, 55);
            this.tsbProvincias.Text = "Provincias";
            this.tsbProvincias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbProvincias.Click += new System.EventHandler(this.tsbProvincias_Click);
            // 
            // tsbLocalidad
            // 
            this.tsbLocalidad.Image = global::Bombones.Windows.Properties.Resources.city_36px;
            this.tsbLocalidad.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbLocalidad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLocalidad.Name = "tsbLocalidad";
            this.tsbLocalidad.Size = new System.Drawing.Size(73, 55);
            this.tsbLocalidad.Text = "Localidades";
            this.tsbLocalidad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbLocalidad.Click += new System.EventHandler(this.tsbLocalidad_Click);
            // 
            // tsbTipoChocolate
            // 
            this.tsbTipoChocolate.Image = global::Bombones.Windows.Properties.Resources.chocolate_bar_36px;
            this.tsbTipoChocolate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbTipoChocolate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTipoChocolate.Name = "tsbTipoChocolate";
            this.tsbTipoChocolate.Size = new System.Drawing.Size(117, 55);
            this.tsbTipoChocolate.Text = "Tipos de Chocolates";
            this.tsbTipoChocolate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbTipoChocolate.Click += new System.EventHandler(this.tsbTipoChocolate_Click);
            // 
            // tsbTipoRelleno
            // 
            this.tsbTipoRelleno.Image = global::Bombones.Windows.Properties.Resources.chocolate_truffle_36px;
            this.tsbTipoRelleno.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbTipoRelleno.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTipoRelleno.Name = "tsbTipoRelleno";
            this.tsbTipoRelleno.Size = new System.Drawing.Size(102, 55);
            this.tsbTipoRelleno.Text = "Tipos de Rellenos";
            this.tsbTipoRelleno.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbTipoRelleno.Click += new System.EventHandler(this.tsbTipoRelleno_Click);
            // 
            // tsbTipoNuez
            // 
            this.tsbTipoNuez.Image = global::Bombones.Windows.Properties.Resources.hazelnut_36px;
            this.tsbTipoNuez.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbTipoNuez.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTipoNuez.Name = "tsbTipoNuez";
            this.tsbTipoNuez.Size = new System.Drawing.Size(97, 55);
            this.tsbTipoNuez.Text = "Tipos de Nueces";
            this.tsbTipoNuez.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbTipoNuez.Click += new System.EventHandler(this.tsbTipoNuez_Click);
            // 
            // FrmMenúPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.ControlBox = false;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "FrmMenúPrincipal";
            this.Text = "FrmMenúPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem provinciasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tiposDeChocolatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rellenosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposDeNuecesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bombonesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cajasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbProvincias;
        private System.Windows.Forms.ToolStripButton tsbLocalidad;
        private System.Windows.Forms.ToolStripButton tsbTipoChocolate;
        private System.Windows.Forms.ToolStripButton tsbTipoNuez;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbTipoRelleno;
    }
}