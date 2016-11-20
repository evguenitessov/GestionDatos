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
            this.button_confirmar_fyh = new System.Windows.Forms.Button();
            this.groupBox_diag = new System.Windows.Forms.GroupBox();
            this.groupBox_atras = new System.Windows.Forms.GroupBox();
            this.button_atras = new System.Windows.Forms.Button();
            this.enfermedad = new System.Windows.Forms.TextBox();
            this.sintoma = new System.Windows.Forms.TextBox();
            this.diagnostico = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.confirmar_todo = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox_fechahora.SuspendLayout();
            this.groupBox_diag.SuspendLayout();
            this.groupBox_atras.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_fechahora
            // 
            this.groupBox_fechahora.Controls.Add(this.button_confirmar_fyh);
            this.groupBox_fechahora.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_fechahora.Location = new System.Drawing.Point(12, 12);
            this.groupBox_fechahora.Name = "groupBox_fechahora";
            this.groupBox_fechahora.Size = new System.Drawing.Size(560, 112);
            this.groupBox_fechahora.TabIndex = 0;
            this.groupBox_fechahora.TabStop = false;
            this.groupBox_fechahora.Text = "Confirmar fecha y hora de atención médica";
            // 
            // button_confirmar_fyh
            // 
            this.button_confirmar_fyh.Location = new System.Drawing.Point(187, 25);
            this.button_confirmar_fyh.Name = "button_confirmar_fyh";
            this.button_confirmar_fyh.Size = new System.Drawing.Size(200, 73);
            this.button_confirmar_fyh.TabIndex = 4;
            this.button_confirmar_fyh.Text = "Confirmo que la atención ocurrió en fecha y hora";
            this.button_confirmar_fyh.UseVisualStyleBackColor = true;
            this.button_confirmar_fyh.Click += new System.EventHandler(this.button_confirmar_Click);
            // 
            // groupBox_diag
            // 
            this.groupBox_diag.Controls.Add(this.label5);
            this.groupBox_diag.Controls.Add(this.label4);
            this.groupBox_diag.Controls.Add(this.label3);
            this.groupBox_diag.Controls.Add(this.diagnostico);
            this.groupBox_diag.Controls.Add(this.sintoma);
            this.groupBox_diag.Controls.Add(this.enfermedad);
            this.groupBox_diag.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_diag.Location = new System.Drawing.Point(12, 130);
            this.groupBox_diag.Name = "groupBox_diag";
            this.groupBox_diag.Size = new System.Drawing.Size(560, 344);
            this.groupBox_diag.TabIndex = 5;
            this.groupBox_diag.TabStop = false;
            this.groupBox_diag.Text = "Diagnóstico";
            // 
            // groupBox_atras
            // 
            this.groupBox_atras.Controls.Add(this.confirmar_todo);
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
            this.button_atras.Location = new System.Drawing.Point(6, 19);
            this.button_atras.Name = "button_atras";
            this.button_atras.Size = new System.Drawing.Size(200, 36);
            this.button_atras.TabIndex = 6;
            this.button_atras.Text = "Atrás";
            this.button_atras.UseVisualStyleBackColor = true;
            this.button_atras.Click += new System.EventHandler(this.button_atras_Click);
            // 
            // enfermedad
            // 
            this.enfermedad.Location = new System.Drawing.Point(187, 102);
            this.enfermedad.Name = "enfermedad";
            this.enfermedad.Size = new System.Drawing.Size(200, 26);
            this.enfermedad.TabIndex = 6;
            // 
            // sintoma
            // 
            this.sintoma.Location = new System.Drawing.Point(187, 52);
            this.sintoma.Name = "sintoma";
            this.sintoma.Size = new System.Drawing.Size(200, 26);
            this.sintoma.TabIndex = 7;
            // 
            // diagnostico
            // 
            this.diagnostico.Location = new System.Drawing.Point(6, 152);
            this.diagnostico.Multiline = true;
            this.diagnostico.Name = "diagnostico";
            this.diagnostico.Size = new System.Drawing.Size(548, 167);
            this.diagnostico.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(242, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Enfermedad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Síntoma/s";
            // 
            // confirmar_todo
            // 
            this.confirmar_todo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmar_todo.Location = new System.Drawing.Point(354, 19);
            this.confirmar_todo.Name = "confirmar_todo";
            this.confirmar_todo.Size = new System.Drawing.Size(200, 36);
            this.confirmar_todo.TabIndex = 7;
            this.confirmar_todo.Text = "Confirmar";
            this.confirmar_todo.UseVisualStyleBackColor = true;
            this.confirmar_todo.Click += new System.EventHandler(this.confirmar_todo_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(242, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "Diagnóstico";
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
            this.groupBox_diag.ResumeLayout(false);
            this.groupBox_diag.PerformLayout();
            this.groupBox_atras.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_fechahora;
        private System.Windows.Forms.Button button_confirmar_fyh;
        private System.Windows.Forms.GroupBox groupBox_diag;
        private System.Windows.Forms.GroupBox groupBox_atras;
        private System.Windows.Forms.Button button_atras;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox diagnostico;
        private System.Windows.Forms.TextBox sintoma;
        private System.Windows.Forms.TextBox enfermedad;
        private System.Windows.Forms.Button confirmar_todo;
        private System.Windows.Forms.Label label5;
    }
}