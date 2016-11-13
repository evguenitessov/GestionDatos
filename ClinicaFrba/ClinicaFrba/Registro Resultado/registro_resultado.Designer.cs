namespace ClinicaFrba.Registro_Resultado
{
    partial class registro_resultado
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
            this.groupBox_fechahora = new System.Windows.Forms.GroupBox();
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.hora = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_confirmar = new System.Windows.Forms.Button();
            this.groupBox_diag = new System.Windows.Forms.GroupBox();
            this.textBox_diag = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox_atras = new System.Windows.Forms.GroupBox();
            this.button_atras = new System.Windows.Forms.Button();
            this.groupBox_fechahora.SuspendLayout();
            this.groupBox_diag.SuspendLayout();
            this.groupBox_atras.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_fechahora
            // 
            this.groupBox_fechahora.Controls.Add(this.button_confirmar);
            this.groupBox_fechahora.Controls.Add(this.label2);
            this.groupBox_fechahora.Controls.Add(this.label1);
            this.groupBox_fechahora.Controls.Add(this.hora);
            this.groupBox_fechahora.Controls.Add(this.fecha);
            this.groupBox_fechahora.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_fechahora.Location = new System.Drawing.Point(12, 12);
            this.groupBox_fechahora.Name = "groupBox_fechahora";
            this.groupBox_fechahora.Size = new System.Drawing.Size(560, 206);
            this.groupBox_fechahora.TabIndex = 0;
            this.groupBox_fechahora.TabStop = false;
            this.groupBox_fechahora.Text = "Confirmar fecha y hora de atención médica";
            // 
            // fecha
            // 
            this.fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha.Location = new System.Drawing.Point(182, 63);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(200, 26);
            this.fecha.TabIndex = 0;
            // 
            // hora
            // 
            this.hora.CustomFormat = "HH:mm";
            this.hora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.hora.Location = new System.Drawing.Point(182, 113);
            this.hora.Name = "hora";
            this.hora.ShowUpDown = true;
            this.hora.Size = new System.Drawing.Size(200, 26);
            this.hora.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(260, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hora";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha ";
            // 
            // button_confirmar
            // 
            this.button_confirmar.Location = new System.Drawing.Point(182, 145);
            this.button_confirmar.Name = "button_confirmar";
            this.button_confirmar.Size = new System.Drawing.Size(200, 36);
            this.button_confirmar.TabIndex = 4;
            this.button_confirmar.Text = "Confirmar";
            this.button_confirmar.UseVisualStyleBackColor = true;
            this.button_confirmar.Click += new System.EventHandler(this.button_confirmar_Click);
            // 
            // groupBox_diag
            // 
            this.groupBox_diag.Controls.Add(this.button1);
            this.groupBox_diag.Controls.Add(this.textBox_diag);
            this.groupBox_diag.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_diag.Location = new System.Drawing.Point(12, 224);
            this.groupBox_diag.Name = "groupBox_diag";
            this.groupBox_diag.Size = new System.Drawing.Size(560, 250);
            this.groupBox_diag.TabIndex = 5;
            this.groupBox_diag.TabStop = false;
            this.groupBox_diag.Text = "Diagnóstico";
            // 
            // textBox_diag
            // 
            this.textBox_diag.Location = new System.Drawing.Point(91, 25);
            this.textBox_diag.Multiline = true;
            this.textBox_diag.Name = "textBox_diag";
            this.textBox_diag.Size = new System.Drawing.Size(390, 165);
            this.textBox_diag.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(182, 196);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 36);
            this.button1.TabIndex = 5;
            this.button1.Text = "Confirmar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox_atras
            // 
            this.groupBox_atras.Controls.Add(this.button_atras);
            this.groupBox_atras.Location = new System.Drawing.Point(12, 480);
            this.groupBox_atras.Name = "groupBox_atras";
            this.groupBox_atras.Size = new System.Drawing.Size(560, 69);
            this.groupBox_atras.TabIndex = 6;
            this.groupBox_atras.TabStop = false;
            // 
            // button_atras
            // 
            this.button_atras.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_atras.Location = new System.Drawing.Point(182, 19);
            this.button_atras.Name = "button_atras";
            this.button_atras.Size = new System.Drawing.Size(200, 36);
            this.button_atras.TabIndex = 6;
            this.button_atras.Text = "Atrás";
            this.button_atras.UseVisualStyleBackColor = true;
            this.button_atras.Click += new System.EventHandler(this.button_atras_Click);
            // 
            // registro_resultado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.groupBox_atras);
            this.Controls.Add(this.groupBox_diag);
            this.Controls.Add(this.groupBox_fechahora);
            this.Name = "registro_resultado";
            this.Text = "Registro de resultado - Clinica FRBA";
            this.groupBox_fechahora.ResumeLayout(false);
            this.groupBox_fechahora.PerformLayout();
            this.groupBox_diag.ResumeLayout(false);
            this.groupBox_diag.PerformLayout();
            this.groupBox_atras.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_fechahora;
        private System.Windows.Forms.Button button_confirmar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker hora;
        private System.Windows.Forms.DateTimePicker fecha;
        private System.Windows.Forms.GroupBox groupBox_diag;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_diag;
        private System.Windows.Forms.GroupBox groupBox_atras;
        private System.Windows.Forms.Button button_atras;
    }
}