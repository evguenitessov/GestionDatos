namespace ClinicaFrba.Cancelar_Atencion
{
    partial class cancelarAtencion
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
            this.profesional_grbx = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.aceptar_fechas = new System.Windows.Forms.Button();
            this.desde_fecha = new System.Windows.Forms.DateTimePicker();
            this.hasta_fecha = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.agenda_dgrvw = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.detalle_txbx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tipo_cancel_txbx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.afiliado_grbx = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.turnos_dgrvw = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.profesional_grbx.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agenda_dgrvw)).BeginInit();
            this.afiliado_grbx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.turnos_dgrvw)).BeginInit();
            this.SuspendLayout();
            // 
            // profesional_grbx
            // 
            this.profesional_grbx.Controls.Add(this.groupBox2);
            this.profesional_grbx.Controls.Add(this.groupBox1);
            this.profesional_grbx.Controls.Add(this.detalle_txbx);
            this.profesional_grbx.Controls.Add(this.label2);
            this.profesional_grbx.Controls.Add(this.tipo_cancel_txbx);
            this.profesional_grbx.Controls.Add(this.label1);
            this.profesional_grbx.Location = new System.Drawing.Point(12, 12);
            this.profesional_grbx.Name = "profesional_grbx";
            this.profesional_grbx.Size = new System.Drawing.Size(725, 484);
            this.profesional_grbx.TabIndex = 1;
            this.profesional_grbx.TabStop = false;
            this.profesional_grbx.Text = "Candelacion del Profesional";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.aceptar_fechas);
            this.groupBox2.Controls.Add(this.desde_fecha);
            this.groupBox2.Controls.Add(this.hasta_fecha);
            this.groupBox2.Location = new System.Drawing.Point(17, 343);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(696, 136);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cancelar período";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(181, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Desde:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(341, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Hasta:";
            // 
            // aceptar_fechas
            // 
            this.aceptar_fechas.Location = new System.Drawing.Point(195, 81);
            this.aceptar_fechas.Name = "aceptar_fechas";
            this.aceptar_fechas.Size = new System.Drawing.Size(192, 32);
            this.aceptar_fechas.TabIndex = 16;
            this.aceptar_fechas.Text = "Cancelar período";
            this.aceptar_fechas.UseVisualStyleBackColor = true;
            this.aceptar_fechas.Click += new System.EventHandler(this.aceptar_fechas_Click);
            // 
            // desde_fecha
            // 
            this.desde_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.desde_fecha.Location = new System.Drawing.Point(156, 49);
            this.desde_fecha.Name = "desde_fecha";
            this.desde_fecha.ShowUpDown = true;
            this.desde_fecha.Size = new System.Drawing.Size(131, 20);
            this.desde_fecha.TabIndex = 14;
            // 
            // hasta_fecha
            // 
            this.hasta_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.hasta_fecha.Location = new System.Drawing.Point(305, 49);
            this.hasta_fecha.Name = "hasta_fecha";
            this.hasta_fecha.ShowUpDown = true;
            this.hasta_fecha.Size = new System.Drawing.Size(125, 20);
            this.hasta_fecha.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.agenda_dgrvw);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(17, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(702, 228);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cancelar un dia de la agenda";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // agenda_dgrvw
            // 
            this.agenda_dgrvw.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.agenda_dgrvw.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.agenda_dgrvw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.agenda_dgrvw.Location = new System.Drawing.Point(15, 19);
            this.agenda_dgrvw.MultiSelect = false;
            this.agenda_dgrvw.Name = "agenda_dgrvw";
            this.agenda_dgrvw.Size = new System.Drawing.Size(681, 148);
            this.agenda_dgrvw.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(567, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 39);
            this.button1.TabIndex = 5;
            this.button1.Text = "Cancelar día";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // detalle_txbx
            // 
            this.detalle_txbx.Location = new System.Drawing.Point(164, 72);
            this.detalle_txbx.Name = "detalle_txbx";
            this.detalle_txbx.Size = new System.Drawing.Size(324, 20);
            this.detalle_txbx.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Detalle de cancelación:";
            // 
            // tipo_cancel_txbx
            // 
            this.tipo_cancel_txbx.Location = new System.Drawing.Point(164, 34);
            this.tipo_cancel_txbx.Name = "tipo_cancel_txbx";
            this.tipo_cancel_txbx.Size = new System.Drawing.Size(324, 20);
            this.tipo_cancel_txbx.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de cancelación:";
            // 
            // afiliado_grbx
            // 
            this.afiliado_grbx.Controls.Add(this.button2);
            this.afiliado_grbx.Controls.Add(this.turnos_dgrvw);
            this.afiliado_grbx.Controls.Add(this.textBox1);
            this.afiliado_grbx.Controls.Add(this.label3);
            this.afiliado_grbx.Controls.Add(this.textBox2);
            this.afiliado_grbx.Controls.Add(this.label6);
            this.afiliado_grbx.Location = new System.Drawing.Point(35, 7);
            this.afiliado_grbx.Name = "afiliado_grbx";
            this.afiliado_grbx.Size = new System.Drawing.Size(939, 484);
            this.afiliado_grbx.TabIndex = 2;
            this.afiliado_grbx.TabStop = false;
            this.afiliado_grbx.Text = "Candelacion del Afiliado";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(791, 424);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 39);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancelar turno";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // turnos_dgrvw
            // 
            this.turnos_dgrvw.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.turnos_dgrvw.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.turnos_dgrvw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.turnos_dgrvw.Location = new System.Drawing.Point(27, 109);
            this.turnos_dgrvw.MultiSelect = false;
            this.turnos_dgrvw.Name = "turnos_dgrvw";
            this.turnos_dgrvw.Size = new System.Drawing.Size(893, 291);
            this.turnos_dgrvw.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(164, 72);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(336, 20);
            this.textBox1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Detalle de cancelación:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(164, 34);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(336, 20);
            this.textBox2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tipo de cancelación:";
            // 
            // cancelarAtencion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 507);
            this.Controls.Add(this.afiliado_grbx);
            this.Controls.Add(this.profesional_grbx);
            this.Name = "cancelarAtencion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cancelar Atencion Médica";
            this.profesional_grbx.ResumeLayout(false);
            this.profesional_grbx.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.agenda_dgrvw)).EndInit();
            this.afiliado_grbx.ResumeLayout(false);
            this.afiliado_grbx.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.turnos_dgrvw)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox profesional_grbx;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView agenda_dgrvw;
        private System.Windows.Forms.TextBox detalle_txbx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tipo_cancel_txbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button aceptar_fechas;
        private System.Windows.Forms.DateTimePicker hasta_fecha;
        private System.Windows.Forms.DateTimePicker desde_fecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox afiliado_grbx;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView turnos_dgrvw;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;

    }
}