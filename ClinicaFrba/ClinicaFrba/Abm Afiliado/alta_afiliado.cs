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
    public partial class alta_afiliado : Form
    {
        public alta_afiliado()
        {
            InitializeComponent();
        }

        private void bot_borrar_Click(object sender, EventArgs e) //borra campos
        {
            nombre.Clear();
            apellido.Clear();
            tipodoc.SelectedIndex = -1;
            nrodoc.Clear();
            direccion.Clear();
            telef.Clear();
            mail.Clear();
            fechanac.Value = DateTime.Today;
            sexo.SelectedIndex = -1;
            ecivil.SelectedIndex = -1;
            canthijosfamcargo.Clear();
            planmed.SelectedIndex = -1;
        }

        private void bot_guardar_Click(object sender, EventArgs e) //guarda si son correctos en la bd
        {
            if (chequeartodoscamposcompletos().Equals(0) && chequeartipodatos().Equals(0))
            {
                //cargar datos en bd
            }
            else 
            {
                MessageBox.Show("Verifique que todos los campos estén completados adecuadamente y los datos correctamente ingresados.", "Error al guardar");            
            }
        }

        private int chequeartodoscamposcompletos() //chequea que estén completos
        {
            if (nombre.Text.Equals("") || apellido.Text.Equals("") || tipodoc.SelectedIndex.Equals(-1) ||
                nrodoc.Text.Equals("") || direccion.Text.Equals("") || mail.Text.Equals("") || telef.Text.Equals("") ||
                sexo.SelectedIndex.Equals(-1) || ecivil.SelectedIndex.Equals(-1) || canthijosfamcargo.Text.Equals("") ||
                planmed.SelectedIndex.Equals(-1))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private int chequeartipodatos() //chequea los tipos de datos
        {
            if (IsNumeric(nombre.Text).Equals(true) || IsNumeric(apellido.Text).Equals(true) ||
                IsNumeric(nrodoc.Text).Equals(false) || IsNumeric(telef.Text).Equals(false) ||
                IsNumeric(canthijosfamcargo.Text).Equals(false))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static bool IsNumeric(string s) //verifica si todos los caracteres son numericos
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c) && c != '.')
                {
                    return false;
                }
            }

            return true;
        }     
    }
}
