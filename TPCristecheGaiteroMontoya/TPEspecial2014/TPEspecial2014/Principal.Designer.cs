namespace TPEspecial2013
{
    partial class Principal
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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.administraccionDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administraccionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarPlanillaDeDemandaDelBuqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.demandaDelBuqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saldoDeInventarioDelBuqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventarioDeLosProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDeCantidadesAOrdenarseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Status = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menu.SuspendLayout();
            this.Status.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.menu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administraccionDToolStripMenuItem,
            this.administraccionToolStripMenuItem,
            this.consultasToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menu.Size = new System.Drawing.Size(599, 31);
            this.menu.TabIndex = 4;
            this.menu.Text = "menuStrip1";
            // 
            // administraccionDToolStripMenuItem
            // 
            this.administraccionDToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarProductosToolStripMenuItem});
            this.administraccionDToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.administraccionDToolStripMenuItem.Name = "administraccionDToolStripMenuItem";
            this.administraccionDToolStripMenuItem.Size = new System.Drawing.Size(169, 25);
            this.administraccionDToolStripMenuItem.Text = "Control de Productos";
            // 
            // cargarProductosToolStripMenuItem
            // 
            this.cargarProductosToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cargarProductosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.cargarProductosToolStripMenuItem.Image = global::TPEspecial2013.Properties.Resources.Load;
            this.cargarProductosToolStripMenuItem.Name = "cargarProductosToolStripMenuItem";
            this.cargarProductosToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.cargarProductosToolStripMenuItem.Text = "Cargar Productos";
            this.cargarProductosToolStripMenuItem.Click += new System.EventHandler(this.cargarProductosToolStripMenuItem_Click);
            // 
            // administraccionToolStripMenuItem
            // 
            this.administraccionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarPlanillaDeDemandaDelBuqueToolStripMenuItem});
            this.administraccionToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.administraccionToolStripMenuItem.Name = "administraccionToolStripMenuItem";
            this.administraccionToolStripMenuItem.Size = new System.Drawing.Size(134, 25);
            this.administraccionToolStripMenuItem.Text = "Administraccion";
            // 
            // cargarPlanillaDeDemandaDelBuqueToolStripMenuItem
            // 
            this.cargarPlanillaDeDemandaDelBuqueToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cargarPlanillaDeDemandaDelBuqueToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.demandaDelBuqueToolStripMenuItem,
            this.saldoDeInventarioDelBuqueToolStripMenuItem});
            this.cargarPlanillaDeDemandaDelBuqueToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.cargarPlanillaDeDemandaDelBuqueToolStripMenuItem.Image = global::TPEspecial2013.Properties.Resources.Load;
            this.cargarPlanillaDeDemandaDelBuqueToolStripMenuItem.Name = "cargarPlanillaDeDemandaDelBuqueToolStripMenuItem";
            this.cargarPlanillaDeDemandaDelBuqueToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.cargarPlanillaDeDemandaDelBuqueToolStripMenuItem.Text = "Cargar Planillas";
            // 
            // demandaDelBuqueToolStripMenuItem
            // 
            this.demandaDelBuqueToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.demandaDelBuqueToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.demandaDelBuqueToolStripMenuItem.Name = "demandaDelBuqueToolStripMenuItem";
            this.demandaDelBuqueToolStripMenuItem.Size = new System.Drawing.Size(309, 26);
            this.demandaDelBuqueToolStripMenuItem.Text = "Abastecimiento de Productos";
            this.demandaDelBuqueToolStripMenuItem.Click += new System.EventHandler(this.demandaDelBuqueToolStripMenuItem_Click);
            // 
            // saldoDeInventarioDelBuqueToolStripMenuItem
            // 
            this.saldoDeInventarioDelBuqueToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.saldoDeInventarioDelBuqueToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.saldoDeInventarioDelBuqueToolStripMenuItem.Name = "saldoDeInventarioDelBuqueToolStripMenuItem";
            this.saldoDeInventarioDelBuqueToolStripMenuItem.Size = new System.Drawing.Size(309, 26);
            this.saldoDeInventarioDelBuqueToolStripMenuItem.Text = "Saldo de Inventario de Productos";
            this.saldoDeInventarioDelBuqueToolStripMenuItem.Click += new System.EventHandler(this.saldoDeInventarioDelBuqueToolStripMenuItem_Click);
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inventarioDeLosProductosToolStripMenuItem,
            this.listadoDeCantidadesAOrdenarseToolStripMenuItem});
            this.consultasToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(90, 25);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // inventarioDeLosProductosToolStripMenuItem
            // 
            this.inventarioDeLosProductosToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.inventarioDeLosProductosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.inventarioDeLosProductosToolStripMenuItem.Name = "inventarioDeLosProductosToolStripMenuItem";
            this.inventarioDeLosProductosToolStripMenuItem.Size = new System.Drawing.Size(269, 26);
            this.inventarioDeLosProductosToolStripMenuItem.Text = "Inventario de los Productos";
            this.inventarioDeLosProductosToolStripMenuItem.Click += new System.EventHandler(this.inventarioDeLosProductosToolStripMenuItem_Click);
            // 
            // listadoDeCantidadesAOrdenarseToolStripMenuItem
            // 
            this.listadoDeCantidadesAOrdenarseToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listadoDeCantidadesAOrdenarseToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.listadoDeCantidadesAOrdenarseToolStripMenuItem.Name = "listadoDeCantidadesAOrdenarseToolStripMenuItem";
            this.listadoDeCantidadesAOrdenarseToolStripMenuItem.Size = new System.Drawing.Size(269, 26);
            this.listadoDeCantidadesAOrdenarseToolStripMenuItem.Text = "Listado de Productos";
            this.listadoDeCantidadesAOrdenarseToolStripMenuItem.Click += new System.EventHandler(this.listadoDeCantidadesAOrdenarseToolStripMenuItem_Click);
            // 
            // Status
            // 
            this.Status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Status.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblUsuario,
            this.toolStripStatusLabel2});
            this.Status.Location = new System.Drawing.Point(0, 450);
            this.Status.Name = "Status";
            this.Status.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.Status.ShowItemToolTips = true;
            this.Status.Size = new System.Drawing.Size(599, 22);
            this.Status.TabIndex = 6;
            this.Status.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ActiveLinkColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(60, 17);
            this.toolStripStatusLabel1.Text = "Usuario :";
            // 
            // lblUsuario
            // 
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(58, 17);
            this.lblUsuario.Text = "----------";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(427, 17);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = "Inventario Del Minimercado";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(599, 472);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.menu);
            this.IsMdiContainer = true;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Principal_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.Status.ResumeLayout(false);
            this.Status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem administraccionDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administraccionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarPlanillaDeDemandaDelBuqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem demandaDelBuqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saldoDeInventarioDelBuqueToolStripMenuItem;
        private System.Windows.Forms.StatusStrip Status;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuario;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventarioDeLosProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoDeCantidadesAOrdenarseToolStripMenuItem;
    }
}