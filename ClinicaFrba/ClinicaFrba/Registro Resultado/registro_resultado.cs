using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Registro_Resultado
{
    public partial class registro_resultado : Form
    {
        public string Usuario { get; set; }
        public DBAccess Access { get; set; }
        public registro_resultado(string usuario)
        {            
            InitializeComponent();
            hora.CustomFormat = "HH:mm";
            Usuario = usuario;
            groupBox_diag.Hide();
        }

        private void button_confirmar_Click(object sender, EventArgs e)
        {
            groupBox_diag.Show();
        }

        private void button_atras_Click(object sender, EventArgs e)
        {
            //Menu.Menu menu = new Menu.Menu(Usuario, "Profesional");
            //this.Hide();
            //menu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_diag.Text.Equals(""))
            {
                MessageBox.Show("Por favor ingrese el diagnóstico", "ERROR");
            }
            else
            {
                
            }
        }
    }
}
