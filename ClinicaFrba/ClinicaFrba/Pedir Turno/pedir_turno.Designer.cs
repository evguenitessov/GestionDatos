namespace ClinicaFrba.Pedir_Turno
{
    partial class pedir_turno
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
            this.box_especialidad = new System.Windows.Forms.GroupBox();
            this.combo_especialidades = new System.Windows.Forms.ComboBox();
            this.aceptar_espec = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.profesional = new System.Windows.Forms.GroupBox();
            this.combo_profesionales = new System.Windows.Forms.ComboBox();
            this.aceptar_profesional = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.atras = new System.Windows.Forms.Button();
            this.fecha = new System.Windows.Forms.GroupBox();
            this.aceptar_fecha = new System.Windows.Forms.Button();
            this.grid_fechas = new System.Windows.Forms.DataGridView();
            this.elegir_fecha = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.box_especialidad.SuspendLayout();
            this.profesional.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.fecha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_fechas)).BeginInit();
            this.SuspendLayout();
            // 
            // box_especialidad
            // 
            this.box_especialidad.Controls.Add(this.combo_especialidades);
            this.box_especialidad.Controls.Add(this.aceptar_espec);
            this.box_especialidad.Controls.Add(this.label1);
            this.box_especialidad.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box_especialidad.Location = new System.Drawing.Point(12, 1);
            this.box_especialidad.Name = "box_especialidad";
            this.box_especialidad.Size = new System.Drawing.Size(560, 120);
            this.box_especialidad.TabIndex = 0;
            this.box_especialidad.TabStop = false;
            this.box_especialidad.Text = "Seleccione especialidad";
            // 
            // combo_especialidades
            // 
            this.combo_especialidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_especialidades.FormattingEnabled = true;
            this.combo_especialidades.Location = new System.Drawing.Point(190, 43);
            this.combo_especialidades.Name = "combo_especialidades";
            this.combo_especialidades.Size = new System.Drawing.Size(192, 26);
            this.combo_especialidades.TabIndex = 2;
            // 
            // aceptar_espec
            // 
            this.aceptar_espec.Location = new System.Drawing.Point(190, 75);
            this.aceptar_espec.Name = "aceptar_espec";
            this.aceptar_espec.Size = new System.Drawing.Size(192, 32);
            this.aceptar_espec.TabIndex = 1;
            this.aceptar_espec.Text = "Aceptar";
            this.aceptar_espec.UseVisualStyleBackColor = true;
            this.aceptar_espec.Click += new System.EventHandler(this.aceptar_espec_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Especialidades Médicas";
            // 
            // profesional
            // 
            this.profesional.Controls.Add(this.combo_profesionales);
            this.profesional.Controls.Add(this.aceptar_profesional);
            this.profesional.Controls.Add(this.label2);
            this.profesional.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profesional.Location = new System.Drawing.Point(12, 127);
            this.profesional.Name = "profesional";
            this.profesional.Size = new System.Drawing.Size(560, 122);
            this.profesional.TabIndex = 1;
            this.profesional.TabStop = false;
            this.profesional.Text = "Seleccione profesional";
            // 
            // combo_profesionales
            // 
            this.combo_profesionales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_profesionales.FormattingEnabled = true;
            this.combo_profesionales.Location = new System.Drawing.Point(191, 43);
            this.combo_profesionales.Name = "combo_profesionales";
            this.combo_profesionales.Size = new System.Drawing.Size(192, 26);
            this.combo_profesionales.TabIndex = 5;
            // 
            // aceptar_profesional
            // 
            this.aceptar_profesional.Location = new System.Drawing.Point(191, 75);
            this.aceptar_profesional.Name = "aceptar_profesional";
            this.aceptar_profesional.Size = new System.Drawing.Size(192, 32);
            this.aceptar_profesional.TabIndex = 4;
            this.aceptar_profesional.Text = "Aceptar";
            this.aceptar_profesional.UseVisualStyleBackColor = true;
            this.aceptar_profesional.Click += new System.EventHandler(this.aceptar_profesional_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Profesionales";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.atras);
            this.groupBox4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 506);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(560, 53);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // atras
            // 
            this.atras.Location = new System.Drawing.Point(183, 15);
            this.atras.Name = "atras";
            this.atras.Size = new System.Drawing.Size(192, 32);
            this.atras.TabIndex = 6;
            this.atras.Text = "Atrás";
            this.atras.UseVisualStyleBackColor = true;
            // 
            // fecha
            // 
            this.fecha.Controls.Add(this.aceptar_fecha);
            this.fecha.Controls.Add(this.grid_fechas);
            this.fecha.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fecha.Location = new System.Drawing.Point(12, 255);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(560, 249);
            this.fecha.TabIndex = 1;
            this.fecha.TabStop = false;
            this.fecha.Text = "Seleccione UNA fecha y horario";
            // 
            // aceptar_fecha
            // 
            this.aceptar_fecha.Location = new System.Drawing.Point(183, 209);
            this.aceptar_fecha.Name = "aceptar_fecha";
            this.aceptar_fecha.Size = new System.Drawing.Size(192, 32);
            this.aceptar_fecha.TabIndex = 6;
            this.aceptar_fecha.Text = "Confirmar turno";
            this.aceptar_fecha.UseVisualStyleBackColor = true;
            this.aceptar_fecha.Click += new System.EventHandler(this.aceptar_fecha_Click_1);
            // 
            // grid_fechas
            // 
            this.grid_fechas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_fechas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.elegir_fecha});
            this.grid_fechas.Location = new System.Drawing.Point(6, 25);
            this.grid_fechas.Name = "grid_fechas";
            this.grid_fechas.Size = new System.Drawing.Size(548, 178);
            this.grid_fechas.TabIndex = 2;
            // 
            // elegir_fecha
            // 
            this.elegir_fecha.HeaderText = "Seleccionar";
            this.elegir_fecha.Name = "elegir_fecha";
            // 
            // pedir_turno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.profesional);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.box_especialidad);
            this.Name = "pedir_turno";
            this.Text = "Clinica FRBA - Solicitud de turno";
            this.box_especialidad.ResumeLayout(false);
            this.box_especialidad.PerformLayout();
            this.profesional.ResumeLayout(false);
            this.profesional.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.fecha.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_fechas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox box_especialidad;
        private System.Windows.Forms.ComboBox combo_especialidades;
        private System.Windows.Forms.Button aceptar_espec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox profesional;
        private System.Windows.Forms.ComboBox combo_profesionales;
        private System.Windows.Forms.Button aceptar_profesional;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button atras;
        private System.Windows.Forms.GroupBox fecha;
        private System.Windows.Forms.Button aceptar_fecha;
        private System.Windows.Forms.DataGridView grid_fechas;
        private System.Windows.Forms.DataGridViewCheckBoxColumn elegir_fecha;
    }
}