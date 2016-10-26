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
            this.box_dias = new System.Windows.Forms.GroupBox();
            this.aceptar_dias = new System.Windows.Forms.Button();
            this.checkedlist_dias = new System.Windows.Forms.CheckedListBox();
            this.box_rango = new System.Windows.Forms.GroupBox();
            this.aceptar_rango = new System.Windows.Forms.Button();
            this.hasta = new System.Windows.Forms.DateTimePicker();
            this.desde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.confirmar = new System.Windows.Forms.Button();
            this.atras = new System.Windows.Forms.Button();
            this.box_fechas = new System.Windows.Forms.GroupBox();
            this.aceptar_fechas = new System.Windows.Forms.Button();
            this.hasta_fecha = new System.Windows.Forms.DateTimePicker();
            this.desde_fecha = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.box_dias.SuspendLayout();
            this.box_rango.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.box_fechas.SuspendLayout();
            this.SuspendLayout();
            // 
            // box_dias
            // 
            this.box_dias.Controls.Add(this.aceptar_dias);
            this.box_dias.Controls.Add(this.checkedlist_dias);
            this.box_dias.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box_dias.Location = new System.Drawing.Point(12, 133);
            this.box_dias.Name = "box_dias";
            this.box_dias.Size = new System.Drawing.Size(560, 208);
            this.box_dias.TabIndex = 0;
            this.box_dias.TabStop = false;
            this.box_dias.Text = "Seleccione día/s";
            // 
            // aceptar_dias
            // 
            this.aceptar_dias.Location = new System.Drawing.Point(184, 161);
            this.aceptar_dias.Name = "aceptar_dias";
            this.aceptar_dias.Size = new System.Drawing.Size(192, 32);
            this.aceptar_dias.TabIndex = 5;
            this.aceptar_dias.Text = "Aceptar";
            this.aceptar_dias.UseVisualStyleBackColor = true;
            this.aceptar_dias.Click += new System.EventHandler(this.aceptar_dias_Click);
            // 
            // checkedlist_dias
            // 
            this.checkedlist_dias.FormattingEnabled = true;
            this.checkedlist_dias.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miércoles",
            "Jueves",
            "Viernes",
            "Sábado"});
            this.checkedlist_dias.Location = new System.Drawing.Point(107, 25);
            this.checkedlist_dias.Name = "checkedlist_dias";
            this.checkedlist_dias.Size = new System.Drawing.Size(340, 130);
            this.checkedlist_dias.TabIndex = 0;
            // 
            // box_rango
            // 
            this.box_rango.Controls.Add(this.aceptar_rango);
            this.box_rango.Controls.Add(this.hasta);
            this.box_rango.Controls.Add(this.desde);
            this.box_rango.Controls.Add(this.label2);
            this.box_rango.Controls.Add(this.label1);
            this.box_rango.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box_rango.Location = new System.Drawing.Point(12, 347);
            this.box_rango.Name = "box_rango";
            this.box_rango.Size = new System.Drawing.Size(560, 127);
            this.box_rango.TabIndex = 1;
            this.box_rango.TabStop = false;
            this.box_rango.Text = "Seleccione rango horario";
            // 
            // aceptar_rango
            // 
            this.aceptar_rango.Location = new System.Drawing.Point(179, 81);
            this.aceptar_rango.Name = "aceptar_rango";
            this.aceptar_rango.Size = new System.Drawing.Size(192, 32);
            this.aceptar_rango.TabIndex = 6;
            this.aceptar_rango.Text = "Aceptar ";
            this.aceptar_rango.UseVisualStyleBackColor = true;
            this.aceptar_rango.Click += new System.EventHandler(this.aceptar_rango_Click);
            // 
            // hasta
            // 
            this.hasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.hasta.Location = new System.Drawing.Point(295, 49);
            this.hasta.Name = "hasta";
            this.hasta.ShowUpDown = true;
            this.hasta.Size = new System.Drawing.Size(200, 26);
            this.hasta.TabIndex = 4;
            // 
            // desde
            // 
            this.desde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.desde.Location = new System.Drawing.Point(52, 49);
            this.desde.Name = "desde";
            this.desde.ShowUpDown = true;
            this.desde.Size = new System.Drawing.Size(200, 26);
            this.desde.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(367, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Desde:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.confirmar);
            this.groupBox3.Controls.Add(this.atras);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 474);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(560, 75);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // confirmar
            // 
            this.confirmar.Location = new System.Drawing.Point(362, 25);
            this.confirmar.Name = "confirmar";
            this.confirmar.Size = new System.Drawing.Size(192, 32);
            this.confirmar.TabIndex = 9;
            this.confirmar.Text = "Confirmar";
            this.confirmar.UseVisualStyleBackColor = true;
            this.confirmar.Click += new System.EventHandler(this.confirmar_Click);
            // 
            // atras
            // 
            this.atras.Location = new System.Drawing.Point(6, 25);
            this.atras.Name = "atras";
            this.atras.Size = new System.Drawing.Size(192, 32);
            this.atras.TabIndex = 8;
            this.atras.Text = "Atrás";
            this.atras.UseVisualStyleBackColor = true;
            // 
            // box_fechas
            // 
            this.box_fechas.Controls.Add(this.aceptar_fechas);
            this.box_fechas.Controls.Add(this.hasta_fecha);
            this.box_fechas.Controls.Add(this.desde_fecha);
            this.box_fechas.Controls.Add(this.label3);
            this.box_fechas.Controls.Add(this.label4);
            this.box_fechas.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box_fechas.Location = new System.Drawing.Point(12, 1);
            this.box_fechas.Name = "box_fechas";
            this.box_fechas.Size = new System.Drawing.Size(560, 126);
            this.box_fechas.TabIndex = 6;
            this.box_fechas.TabStop = false;
            this.box_fechas.Text = "Seleccione rango de fechas";
            // 
            // aceptar_fechas
            // 
            this.aceptar_fechas.Location = new System.Drawing.Point(179, 80);
            this.aceptar_fechas.Name = "aceptar_fechas";
            this.aceptar_fechas.Size = new System.Drawing.Size(192, 32);
            this.aceptar_fechas.TabIndex = 11;
            this.aceptar_fechas.Text = "Aceptar ";
            this.aceptar_fechas.UseVisualStyleBackColor = true;
            this.aceptar_fechas.Click += new System.EventHandler(this.aceptar_fechas_Click);
            // 
            // hasta_fecha
            // 
            this.hasta_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.hasta_fecha.Location = new System.Drawing.Point(295, 48);
            this.hasta_fecha.Name = "hasta_fecha";
            this.hasta_fecha.ShowUpDown = true;
            this.hasta_fecha.Size = new System.Drawing.Size(200, 26);
            this.hasta_fecha.TabIndex = 10;
            // 
            // desde_fecha
            // 
            this.desde_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.desde_fecha.Location = new System.Drawing.Point(52, 48);
            this.desde_fecha.Name = "desde_fecha";
            this.desde_fecha.ShowUpDown = true;
            this.desde_fecha.Size = new System.Drawing.Size(200, 26);
            this.desde_fecha.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(367, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Hasta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(118, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Desde:";
            // 
            // registrar_agenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.box_fechas);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.box_rango);
            this.Controls.Add(this.box_dias);
            this.Name = "registrar_agenda";
            this.Text = "Clinica FRBA - Registrar agenda profesional";
            this.box_dias.ResumeLayout(false);
            this.box_rango.ResumeLayout(false);
            this.box_rango.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.box_fechas.ResumeLayout(false);
            this.box_fechas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox box_dias;
        private System.Windows.Forms.CheckedListBox checkedlist_dias;
        private System.Windows.Forms.GroupBox box_rango;
        private System.Windows.Forms.DateTimePicker hasta;
        private System.Windows.Forms.DateTimePicker desde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button aceptar_dias;
        private System.Windows.Forms.Button aceptar_rango;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button atras;
        private System.Windows.Forms.Button confirmar;
        private System.Windows.Forms.GroupBox box_fechas;
        private System.Windows.Forms.Button aceptar_fechas;
        private System.Windows.Forms.DateTimePicker hasta_fecha;
        private System.Windows.Forms.DateTimePicker desde_fecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}