using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Registrar_Agenta_Medico
{
    public partial class registrar_agenda : Form
    {
        public registrar_agenda()
        {
            InitializeComponent();
            desde.CustomFormat = "HH:mm";
            hasta.CustomFormat = "HH:mm";
            box_rango.Hide();
            confirmar.Hide();
        }

        private void aceptar_dias_Click(object sender, EventArgs e)
        {
            if (sabadoischecked().Equals(false))
            {
                box_rango.Show();
                rango_dias_habiles();
            }
            else
            {
                box_rango.Show();
                rango_sabados();
            }
            
        }

        private void rango_sabados()
        {
            desde.MaxDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 15, 0, 0);
            desde.MinDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 0, 0);
            hasta.MaxDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 15, 0, 0);
            hasta.MinDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 0, 0);
        }

        private void rango_dias_habiles()
        {
            desde.MaxDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 20, 0, 0);
            desde.MinDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0);
            hasta.MaxDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 20, 0, 0);
            hasta.MinDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0);
        }

        private bool sabadoischecked()
        {
            if (checkedlist_dias.CheckedItems.Contains("Sábado"))
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        private void aceptar_rango_Click(object sender, EventArgs e)
        {
            if (validar_rango().Equals(false))
            {
                MessageBox.Show("Verifique que el rango se encuentre entre 07:00 - 20:00 o entre 10:00 - 15:00 respectivamente.", "Error");
            }
            else
            {
                MessageBox.Show("El rango ingresado es correcto. Puede confirmar.", "Éxito");
                confirmar.Show();
            }
        }

        private bool validar_rango()
        {
            if (desde.Value.Hour < hasta.Value.Hour)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void confirmar_Click(object sender, EventArgs e)
        {

        }
    }
}
