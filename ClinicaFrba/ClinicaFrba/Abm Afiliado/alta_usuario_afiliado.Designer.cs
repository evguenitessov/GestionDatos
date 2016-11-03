namespace ClinicaFrba.Abm_Afiliado
{
    partial class alta_usuario_afiliado
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
            this.group_alta = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.contra = new System.Windows.Forms.TextBox();
            this.usuario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bot_atras = new System.Windows.Forms.Button();
            this.bot_siguiente = new System.Windows.Forms.Button();
            this.bot_borrar = new System.Windows.Forms.Button();
            this.label_conyuge = new System.Windows.Forms.Label();
            this.label_hijosfam = new System.Windows.Forms.Label();
            this.group_alta.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // group_alta
            // 
            this.group_alta.BackColor = System.Drawing.Color.Transparent;
            this.group_alta.Controls.Add(this.label_conyuge);
            this.group_alta.Controls.Add(this.label_hijosfam);
            this.group_alta.Controls.Add(this.label13);
            this.group_alta.Controls.Add(this.contra);
            this.group_alta.Controls.Add(this.usuario);
            this.group_alta.Controls.Add(this.label4);
            this.group_alta.Controls.Add(this.label1);
            this.group_alta.Font = new System.Drawing.Font("Calibri", 12F);
            this.group_alta.Location = new System.Drawing.Point(12, 6);
            this.group_alta.Name = "group_alta";
            this.group_alta.Size = new System.Drawing.Size(560, 462);
            this.group_alta.TabIndex = 1;
            this.group_alta.TabStop = false;
            this.group_alta.Text = "Nuevo afiliado";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(393, 440);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(156, 19);
            this.label13.TabIndex = 25;
            this.label13.Text = "* campos obligatorios.";
            // 
            // contra
            // 
            this.contra.Location = new System.Drawing.Point(302, 226);
            this.contra.Name = "contra";
            this.contra.Size = new System.Drawing.Size(200, 27);
            this.contra.TabIndex = 15;
            // 
            // usuario
            // 
            this.usuario.Location = new System.Drawing.Point(302, 193);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(200, 27);
            this.usuario.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Contraseña*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario *";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bot_atras);
            this.groupBox1.Controls.Add(this.bot_siguiente);
            this.groupBox1.Controls.Add(this.bot_borrar);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 468);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 85);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // bot_atras
            // 
            this.bot_atras.Location = new System.Drawing.Point(6, 25);
            this.bot_atras.Name = "bot_atras";
            this.bot_atras.Size = new System.Drawing.Size(124, 40);
            this.bot_atras.TabIndex = 13;
            this.bot_atras.Text = "Atrás";
            this.bot_atras.UseVisualStyleBackColor = true;
            // 
            // bot_siguiente
            // 
            this.bot_siguiente.Location = new System.Drawing.Point(430, 25);
            this.bot_siguiente.Name = "bot_siguiente";
            this.bot_siguiente.Size = new System.Drawing.Size(124, 40);
            this.bot_siguiente.TabIndex = 12;
            this.bot_siguiente.Text = "Siguiente";
            this.bot_siguiente.UseVisualStyleBackColor = true;
            this.bot_siguiente.Click += new System.EventHandler(this.bot_siguiente_Click);
            // 
            // bot_borrar
            // 
            this.bot_borrar.Location = new System.Drawing.Point(217, 25);
            this.bot_borrar.Name = "bot_borrar";
            this.bot_borrar.Size = new System.Drawing.Size(124, 40);
            this.bot_borrar.TabIndex = 11;
            this.bot_borrar.Text = "Borrar";
            this.bot_borrar.UseVisualStyleBackColor = true;
            this.bot_borrar.Click += new System.EventHandler(this.bot_borrar_Click);
            // 
            // label_conyuge
            // 
            this.label_conyuge.AutoSize = true;
            this.label_conyuge.Location = new System.Drawing.Point(213, 23);
            this.label_conyuge.Name = "label_conyuge";
            this.label_conyuge.Size = new System.Drawing.Size(132, 19);
            this.label_conyuge.TabIndex = 16;
            this.label_conyuge.Text = "ALTA DE CONYUGE";
            // 
            // label_hijosfam
            // 
            this.label_hijosfam.AutoSize = true;
            this.label_hijosfam.Location = new System.Drawing.Point(190, 42);
            this.label_hijosfam.Name = "label_hijosfam";
            this.label_hijosfam.Size = new System.Drawing.Size(185, 19);
            this.label_hijosfam.TabIndex = 26;
            this.label_hijosfam.Text = "ALTA DE HIJOS/FAMILIARES";
            // 
            // alta_usuario_afiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.group_alta);
            this.Name = "alta_usuario_afiliado";
            this.Text = "Clinica FRBA - Alta de afiliado";
            this.group_alta.ResumeLayout(false);
            this.group_alta.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox group_alta;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox contra;
        private System.Windows.Forms.TextBox usuario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bot_atras;
        private System.Windows.Forms.Button bot_siguiente;
        private System.Windows.Forms.Button bot_borrar;
        private System.Windows.Forms.Label label_conyuge;
        private System.Windows.Forms.Label label_hijosfam;
    }
}