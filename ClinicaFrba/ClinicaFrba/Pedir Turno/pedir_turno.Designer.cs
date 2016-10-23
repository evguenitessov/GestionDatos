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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.aceptar_especialidad = new System.Windows.Forms.Button();
            this.cbox_especialidades = new System.Windows.Forms.ComboBox();
            this.cbox_profesionales = new System.Windows.Forms.ComboBox();
            this.aceptar_profesional = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.atras = new System.Windows.Forms.Button();
            this.confirmar_turno = new System.Windows.Forms.Button();
            this.grid_fechas = new System.Windows.Forms.DataGridView();
            this.grid_horarios = new System.Windows.Forms.DataGridView();
            this.aceptar_fecha = new System.Windows.Forms.Button();
            this.elegir_fecha = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.elegir_horario = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.box_especialidad.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_fechas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_horarios)).BeginInit();
            this.SuspendLayout();
            // 
            // box_especialidad
            // 
            this.box_especialidad.Controls.Add(this.cbox_especialidades);
            this.box_especialidad.Controls.Add(this.aceptar_especialidad);
            this.box_especialidad.Controls.Add(this.label1);
            this.box_especialidad.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box_especialidad.Location = new System.Drawing.Point(12, 1);
            this.box_especialidad.Name = "box_especialidad";
            this.box_especialidad.Size = new System.Drawing.Size(560, 120);
            this.box_especialidad.TabIndex = 0;
            this.box_especialidad.TabStop = false;
            this.box_especialidad.Text = "Seleccione especialidad";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbox_profesionales);
            this.groupBox2.Controls.Add(this.aceptar_profesional);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 122);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seleccione profesional";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.confirmar_turno);
            this.groupBox3.Controls.Add(this.grid_horarios);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(294, 255);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(278, 249);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Seleccione UN horario";
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
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.aceptar_fecha);
            this.groupBox5.Controls.Add(this.grid_fechas);
            this.groupBox5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(12, 255);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(276, 249);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Seleccione UNA fecha";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(206, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Especialidades Médicas";
            // 
            // aceptar_especialidad
            // 
            this.aceptar_especialidad.Location = new System.Drawing.Point(183, 75);
            this.aceptar_especialidad.Name = "aceptar_especialidad";
            this.aceptar_especialidad.Size = new System.Drawing.Size(192, 32);
            this.aceptar_especialidad.TabIndex = 1;
            this.aceptar_especialidad.Text = "Aceptar";
            this.aceptar_especialidad.UseVisualStyleBackColor = true;
            // 
            // cbox_especialidades
            // 
            this.cbox_especialidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_especialidades.FormattingEnabled = true;
            this.cbox_especialidades.Location = new System.Drawing.Point(183, 43);
            this.cbox_especialidades.Name = "cbox_especialidades";
            this.cbox_especialidades.Size = new System.Drawing.Size(192, 26);
            this.cbox_especialidades.TabIndex = 2;
            // 
            // cbox_profesionales
            // 
            this.cbox_profesionales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_profesionales.FormattingEnabled = true;
            this.cbox_profesionales.Location = new System.Drawing.Point(183, 43);
            this.cbox_profesionales.Name = "cbox_profesionales";
            this.cbox_profesionales.Size = new System.Drawing.Size(192, 26);
            this.cbox_profesionales.TabIndex = 5;
            // 
            // aceptar_profesional
            // 
            this.aceptar_profesional.Location = new System.Drawing.Point(183, 75);
            this.aceptar_profesional.Name = "aceptar_profesional";
            this.aceptar_profesional.Size = new System.Drawing.Size(192, 32);
            this.aceptar_profesional.TabIndex = 4;
            this.aceptar_profesional.Text = "Aceptar";
            this.aceptar_profesional.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Profesionales";
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
            // confirmar_turno
            // 
            this.confirmar_turno.Location = new System.Drawing.Point(39, 209);
            this.confirmar_turno.Name = "confirmar_turno";
            this.confirmar_turno.Size = new System.Drawing.Size(192, 32);
            this.confirmar_turno.TabIndex = 7;
            this.confirmar_turno.Text = "Confirmar Turno";
            this.confirmar_turno.UseVisualStyleBackColor = true;
            // 
            // grid_fechas
            // 
            this.grid_fechas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_fechas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.elegir_fecha});
            this.grid_fechas.Location = new System.Drawing.Point(6, 25);
            this.grid_fechas.Name = "grid_fechas";
            this.grid_fechas.Size = new System.Drawing.Size(259, 178);
            this.grid_fechas.TabIndex = 2;
            // 
            // grid_horarios
            // 
            this.grid_horarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_horarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.elegir_horario});
            this.grid_horarios.Location = new System.Drawing.Point(6, 25);
            this.grid_horarios.Name = "grid_horarios";
            this.grid_horarios.Size = new System.Drawing.Size(259, 178);
            this.grid_horarios.TabIndex = 3;
            // 
            // aceptar_fecha
            // 
            this.aceptar_fecha.Location = new System.Drawing.Point(42, 209);
            this.aceptar_fecha.Name = "aceptar_fecha";
            this.aceptar_fecha.Size = new System.Drawing.Size(192, 32);
            this.aceptar_fecha.TabIndex = 6;
            this.aceptar_fecha.Text = "Aceptar";
            this.aceptar_fecha.UseVisualStyleBackColor = true;
            // 
            // elegir_fecha
            // 
            this.elegir_fecha.HeaderText = "Seleccionar";
            this.elegir_fecha.Name = "elegir_fecha";
            // 
            // elegir_horario
            // 
            this.elegir_horario.HeaderText = "Seleccionar";
            this.elegir_horario.Name = "elegir_horario";
            // 
            // pedir_turno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.box_especialidad);
            this.Name = "pedir_turno";
            this.Text = "Clinica FRBA - Solicitud de turno";
            this.box_especialidad.ResumeLayout(false);
            this.box_especialidad.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_fechas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_horarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox box_especialidad;
        private System.Windows.Forms.ComboBox cbox_especialidades;
        private System.Windows.Forms.Button aceptar_especialidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbox_profesionales;
        private System.Windows.Forms.Button aceptar_profesional;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button confirmar_turno;
        private System.Windows.Forms.DataGridView grid_horarios;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button atras;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button aceptar_fecha;
        private System.Windows.Forms.DataGridView grid_fechas;
        private System.Windows.Forms.DataGridViewCheckBoxColumn elegir_horario;
        private System.Windows.Forms.DataGridViewCheckBoxColumn elegir_fecha;
    }
}