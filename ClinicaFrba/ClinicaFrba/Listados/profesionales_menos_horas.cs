using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Listados
{
    public partial class profesionales_menos_horas : Form
    {
        private string anio;
        private string semestre;
        public DBAccess Access { get; set; }

        public profesionales_menos_horas(string anio, string semestre)
        {
            InitializeComponent();
            Access = new DBAccess();
            this.anio = anio;
            this.semestre = semestre;
            cargarespecialidades();
            cargarplanes();
        }

        private void cargarplanes()
        {
            SqlConnection conexion = new SqlConnection(Access.Conexion);
            conexion.Open();
            string query = "SELECT Id FROM UN_CORTADO.PLANES";
            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                combo_plan.Items.Add(dr[0]); ;
            }
        }

        private void cargarespecialidades()
        {
            SqlConnection conexion = new SqlConnection(Access.Conexion);
            conexion.Open();
            string query = "SELECT Nombre FROM UN_CORTADO.ESPECIALIDADES";
            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                combo_especialidades.Items.Add(dr[0]);
            }
        }
    }
}
