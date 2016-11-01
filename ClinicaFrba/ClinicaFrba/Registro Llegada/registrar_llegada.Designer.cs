namespace ClinicaFrba.Registro_Llegada
{
    partial class registrar_llegada
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlCrit = new System.Windows.Forms.Panel();
            this.checkProfesional = new System.Windows.Forms.CheckBox();
            this.checkEspecialidad = new System.Windows.Forms.CheckBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCrit = new System.Windows.Forms.Button();
            this.comboBusqueda = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBuscarTurnosDisp = new System.Windows.Forms.Button();
            this.comboBusqueda2 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.fechaDeTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horaDeInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horaDeFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.llegada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.comboAfiliado = new System.Windows.Forms.ComboBox();
            this.gridBonosDisponibles = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.pnlCrit.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBonosDisponibles)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlCrit);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.btnCrit);
            this.groupBox1.Controls.Add(this.comboBusqueda);
            this.groupBox1.Location = new System.Drawing.Point(95, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 75);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Búsqueda por Profesional";
            // 
            // pnlCrit
            // 
            this.pnlCrit.Controls.Add(this.checkProfesional);
            this.pnlCrit.Controls.Add(this.checkEspecialidad);
            this.pnlCrit.Location = new System.Drawing.Point(273, 14);
            this.pnlCrit.Name = "pnlCrit";
            this.pnlCrit.Size = new System.Drawing.Size(92, 49);
            this.pnlCrit.TabIndex = 1;
            // 
            // checkProfesional
            // 
            this.checkProfesional.AutoSize = true;
            this.checkProfesional.Location = new System.Drawing.Point(3, 5);
            this.checkProfesional.Name = "checkProfesional";
            this.checkProfesional.Size = new System.Drawing.Size(78, 17);
            this.checkProfesional.TabIndex = 1;
            this.checkProfesional.Text = "Profesional";
            this.checkProfesional.UseVisualStyleBackColor = true;
            this.checkProfesional.CheckedChanged += new System.EventHandler(this.checkProfesional_CheckedChanged);
            // 
            // checkEspecialidad
            // 
            this.checkEspecialidad.AutoSize = true;
            this.checkEspecialidad.Location = new System.Drawing.Point(3, 28);
            this.checkEspecialidad.Name = "checkEspecialidad";
            this.checkEspecialidad.Size = new System.Drawing.Size(86, 17);
            this.checkEspecialidad.TabIndex = 4;
            this.checkEspecialidad.Text = "Especialidad";
            this.checkEspecialidad.UseVisualStyleBackColor = true;
            this.checkEspecialidad.CheckedChanged += new System.EventHandler(this.checkEspecialidad_CheckedChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(163, 27);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(49, 23);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnCrit
            // 
            this.btnCrit.Location = new System.Drawing.Point(218, 27);
            this.btnCrit.Name = "btnCrit";
            this.btnCrit.Size = new System.Drawing.Size(49, 23);
            this.btnCrit.TabIndex = 2;
            this.btnCrit.Text = "Criterio";
            this.btnCrit.UseVisualStyleBackColor = true;
            this.btnCrit.Click += new System.EventHandler(this.btnCrit_Click);
            // 
            // comboBusqueda
            // 
            this.comboBusqueda.FormattingEnabled = true;
            this.comboBusqueda.Location = new System.Drawing.Point(6, 29);
            this.comboBusqueda.Name = "comboBusqueda";
            this.comboBusqueda.Size = new System.Drawing.Size(151, 21);
            this.comboBusqueda.TabIndex = 1;
            this.comboBusqueda.SelectedIndexChanged += new System.EventHandler(this.comboBusqueda_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(530, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(24, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(530, 24);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(24, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBuscarTurnosDisp);
            this.groupBox2.Controls.Add(this.comboBusqueda2);
            this.groupBox2.Location = new System.Drawing.Point(95, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(377, 75);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seleccionar Especialidad";
            this.groupBox2.Visible = false;
            // 
            // btnBuscarTurnosDisp
            // 
            this.btnBuscarTurnosDisp.Location = new System.Drawing.Point(163, 27);
            this.btnBuscarTurnosDisp.Name = "btnBuscarTurnosDisp";
            this.btnBuscarTurnosDisp.Size = new System.Drawing.Size(49, 23);
            this.btnBuscarTurnosDisp.TabIndex = 3;
            this.btnBuscarTurnosDisp.Text = "Buscar";
            this.btnBuscarTurnosDisp.UseVisualStyleBackColor = true;
            this.btnBuscarTurnosDisp.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBusqueda2
            // 
            this.comboBusqueda2.FormattingEnabled = true;
            this.comboBusqueda2.Location = new System.Drawing.Point(6, 27);
            this.comboBusqueda2.Name = "comboBusqueda2";
            this.comboBusqueda2.Size = new System.Drawing.Size(151, 21);
            this.comboBusqueda2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fechaDeTurno,
            this.horaDeInicio,
            this.horaDeFin,
            this.llegada});
            this.dataGridView1.Location = new System.Drawing.Point(12, 203);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(560, 164);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // fechaDeTurno
            // 
            this.fechaDeTurno.HeaderText = "Fecha";
            this.fechaDeTurno.Name = "fechaDeTurno";
            // 
            // horaDeInicio
            // 
            this.horaDeInicio.HeaderText = "Hora de Inicio";
            this.horaDeInicio.Name = "horaDeInicio";
            // 
            // horaDeFin
            // 
            this.horaDeFin.HeaderText = "Hora de Fin";
            this.horaDeFin.Name = "horaDeFin";
            // 
            // llegada
            // 
            this.llegada.HeaderText = "Llegada de Afiliado";
            this.llegada.Name = "llegada";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.comboAfiliado);
            this.groupBox3.Location = new System.Drawing.Point(12, 403);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(226, 75);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Seleccionar Afiliado";
            this.groupBox3.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(163, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(49, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Buscar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboAfiliado
            // 
            this.comboAfiliado.FormattingEnabled = true;
            this.comboAfiliado.Location = new System.Drawing.Point(6, 27);
            this.comboAfiliado.Name = "comboAfiliado";
            this.comboAfiliado.Size = new System.Drawing.Size(151, 21);
            this.comboAfiliado.TabIndex = 1;
            // 
            // gridBonosDisponibles
            // 
            this.gridBonosDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBonosDisponibles.Location = new System.Drawing.Point(6, 16);
            this.gridBonosDisponibles.Name = "gridBonosDisponibles";
            this.gridBonosDisponibles.Size = new System.Drawing.Size(302, 124);
            this.gridBonosDisponibles.TabIndex = 6;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.gridBonosDisponibles);
            this.groupBox4.Location = new System.Drawing.Point(258, 385);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(314, 146);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Bonos Disponibles ";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(50, 503);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(151, 46);
            this.btnConfirmar.TabIndex = 8;
            this.btnConfirmar.Text = "Confirmar Llegada";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            // 
            // registrar_llegada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "registrar_llegada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Llegada";
            this.Load += new System.EventHandler(this.registrar_llegada_Load);
            this.groupBox1.ResumeLayout(false);
            this.pnlCrit.ResumeLayout(false);
            this.pnlCrit.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBonosDisponibles)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkEspecialidad;
        private System.Windows.Forms.CheckBox checkProfesional;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCrit;
        private System.Windows.Forms.ComboBox comboBusqueda;
        private System.Windows.Forms.Panel pnlCrit;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBuscarTurnosDisp;
        private System.Windows.Forms.ComboBox comboBusqueda2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDeTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn horaDeInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn horaDeFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn llegada;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboAfiliado;
        private System.Windows.Forms.DataGridView gridBonosDisponibles;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnConfirmar;
    }
}