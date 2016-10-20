namespace ClinicaFrba.Pedir_Turno
{
    partial class pedido_turno
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
            this.label1 = new System.Windows.Forms.Label();
            this.especialidades = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bot_confirmar = new System.Windows.Forms.Button();
            this.bot_buscar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.fechas = new System.Windows.Forms.DataGridView();
            this.horarios = new System.Windows.Forms.DataGridView();
            this.selec_fecha = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.selec_horarios = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bot_atras = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fechas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horarios)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bot_buscar);
            this.groupBox1.Controls.Add(this.especialidades);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 124);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccionar especialidad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F);
            this.label1.Location = new System.Drawing.Point(228, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Especialidades";
            // 
            // especialidades
            // 
            this.especialidades.FormattingEnabled = true;
            this.especialidades.Location = new System.Drawing.Point(165, 48);
            this.especialidades.Name = "especialidades";
            this.especialidades.Size = new System.Drawing.Size(231, 27);
            this.especialidades.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bot_atras);
            this.groupBox2.Controls.Add(this.bot_confirmar);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.groupBox2.Location = new System.Drawing.Point(12, 468);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 85);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // bot_confirmar
            // 
            this.bot_confirmar.Location = new System.Drawing.Point(284, 25);
            this.bot_confirmar.Name = "bot_confirmar";
            this.bot_confirmar.Size = new System.Drawing.Size(270, 40);
            this.bot_confirmar.TabIndex = 12;
            this.bot_confirmar.Text = "Confirmar turno";
            this.bot_confirmar.UseVisualStyleBackColor = true;
            // 
            // bot_buscar
            // 
            this.bot_buscar.Location = new System.Drawing.Point(165, 81);
            this.bot_buscar.Name = "bot_buscar";
            this.bot_buscar.Size = new System.Drawing.Size(231, 33);
            this.bot_buscar.TabIndex = 14;
            this.bot_buscar.Text = "Ok";
            this.bot_buscar.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 131);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(560, 124);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Seleccionar profesional";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(165, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(231, 33);
            this.button1.TabIndex = 14;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(165, 48);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(231, 27);
            this.comboBox1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F);
            this.label3.Location = new System.Drawing.Point(236, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Profesionales";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.fechas);
            this.groupBox4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 261);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(278, 211);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Seleccionar fecha";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.horarios);
            this.groupBox5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(296, 261);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(278, 211);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Seleccionar horario";
            // 
            // fechas
            // 
            this.fechas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fechas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selec_fecha});
            this.fechas.Location = new System.Drawing.Point(6, 26);
            this.fechas.Name = "fechas";
            this.fechas.Size = new System.Drawing.Size(266, 179);
            this.fechas.TabIndex = 15;
            // 
            // horarios
            // 
            this.horarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.horarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selec_horarios});
            this.horarios.Location = new System.Drawing.Point(4, 26);
            this.horarios.Name = "horarios";
            this.horarios.Size = new System.Drawing.Size(266, 179);
            this.horarios.TabIndex = 16;
            // 
            // selec_fecha
            // 
            this.selec_fecha.HeaderText = "Seleccionar";
            this.selec_fecha.Name = "selec_fecha";
            // 
            // selec_horarios
            // 
            this.selec_horarios.HeaderText = "Seleccionar";
            this.selec_horarios.Name = "selec_horarios";
            // 
            // bot_atras
            // 
            this.bot_atras.Location = new System.Drawing.Point(6, 25);
            this.bot_atras.Name = "bot_atras";
            this.bot_atras.Size = new System.Drawing.Size(272, 40);
            this.bot_atras.TabIndex = 13;
            this.bot_atras.Text = "Atrás";
            this.bot_atras.UseVisualStyleBackColor = true;
            // 
            // pedido_turno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "pedido_turno";
            this.Text = "Clinica FRBA - Pedido de turno";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fechas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.horarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox especialidades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bot_buscar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bot_confirmar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView fechas;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selec_fecha;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView horarios;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selec_horarios;
        private System.Windows.Forms.Button bot_atras;
    }
}