
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
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivosToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
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
            // 
            // rellenosToolStripMenuItem
            // 
            this.rellenosToolStripMenuItem.Name = "rellenosToolStripMenuItem";
            this.rellenosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rellenosToolStripMenuItem.Text = "Rellenos";
            // 
            // tiposDeNuecesToolStripMenuItem
            // 
            this.tiposDeNuecesToolStripMenuItem.Name = "tiposDeNuecesToolStripMenuItem";
            this.tiposDeNuecesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tiposDeNuecesToolStripMenuItem.Text = "Tipos de Nueces";
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
            // FrmMenúPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "FrmMenúPrincipal";
            this.Text = "FrmMenúPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
    }
}