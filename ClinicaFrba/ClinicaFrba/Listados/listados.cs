using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Listados
{
    public partial class listados : Form
    {
        public listados()
        {
            InitializeComponent();
            combo_trimestre.Items.Add("1");
            combo_trimestre.Items.Add("2");
        }

        private void especmascan_Click(object sender, EventArgs e)
        {
            if(chequearcamposllenos().Equals(true))
            {
                Listados.especialidades_mas_cancelaciones especmascan = new Listados.especialidades_mas_cancelaciones(textBox1.Text, combo_trimestre.SelectedItem.ToString());
                especmascan.Show();
            }
        }

        private bool chequearcamposllenos()
        {
            if (textBox1.Equals("") || combo_trimestre.SelectedIndex.Equals(-1))
            {
                MessageBox.Show("Completar todos los campos.", "Error");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void profmasconsul_Click(object sender, EventArgs e)
        {
            if (chequearcamposllenos().Equals(true))
            {
                Listados.profesionales_mas_consultados profmasconsul = new Listados.profesionales_mas_consultados(textBox1.Text, combo_trimestre.SelectedItem.ToString());
                profmasconsul.Show();
            }
        }

        private void afimasbonos_Click(object sender, EventArgs e)
        {
            if (chequearcamposllenos().Equals(true))
            {
                Listados.afiliados_mas_bonos afimasbonos = new Listados.afiliados_mas_bonos(textBox1.Text, combo_trimestre.SelectedItem.ToString());
                afimasbonos.Show();
            }
        }

        private void profvagos_Click(object sender, EventArgs e)
        {
            if (chequearcamposllenos().Equals(true))
            {
                Listados.profesionales_menos_horas profvagos = new Listados.profesionales_menos_horas(textBox1.Text, combo_trimestre.SelectedItem.ToString());
                profvagos.Show();
            }
        }

        private void especmasbonos_Click(object sender, EventArgs e)
        {
            if (chequearcamposllenos().Equals(true))
            {
                Listados.especialidades_mas_bonos especmasbonos = new Listados.especialidades_mas_bonos(textBox1.Text, combo_trimestre.SelectedItem.ToString());
                especmasbonos.Show();
            }
        }

        private void bot_atras_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
