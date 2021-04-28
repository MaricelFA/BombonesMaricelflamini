
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
            this.bombonesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbProvincias = new System.Windows.Forms.ToolStripButton();
            this.tsbLocalidad = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbTipoChocolate = new System.Windows.Forms.ToolStripButton();
            this.tsbTipoRelleno = new System.Windows.Forms.ToolStripButton();
            this.tsbTipoNuez = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonClientes = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTiposDoc = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonBombon = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonVentas = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.tiposDeDocumentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeChocolateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeRellenosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeNuecesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
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
            this.ventasToolStripMenuItem,
            this.toolStripSeparator10,
            this.clientesToolStripMenuItem,
            this.toolStripSeparator8,
            this.provinciasToolStripMenuItem,
            this.localidadesToolStripMenuItem,
            this.toolStripSeparator1,
            this.bombonesToolStripMenuItem,
            this.toolStripSeparator9});
            this.archivosToolStripMenuItem.Name = "archivosToolStripMenuItem";
            this.archivosToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.archivosToolStripMenuItem.Text = "Archivos";
            // 
            // provinciasToolStripMenuItem
            // 
            this.provinciasToolStripMenuItem.Name = "provinciasToolStripMenuItem";
            this.provinciasToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.provinciasToolStripMenuItem.Text = "Provincias";
            this.provinciasToolStripMenuItem.Click += new System.EventHandler(this.provinciasToolStripMenuItem_Click);
            // 
            // localidadesToolStripMenuItem
            // 
            this.localidadesToolStripMenuItem.Name = "localidadesToolStripMenuItem";
            this.localidadesToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.localidadesToolStripMenuItem.Text = "Localidades";
            this.localidadesToolStripMenuItem.Click += new System.EventHandler(this.localidadesToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tiposDeDocumentosToolStripMenuItem});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(186, 6);
            // 
            // bombonesToolStripMenuItem
            // 
            this.bombonesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tiposDeChocolateToolStripMenuItem,
            this.tiposDeRellenosToolStripMenuItem,
            this.tiposDeNuecesToolStripMenuItem1});
            this.bombonesToolStripMenuItem.Name = "bombonesToolStripMenuItem";
            this.bombonesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bombonesToolStripMenuItem.Text = "Bombones";
            this.bombonesToolStripMenuItem.Click += new System.EventHandler(this.bombonesToolStripMenuItem_Click);
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
            this.toolStripButtonBombon,
            this.toolStripSeparator6,
            this.toolStripButtonClientes,
            this.toolStripSeparator4,
            this.toolStripButtonVentas,
            this.toolStripSeparator3,
            this.tsbProvincias,
            this.tsbLocalidad,
            this.toolStripSeparator5,
            this.tsbTipoChocolate,
            this.tsbTipoRelleno,
            this.tsbTipoNuez,
            this.toolStripSeparator7,
            this.toolStripButtonTiposDoc});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1370, 87);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbProvincias
            // 
            this.tsbProvincias.Image = global::Bombones.Windows.Properties.Resources.world_map_36px;
            this.tsbProvincias.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbProvincias.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbProvincias.Name = "tsbProvincias";
            this.tsbProvincias.Size = new System.Drawing.Size(65, 84);
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
            this.tsbLocalidad.Size = new System.Drawing.Size(73, 84);
            this.tsbLocalidad.Text = "Localidades";
            this.tsbLocalidad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbLocalidad.Click += new System.EventHandler(this.tsbLocalidad_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 87);
            // 
            // tsbTipoChocolate
            // 
            this.tsbTipoChocolate.Image = global::Bombones.Windows.Properties.Resources.chocolate_bar_36px;
            this.tsbTipoChocolate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbTipoChocolate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTipoChocolate.Name = "tsbTipoChocolate";
            this.tsbTipoChocolate.Size = new System.Drawing.Size(117, 84);
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
            this.tsbTipoRelleno.Size = new System.Drawing.Size(102, 84);
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
            this.tsbTipoNuez.Size = new System.Drawing.Size(97, 84);
            this.tsbTipoNuez.Text = "Tipos de Nueces";
            this.tsbTipoNuez.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbTipoNuez.Click += new System.EventHandler(this.tsbTipoNuez_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 87);
            // 
            // toolStripButtonClientes
            // 
            this.toolStripButtonClientes.Image = global::Bombones.Windows.Properties.Resources.clientes;
            this.toolStripButtonClientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonClientes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClientes.Name = "toolStripButtonClientes";
            this.toolStripButtonClientes.Size = new System.Drawing.Size(53, 84);
            this.toolStripButtonClientes.Text = "Clientes";
            this.toolStripButtonClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonClientes.Click += new System.EventHandler(this.toolStripButtonClientes_Click);
            // 
            // toolStripButtonTiposDoc
            // 
            this.toolStripButtonTiposDoc.Image = global::Bombones.Windows.Properties.Resources.doc;
            this.toolStripButtonTiposDoc.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonTiposDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTiposDoc.Name = "toolStripButtonTiposDoc";
            this.toolStripButtonTiposDoc.Size = new System.Drawing.Size(121, 84);
            this.toolStripButtonTiposDoc.Text = "Tipos de Documento";
            this.toolStripButtonTiposDoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonTiposDoc.Click += new System.EventHandler(this.toolStripButtonTiposDoc_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 87);
            // 
            // toolStripButtonBombon
            // 
            this.toolStripButtonBombon.Image = global::Bombones.Windows.Properties.Resources.candy;
            this.toolStripButtonBombon.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonBombon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBombon.Name = "toolStripButtonBombon";
            this.toolStripButtonBombon.Size = new System.Drawing.Size(68, 84);
            this.toolStripButtonBombon.Text = "Bombones";
            this.toolStripButtonBombon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonBombon.Click += new System.EventHandler(this.toolStripButtonBombon_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 87);
            // 
            // toolStripButtonVentas
            // 
            this.toolStripButtonVentas.Image = global::Bombones.Windows.Properties.Resources.ventas;
            this.toolStripButtonVentas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonVentas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonVentas.Name = "toolStripButtonVentas";
            this.toolStripButtonVentas.Size = new System.Drawing.Size(45, 84);
            this.toolStripButtonVentas.Text = "Ventas";
            this.toolStripButtonVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonVentas.Click += new System.EventHandler(this.toolStripButtonVentas_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 87);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(186, 6);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(186, 6);
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.ventasToolStripMenuItem.Text = "Ventas";
            this.ventasToolStripMenuItem.Click += new System.EventHandler(this.ventasToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(186, 6);
            // 
            // tiposDeDocumentosToolStripMenuItem
            // 
            this.tiposDeDocumentosToolStripMenuItem.Name = "tiposDeDocumentosToolStripMenuItem";
            this.tiposDeDocumentosToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.tiposDeDocumentosToolStripMenuItem.Text = "Tipos De Documentos";
            this.tiposDeDocumentosToolStripMenuItem.Click += new System.EventHandler(this.tiposDeDocumentosToolStripMenuItem_Click);
            // 
            // tiposDeChocolateToolStripMenuItem
            // 
            this.tiposDeChocolateToolStripMenuItem.Name = "tiposDeChocolateToolStripMenuItem";
            this.tiposDeChocolateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tiposDeChocolateToolStripMenuItem.Text = "Tipos De Chocolate";
            this.tiposDeChocolateToolStripMenuItem.Click += new System.EventHandler(this.tiposDeChocolateToolStripMenuItem_Click);
            // 
            // tiposDeRellenosToolStripMenuItem
            // 
            this.tiposDeRellenosToolStripMenuItem.Name = "tiposDeRellenosToolStripMenuItem";
            this.tiposDeRellenosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tiposDeRellenosToolStripMenuItem.Text = "Tipos De Rellenos";
            this.tiposDeRellenosToolStripMenuItem.Click += new System.EventHandler(this.tiposDeRellenosToolStripMenuItem_Click);
            // 
            // tiposDeNuecesToolStripMenuItem1
            // 
            this.tiposDeNuecesToolStripMenuItem1.Name = "tiposDeNuecesToolStripMenuItem1";
            this.tiposDeNuecesToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.tiposDeNuecesToolStripMenuItem1.Text = "Tipos De Nueces";
            this.tiposDeNuecesToolStripMenuItem1.Click += new System.EventHandler(this.tiposDeNuecesToolStripMenuItem1_Click);
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
            this.Load += new System.EventHandler(this.FrmMenúPrincipal_Load);
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
        private System.Windows.Forms.ToolStripMenuItem bombonesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbProvincias;
        private System.Windows.Forms.ToolStripButton tsbLocalidad;
        private System.Windows.Forms.ToolStripButton tsbTipoChocolate;
        private System.Windows.Forms.ToolStripButton tsbTipoNuez;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbTipoRelleno;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButtonClientes;
        private System.Windows.Forms.ToolStripButton toolStripButtonTiposDoc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButtonBombon;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripButtonVentas;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem tiposDeDocumentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposDeChocolateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposDeRellenosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposDeNuecesToolStripMenuItem1;
    }
}