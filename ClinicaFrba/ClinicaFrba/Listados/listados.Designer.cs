namespace ClinicaFrba.Listados
{
    partial class listados
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bot_atras = new System.Windows.Forms.Button();
            this.especmascan = new System.Windows.Forms.Button();
            this.profmasconsul = new System.Windows.Forms.Button();
            this.profvagos = new System.Windows.Forms.Button();
            this.afimasbonos = new System.Windows.Forms.Button();
            this.especmasbonos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.combo_trimestre = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.combo_trimestre);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.especmasbonos);
            this.groupBox1.Controls.Add(this.afimasbonos);
            this.groupBox1.Controls.Add(this.profvagos);
            this.groupBox1.Controls.Add(this.profmasconsul);
            this.groupBox1.Controls.Add(this.especmascan);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 418);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estadísticas  ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bot_atras);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 464);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 85);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // bot_atras
            // 
            this.bot_atras.Location = new System.Drawing.Point(224, 25);
            this.bot_atras.Name = "bot_atras";
            this.bot_atras.Size = new System.Drawing.Size(134, 40);
            this.bot_atras.TabIndex = 13;
            this.bot_atras.Text = "Atrás";
            this.bot_atras.UseVisualStyleBackColor = true;
            // 
            // especmascan
            // 
            this.especmascan.Location = new System.Drawing.Point(130, 298);
            this.especmascan.Name = "especmascan";
            this.especmascan.Size = new System.Drawing.Size(134, 80);
            this.especmascan.TabIndex = 14;
            this.especmascan.Text = "TOP 5 Especialidades con más cancelaciones";
            this.especmascan.UseVisualStyleBackColor = true;
            this.especmascan.Click += new System.EventHandler(this.especmascan_Click);
            // 
            // profmasconsul
            // 
            this.profmasconsul.Location = new System.Drawing.Point(44, 195);
            this.profmasconsul.Name = "profmasconsul";
            this.profmasconsul.Size = new System.Drawing.Size(134, 80);
            this.profmasconsul.TabIndex = 15;
            this.profmasconsul.Text = "TOP 5 Profesionales más consultados por plan/especialidad";
            this.profmasconsul.UseVisualStyleBackColor = true;
            this.profmasconsul.Click += new System.EventHandler(this.profmasconsul_Click);
            // 
            // profvagos
            // 
            this.profvagos.Location = new System.Drawing.Point(208, 195);
            this.profvagos.Name = "profvagos";
            this.profvagos.Size = new System.Drawing.Size(134, 80);
            this.profvagos.TabIndex = 16;
            this.profvagos.Text = "TOP 5 Profesionales con menos horas trabajadas";
            this.profvagos.UseVisualStyleBackColor = true;
            this.profvagos.Click += new System.EventHandler(this.profvagos_Click);
            // 
            // afimasbonos
            // 
            this.afimasbonos.Location = new System.Drawing.Point(289, 298);
            this.afimasbonos.Name = "afimasbonos";
            this.afimasbonos.Size = new System.Drawing.Size(134, 80);
            this.afimasbonos.TabIndex = 17;
            this.afimasbonos.Text = "TOP 5  Afiliados que adquirieron mas bonos";
            this.afimasbonos.UseVisualStyleBackColor = true;
            this.afimasbonos.Click += new System.EventHandler(this.afimasbonos_Click);
            // 
            // especmasbonos
            // 
            this.especmasbonos.Location = new System.Drawing.Point(372, 195);
            this.especmasbonos.Name = "especmasbonos";
            this.especmasbonos.Size = new System.Drawing.Size(134, 80);
            this.especmasbonos.TabIndex = 18;
            this.especmasbonos.Text = "TOP 5 Especialidades con más bonos de consulta usados";
            this.especmasbonos.UseVisualStyleBackColor = true;
            this.especmasbonos.Click += new System.EventHandler(this.especmasbonos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(241, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 18);
            this.label1.TabIndex = 19;
            this.label1.Text = "Semestre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 18);
            this.label2.TabIndex = 20;
            this.label2.Text = "Año";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(208, 68);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(134, 26);
            this.textBox1.TabIndex = 21;
            // 
            // combo_trimestre
            // 
            this.combo_trimestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_trimestre.FormattingEnabled = true;
            this.combo_trimestre.Location = new System.Drawing.Point(208, 118);
            this.combo_trimestre.Name = "combo_trimestre";
            this.combo_trimestre.Size = new System.Drawing.Size(134, 26);
            this.combo_trimestre.TabIndex = 22;
            // 
            // listados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "listados";
            this.Text = "Clinica FRBA - Listados Estadísticos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button especmasbonos;
        private System.Windows.Forms.Button afimasbonos;
        private System.Windows.Forms.Button profvagos;
        private System.Windows.Forms.Button profmasconsul;
        private System.Windows.Forms.Button especmascan;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bot_atras;
        private System.Windows.Forms.ComboBox combo_trimestre;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}