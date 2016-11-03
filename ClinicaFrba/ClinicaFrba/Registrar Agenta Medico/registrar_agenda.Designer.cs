namespace ClinicaFrba.Registrar_Agenta_Medico
{
    partial class registrar_agenda
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.agregar = new System.Windows.Forms.Button();
            this.confirmar = new System.Windows.Forms.Button();
            this.aceptar_dias = new System.Windows.Forms.Button();
            this.box_dias = new System.Windows.Forms.GroupBox();
            this.roles_cbx = new System.Windows.Forms.ComboBox();
            this.checkedlist_dia_sab = new System.Windows.Forms.CheckedListBox();
            this.checkedlist_dias = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.desde = new System.Windows.Forms.DateTimePicker();
            this.hasta = new System.Windows.Forms.DateTimePicker();
            this.aceptar_rango = new System.Windows.Forms.Button();
            this.box_rango = new System.Windows.Forms.GroupBox();
            this.box_fechas = new System.Windows.Forms.GroupBox();
            this.aceptar_fechas = new System.Windows.Forms.Button();
            this.hasta_fecha = new System.Windows.Forms.DateTimePicker();
            this.desde_fecha = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.box_rango_sab = new System.Windows.Forms.GroupBox();
            this.hasta_sab = new System.Windows.Forms.DateTimePicker();
            this.desde_sab = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.box_dias.SuspendLayout();
            this.box_rango.SuspendLayout();
            this.box_fechas.SuspendLayout();
            this.box_rango_sab.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.agregar);
            this.groupBox3.Controls.Add(this.confirmar);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 484);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(655, 69);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // agregar
            // 
            this.agregar.Enabled = false;
            this.agregar.Location = new System.Drawing.Point(362, 25);
            this.agregar.Name = "agregar";
            this.agregar.Size = new System.Drawing.Size(132, 32);
            this.agregar.TabIndex = 10;
            this.agregar.Text = "Agregar otra";
            this.agregar.UseVisualStyleBackColor = true;
            this.agregar.Click += new System.EventHandler(this.agregar_Click);
            // 
            // confirmar
            // 
            this.confirmar.Enabled = false;
            this.confirmar.Location = new System.Drawing.Point(511, 25);
            this.confirmar.Name = "confirmar";
            this.confirmar.Size = new System.Drawing.Size(132, 32);
            this.confirmar.TabIndex = 9;
            this.confirmar.Text = "Confirmar";
            this.confirmar.UseVisualStyleBackColor = true;
            this.confirmar.Click += new System.EventHandler(this.confirmar_Click);
            // 
            // aceptar_dias
            // 
            this.aceptar_dias.Location = new System.Drawing.Point(228, 140);
            this.aceptar_dias.Name = "aceptar_dias";
            this.aceptar_dias.Size = new System.Drawing.Size(192, 32);
            this.aceptar_dias.TabIndex = 5;
            this.aceptar_dias.Text = "Aceptar";
            this.aceptar_dias.UseVisualStyleBackColor = true;
            this.aceptar_dias.Click += new System.EventHandler(this.aceptar_dias_Click);
            // 
            // box_dias
            // 
            this.box_dias.Controls.Add(this.roles_cbx);
            this.box_dias.Controls.Add(this.checkedlist_dia_sab);
            this.box_dias.Controls.Add(this.aceptar_dias);
            this.box_dias.Controls.Add(this.checkedlist_dias);
            this.box_dias.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box_dias.Location = new System.Drawing.Point(12, 12);
            this.box_dias.Name = "box_dias";
            this.box_dias.Size = new System.Drawing.Size(655, 184);
            this.box_dias.TabIndex = 0;
            this.box_dias.TabStop = false;
            this.box_dias.Text = "Seleccione día/s";
            // 
            // roles_cbx
            // 
            this.roles_cbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roles_cbx.FormattingEnabled = true;
            this.roles_cbx.Location = new System.Drawing.Point(437, 25);
            this.roles_cbx.Name = "roles_cbx";
            this.roles_cbx.Size = new System.Drawing.Size(206, 26);
            this.roles_cbx.TabIndex = 12;
            // 
            // checkedlist_dia_sab
            // 
            this.checkedlist_dia_sab.CheckOnClick = true;
            this.checkedlist_dia_sab.FormattingEnabled = true;
            this.checkedlist_dia_sab.Items.AddRange(new object[] {
            "Sábado"});
            this.checkedlist_dia_sab.Location = new System.Drawing.Point(228, 25);
            this.checkedlist_dia_sab.Name = "checkedlist_dia_sab";
            this.checkedlist_dia_sab.Size = new System.Drawing.Size(185, 109);
            this.checkedlist_dia_sab.TabIndex = 6;
            // 
            // checkedlist_dias
            // 
            this.checkedlist_dias.CheckOnClick = true;
            this.checkedlist_dias.FormattingEnabled = true;
            this.checkedlist_dias.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miércoles",
            "Jueves",
            "Viernes"});
            this.checkedlist_dias.Location = new System.Drawing.Point(17, 25);
            this.checkedlist_dias.Name = "checkedlist_dias";
            this.checkedlist_dias.Size = new System.Drawing.Size(194, 109);
            this.checkedlist_dias.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Desde:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hasta:";
            // 
            // desde
            // 
            this.desde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.desde.Location = new System.Drawing.Point(10, 58);
            this.desde.Name = "desde";
            this.desde.ShowUpDown = true;
            this.desde.Size = new System.Drawing.Size(132, 26);
            this.desde.TabIndex = 3;
            // 
            // hasta
            // 
            this.hasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.hasta.Location = new System.Drawing.Point(170, 57);
            this.hasta.Name = "hasta";
            this.hasta.ShowUpDown = true;
            this.hasta.Size = new System.Drawing.Size(138, 26);
            this.hasta.TabIndex = 4;
            this.hasta.ValueChanged += new System.EventHandler(this.hasta_ValueChanged);
            // 
            // aceptar_rango
            // 
            this.aceptar_rango.Location = new System.Drawing.Point(240, 304);
            this.aceptar_rango.Name = "aceptar_rango";
            this.aceptar_rango.Size = new System.Drawing.Size(192, 32);
            this.aceptar_rango.TabIndex = 6;
            this.aceptar_rango.Text = "Aceptar ";
            this.aceptar_rango.UseVisualStyleBackColor = true;
            this.aceptar_rango.Visible = false;
            this.aceptar_rango.Click += new System.EventHandler(this.aceptar_rango_Click);
            // 
            // box_rango
            // 
            this.box_rango.Controls.Add(this.hasta);
            this.box_rango.Controls.Add(this.desde);
            this.box_rango.Controls.Add(this.label2);
            this.box_rango.Controls.Add(this.label1);
            this.box_rango.Enabled = false;
            this.box_rango.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box_rango.Location = new System.Drawing.Point(18, 202);
            this.box_rango.Name = "box_rango";
            this.box_rango.Size = new System.Drawing.Size(320, 96);
            this.box_rango.TabIndex = 1;
            this.box_rango.TabStop = false;
            this.box_rango.Text = "Seleccione rango horario de lun a vie";
            this.box_rango.Visible = false;
            // 
            // box_fechas
            // 
            this.box_fechas.Controls.Add(this.aceptar_fechas);
            this.box_fechas.Controls.Add(this.hasta_fecha);
            this.box_fechas.Controls.Add(this.desde_fecha);
            this.box_fechas.Controls.Add(this.label3);
            this.box_fechas.Controls.Add(this.label4);
            this.box_fechas.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box_fechas.Location = new System.Drawing.Point(12, 351);
            this.box_fechas.Name = "box_fechas";
            this.box_fechas.Size = new System.Drawing.Size(655, 126);
            this.box_fechas.TabIndex = 9;
            this.box_fechas.TabStop = false;
            this.box_fechas.Text = "Seleccione rango de fechas";
            this.box_fechas.Visible = false;
            // 
            // aceptar_fechas
            // 
            this.aceptar_fechas.Location = new System.Drawing.Point(228, 75);
            this.aceptar_fechas.Name = "aceptar_fechas";
            this.aceptar_fechas.Size = new System.Drawing.Size(192, 32);
            this.aceptar_fechas.TabIndex = 11;
            this.aceptar_fechas.Text = "Aceptar ";
            this.aceptar_fechas.UseVisualStyleBackColor = true;
            this.aceptar_fechas.Click += new System.EventHandler(this.aceptar_fechas_Click_1);
            // 
            // hasta_fecha
            // 
            this.hasta_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.hasta_fecha.Location = new System.Drawing.Point(344, 43);
            this.hasta_fecha.Name = "hasta_fecha";
            this.hasta_fecha.ShowUpDown = true;
            this.hasta_fecha.Size = new System.Drawing.Size(200, 26);
            this.hasta_fecha.TabIndex = 10;
            // 
            // desde_fecha
            // 
            this.desde_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.desde_fecha.Location = new System.Drawing.Point(101, 43);
            this.desde_fecha.Name = "desde_fecha";
            this.desde_fecha.ShowUpDown = true;
            this.desde_fecha.Size = new System.Drawing.Size(200, 26);
            this.desde_fecha.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(416, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Hasta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Desde:";
            // 
            // box_rango_sab
            // 
            this.box_rango_sab.Controls.Add(this.hasta_sab);
            this.box_rango_sab.Controls.Add(this.desde_sab);
            this.box_rango_sab.Controls.Add(this.label5);
            this.box_rango_sab.Controls.Add(this.label6);
            this.box_rango_sab.Enabled = false;
            this.box_rango_sab.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box_rango_sab.Location = new System.Drawing.Point(353, 202);
            this.box_rango_sab.Name = "box_rango_sab";
            this.box_rango_sab.Size = new System.Drawing.Size(320, 96);
            this.box_rango_sab.TabIndex = 8;
            this.box_rango_sab.TabStop = false;
            this.box_rango_sab.Text = "Seleccione rango horario del sabado";
            this.box_rango_sab.Visible = false;
            // 
            // hasta_sab
            // 
            this.hasta_sab.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.hasta_sab.Location = new System.Drawing.Point(170, 57);
            this.hasta_sab.Name = "hasta_sab";
            this.hasta_sab.ShowUpDown = true;
            this.hasta_sab.Size = new System.Drawing.Size(138, 26);
            this.hasta_sab.TabIndex = 4;
            // 
            // desde_sab
            // 
            this.desde_sab.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.desde_sab.Location = new System.Drawing.Point(10, 58);
            this.desde_sab.Name = "desde_sab";
            this.desde_sab.ShowUpDown = true;
            this.desde_sab.Size = new System.Drawing.Size(132, 26);
            this.desde_sab.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(206, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "Hasta:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 18);
            this.label6.TabIndex = 1;
            this.label6.Text = "Desde:";
            // 
            // registrar_agenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 571);
            this.Controls.Add(this.aceptar_rango);
            this.Controls.Add(this.box_fechas);
            this.Controls.Add(this.box_rango_sab);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.box_rango);
            this.Controls.Add(this.box_dias);
            this.Name = "registrar_agenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clinica FRBA - Registrar agenda profesional";
            this.groupBox3.ResumeLayout(false);
            this.box_dias.ResumeLayout(false);
            this.box_rango.ResumeLayout(false);
            this.box_rango.PerformLayout();
            this.box_fechas.ResumeLayout(false);
            this.box_fechas.PerformLayout();
            this.box_rango_sab.ResumeLayout(false);
            this.box_rango_sab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button confirmar;
        private System.Windows.Forms.Button aceptar_dias;
        private System.Windows.Forms.GroupBox box_dias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker desde;
        private System.Windows.Forms.DateTimePicker hasta;
        private System.Windows.Forms.Button aceptar_rango;
        private System.Windows.Forms.GroupBox box_rango;
        private System.Windows.Forms.GroupBox box_fechas;
        private System.Windows.Forms.Button aceptar_fechas;
        private System.Windows.Forms.DateTimePicker hasta_fecha;
        private System.Windows.Forms.DateTimePicker desde_fecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox box_rango_sab;
        private System.Windows.Forms.DateTimePicker hasta_sab;
        private System.Windows.Forms.DateTimePicker desde_sab;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox checkedlist_dia_sab;
        private System.Windows.Forms.CheckedListBox checkedlist_dias;
        private System.Windows.Forms.ComboBox roles_cbx;
        private System.Windows.Forms.Button agregar;
    }
}