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
            this.cmdBusqueda = new System.Windows.Forms.ComboBox();
            this.btnCrit = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.checkProfesional = new System.Windows.Forms.CheckBox();
            this.checkEspecialidad = new System.Windows.Forms.CheckBox();
            this.pnlCrit = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.pnlCrit.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlCrit);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.btnCrit);
            this.groupBox1.Controls.Add(this.cmdBusqueda);
            this.groupBox1.Location = new System.Drawing.Point(95, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 75);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Búsqueda por Profesional";
            // 
            // cmdBusqueda
            // 
            this.cmdBusqueda.FormattingEnabled = true;
            this.cmdBusqueda.Location = new System.Drawing.Point(6, 29);
            this.cmdBusqueda.Name = "cmdBusqueda";
            this.cmdBusqueda.Size = new System.Drawing.Size(151, 21);
            this.cmdBusqueda.TabIndex = 1;
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
            // pnlCrit
            // 
            this.pnlCrit.Controls.Add(this.checkProfesional);
            this.pnlCrit.Controls.Add(this.checkEspecialidad);
            this.pnlCrit.Location = new System.Drawing.Point(273, 14);
            this.pnlCrit.Name = "pnlCrit";
            this.pnlCrit.Size = new System.Drawing.Size(92, 49);
            this.pnlCrit.TabIndex = 1;
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
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Location = new System.Drawing.Point(144, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(305, 75);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seleccionar Especialidad";
            this.groupBox2.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(163, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(151, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // registrar_llegada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkEspecialidad;
        private System.Windows.Forms.CheckBox checkProfesional;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCrit;
        private System.Windows.Forms.ComboBox cmdBusqueda;
        private System.Windows.Forms.Panel pnlCrit;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}