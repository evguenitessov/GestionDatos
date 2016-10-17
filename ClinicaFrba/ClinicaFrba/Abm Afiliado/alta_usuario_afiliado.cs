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
    public partial class alta_usuario_afiliado : Form
    {
        public alta_usuario_afiliado()
        {
            InitializeComponent();
        }

        private void bot_borrar_Click(object sender, EventArgs e)
        {
            usuario.Clear();
            contra.Clear();
        }

        private void bot_siguiente_Click(object sender, EventArgs e)
        {
            //verificar que no exista un usuario con ese mismo nombre
        }
    }
}
