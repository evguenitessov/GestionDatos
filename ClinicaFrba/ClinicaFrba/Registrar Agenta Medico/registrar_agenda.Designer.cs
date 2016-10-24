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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkedlist_dias = new System.Windows.Forms.CheckedListBox();
            this.box_rango = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.desde = new System.Windows.Forms.DateTimePicker();
            this.hasta = new System.Windows.Forms.DateTimePicker();
            this.aceptar_dias = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.aceptar_rango = new System.Windows.Forms.Button();
            this.atras = new System.Windows.Forms.Button();
            this.confirmar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.box_rango.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.aceptar_dias);
            this.groupBox1.Controls.Add(this.checkedlist_dias);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 224);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione día/s";
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
            this.checkedlist_dias.Location = new System.Drawing.Point(102, 36);
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
            this.box_rango.Location = new System.Drawing.Point(12, 242);
            this.box_rango.Name = "box_rango";
            this.box_rango.Size = new System.Drawing.Size(560, 153);
            this.box_rango.TabIndex = 1;
            this.box_rango.TabStop = false;
            this.box_rango.Text = "Seleccione rango horario";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Desde:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(367, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hasta:";
            // 
            // desde
            // 
            this.desde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.desde.Location = new System.Drawing.Point(52, 59);
            this.desde.Name = "desde";
            this.desde.ShowUpDown = true;
            this.desde.Size = new System.Drawing.Size(200, 26);
            this.desde.TabIndex = 3;
            // 
            // hasta
            // 
            this.hasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.hasta.Location = new System.Drawing.Point(295, 59);
            this.hasta.Name = "hasta";
            this.hasta.ShowUpDown = true;
            this.hasta.Size = new System.Drawing.Size(200, 26);
            this.hasta.TabIndex = 4;
            // 
            // aceptar_dias
            // 
            this.aceptar_dias.Location = new System.Drawing.Point(179, 172);
            this.aceptar_dias.Name = "aceptar_dias";
            this.aceptar_dias.Size = new System.Drawing.Size(192, 32);
            this.aceptar_dias.TabIndex = 5;
            this.aceptar_dias.Text = "Aceptar";
            this.aceptar_dias.UseVisualStyleBackColor = true;
            this.aceptar_dias.Click += new System.EventHandler(this.aceptar_dias_Click);
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
            // aceptar_rango
            // 
            this.aceptar_rango.Location = new System.Drawing.Point(179, 91);
            this.aceptar_rango.Name = "aceptar_rango";
            this.aceptar_rango.Size = new System.Drawing.Size(192, 32);
            this.aceptar_rango.TabIndex = 6;
            this.aceptar_rango.Text = "Aceptar ";
            this.aceptar_rango.UseVisualStyleBackColor = true;
            this.aceptar_rango.Click += new System.EventHandler(this.aceptar_rango_Click);
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
            // confirmar
            // 
            this.confirmar.Location = new System.Drawing.Point(362, 25);
            this.confirmar.Name = "confirmar";
            this.confirmar.Size = new System.Drawing.Size(192, 32);
            this.confirmar.TabIndex = 9;
            this.confirmar.Text = "Confirmar";
            this.confirmar.UseVisualStyleBackColor = true;
            // 
            // registrar_agenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.box_rango);
            this.Controls.Add(this.groupBox1);
            this.Name = "registrar_agenda";
            this.Text = "Clinica FRBA - Registrar agenda profesional";
            this.groupBox1.ResumeLayout(false);
            this.box_rango.ResumeLayout(false);
            this.box_rango.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
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
    }
}