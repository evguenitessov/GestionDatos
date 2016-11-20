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
    public partial class especialidades_mas_cancelaciones : Form
    {
        private string anio;
        private string trimestre;

        public especialidades_mas_cancelaciones(string anio, string trimestre)
        {
            InitializeComponent();
            this.anio = anio;
            this.trimestre = trimestre;
        }
    }
}
