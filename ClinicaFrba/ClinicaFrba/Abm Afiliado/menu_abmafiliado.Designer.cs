namespace ClinicaFrba.Abm_Afiliado
{
    partial class menu_abmafiliado
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
            this.boton_alta = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.boton_alta);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 237);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // boton_alta
            // 
            this.boton_alta.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton_alta.Location = new System.Drawing.Point(33, 61);
            this.boton_alta.Name = "boton_alta";
            this.boton_alta.Size = new System.Drawing.Size(196, 44);
            this.boton_alta.TabIndex = 17;
            this.boton_alta.Text = "Alta de afiliado";
            this.boton_alta.UseVisualStyleBackColor = true;
            this.boton_alta.Click += new System.EventHandler(this.boton_alta_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(33, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(196, 45);
            this.button1.TabIndex = 18;
            this.button1.Text = "Modificacion/Baja de afiliado";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menu_abmafiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.groupBox1);
            this.Name = "menu_abmafiliado";
            this.Text = "Menú ABM afiliado - Clinica FRBA";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button boton_alta;
    }
}