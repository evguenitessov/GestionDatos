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
    public partial class afiliados_mas_bonos : Form
    {
        private string anio;
        private string trimestre;

        public afiliados_mas_bonos(string anio, string trimestre)
        {
            InitializeComponent();
            this.anio = anio;
            this.trimestre = trimestre;
        }
    }
}
