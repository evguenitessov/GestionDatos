namespace ClinicaFrba.Abm_Afiliado
{
    partial class listado_afiliado
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
            this.filtros = new System.Windows.Forms.GroupBox();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.mail = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.nroafiliado = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.nroflia = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.usuario = new System.Windows.Forms.ToolStripTextBox();
            this.grid_afiliados = new System.Windows.Forms.DataGridView();
            this.modificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.baja = new System.Windows.Forms.DataGridViewButtonColumn();
            this.bot_mprincipal = new System.Windows.Forms.Button();
            this.bot_buscar = new System.Windows.Forms.Button();
            this.bot_borrar = new System.Windows.Forms.Button();
            this.filtros.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_afiliados)).BeginInit();
            this.SuspendLayout();
            // 
            // filtros
            // 
            this.filtros.Controls.Add(this.toolStrip4);
            this.filtros.Controls.Add(this.toolStrip2);
            this.filtros.Controls.Add(this.toolStrip1);
            this.filtros.Location = new System.Drawing.Point(4, 4);
            this.filtros.Margin = new System.Windows.Forms.Padding(4);
            this.filtros.Name = "filtros";
            this.filtros.Padding = new System.Windows.Forms.Padding(4);
            this.filtros.Size = new System.Drawing.Size(577, 131);
            this.filtros.TabIndex = 0;
            this.filtros.TabStop = false;
            this.filtros.Text = "Filtros de búsqueda";
            // 
            // toolStrip4
            // 
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel4,
            this.mail});
            this.toolStrip4.Location = new System.Drawing.Point(4, 74);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(569, 25);
            this.toolStrip4.TabIndex = 3;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(30, 22);
            this.toolStripLabel4.Text = "Mail";
            // 
            // mail
            // 
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.nroafiliado,
            this.toolStripLabel3,
            this.nroflia});
            this.toolStrip2.Location = new System.Drawing.Point(4, 49);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(569, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(88, 22);
            this.toolStripLabel2.Text = "Nro. de afiliado";
            // 
            // nroafiliado
            // 
            this.nroafiliado.Name = "nroafiliado";
            this.nroafiliado.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(85, 22);
            this.toolStripLabel3.Text = "Nro. de familia";
            // 
            // nroflia
            // 
            this.nroflia.Name = "nroflia";
            this.nroflia.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.usuario});
            this.toolStrip1.Location = new System.Drawing.Point(4, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(569, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(109, 22);
            this.toolStripLabel1.Text = "Nombre de usuario";
            // 
            // usuario
            // 
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(100, 25);
            // 
            // grid_afiliados
            // 
            this.grid_afiliados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_afiliados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.modificar,
            this.baja});
            this.grid_afiliados.Location = new System.Drawing.Point(4, 188);
            this.grid_afiliados.Name = "grid_afiliados";
            this.grid_afiliados.Size = new System.Drawing.Size(577, 370);
            this.grid_afiliados.TabIndex = 1;
            this.grid_afiliados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_afiliados_CellContentClick);
            // 
            // modificar
            // 
            this.modificar.HeaderText = "Modificar";
            this.modificar.Name = "modificar";
            this.modificar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.modificar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // baja
            // 
            this.baja.HeaderText = "Baja";
            this.baja.Name = "baja";
            this.baja.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.baja.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // bot_mprincipal
            // 
            this.bot_mprincipal.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bot_mprincipal.Location = new System.Drawing.Point(4, 142);
            this.bot_mprincipal.Name = "bot_mprincipal";
            this.bot_mprincipal.Size = new System.Drawing.Size(124, 40);
            this.bot_mprincipal.TabIndex = 13;
            this.bot_mprincipal.Text = "Atrás";
            this.bot_mprincipal.UseVisualStyleBackColor = true;
            this.bot_mprincipal.Click += new System.EventHandler(this.bot_mprincipal_Click);
            // 
            // bot_buscar
            // 
            this.bot_buscar.Font = new System.Drawing.Font("Calibri", 11F);
            this.bot_buscar.Location = new System.Drawing.Point(457, 142);
            this.bot_buscar.Name = "bot_buscar";
            this.bot_buscar.Size = new System.Drawing.Size(124, 40);
            this.bot_buscar.TabIndex = 12;
            this.bot_buscar.Text = "Buscar";
            this.bot_buscar.UseVisualStyleBackColor = true;
            this.bot_buscar.Click += new System.EventHandler(this.bot_buscar_Click);
            // 
            // bot_borrar
            // 
            this.bot_borrar.Font = new System.Drawing.Font("Calibri", 11F);
            this.bot_borrar.Location = new System.Drawing.Point(227, 142);
            this.bot_borrar.Name = "bot_borrar";
            this.bot_borrar.Size = new System.Drawing.Size(124, 40);
            this.bot_borrar.TabIndex = 11;
            this.bot_borrar.Text = "Borrar";
            this.bot_borrar.UseVisualStyleBackColor = true;
            this.bot_borrar.Click += new System.EventHandler(this.bot_borrar_Click);
            // 
            // listado_afiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.bot_buscar);
            this.Controls.Add(this.bot_mprincipal);
            this.Controls.Add(this.bot_borrar);
            this.Controls.Add(this.grid_afiliados);
            this.Controls.Add(this.filtros);
            this.Font = new System.Drawing.Font("Calibri", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "listado_afiliado";
            this.Text = "Clinica FRBA - Listado de afiliados";
            this.filtros.ResumeLayout(false);
            this.filtros.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_afiliados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox filtros;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox mail;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox nroafiliado;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox usuario;
        private System.Windows.Forms.DataGridView grid_afiliados;
        private System.Windows.Forms.DataGridViewButtonColumn modificar;
        private System.Windows.Forms.DataGridViewButtonColumn baja;
        private System.Windows.Forms.Button bot_mprincipal;
        private System.Windows.Forms.Button bot_buscar;
        private System.Windows.Forms.Button bot_borrar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox nroflia;
    }
}