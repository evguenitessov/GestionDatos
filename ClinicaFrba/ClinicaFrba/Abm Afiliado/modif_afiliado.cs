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
    public partial class modif_afiliado : Form
    {
        public modif_afiliado()
        {
            InitializeComponent();
        }

        private void bot_borrar_Click(object sender, EventArgs e)
        {
            direccion.Clear();
            telef.Clear();
            mail.Clear();
            sexo.SelectedIndex = -1;
            ecivil.SelectedIndex = -1;
            canthijosfamcargo.Clear();
            planmed.SelectedIndex = -1;
        }
    }
}
