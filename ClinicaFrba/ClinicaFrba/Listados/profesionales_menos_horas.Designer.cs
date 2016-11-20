namespace ClinicaFrba.Listados
{
    partial class profesionales_menos_horas
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
            this.combo_plan = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buscar = new System.Windows.Forms.Button();
            this.combo_especialidades = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.combo_plan);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.buscar);
            this.groupBox1.Controls.Add(this.combo_especialidades);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 537);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estadísticas";
            // 
            // combo_plan
            // 
            this.combo_plan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_plan.FormattingEnabled = true;
            this.combo_plan.Location = new System.Drawing.Point(184, 71);
            this.combo_plan.Name = "combo_plan";
            this.combo_plan.Size = new System.Drawing.Size(188, 26);
            this.combo_plan.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(259, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "Plan";
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(184, 153);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(188, 31);
            this.buscar.TabIndex = 9;
            this.buscar.Text = "Buscar";
            this.buscar.UseVisualStyleBackColor = true;
            // 
            // combo_especialidades
            // 
            this.combo_especialidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_especialidades.FormattingEnabled = true;
            this.combo_especialidades.Location = new System.Drawing.Point(184, 121);
            this.combo_especialidades.Name = "combo_especialidades";
            this.combo_especialidades.Size = new System.Drawing.Size(188, 26);
            this.combo_especialidades.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Especialidad";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 204);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(508, 314);
            this.dataGridView1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(126, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "PROFESIONALES CON MENOS HORAS TRABAJADAS";
            // 
            // profesionales_menos_horas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.groupBox1);
            this.Name = "profesionales_menos_horas";
            this.Text = "Clinica FRBA - Profesionales con menos horas trabajadas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combo_plan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.ComboBox combo_especialidades;
        private System.Windows.Forms.Label label2;
    }
}