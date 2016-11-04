using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class menu_abmafiliado : Form
    {
        public menu_abmafiliado()
        {
            InitializeComponent();
        }

        private void boton_alta_Click(object sender, EventArgs e)
        {
           Abm_Afiliado.alta_usuario_afiliado alta_afi= new Abm_Afiliado.alta_usuario_afiliado(false, 0, null);
           alta_afi.Show();
           this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.listado_afiliado listado_afi = new Abm_Afiliado.listado_afiliado();
            listado_afi.Show();
            this.Hide();
        }
    }
}
