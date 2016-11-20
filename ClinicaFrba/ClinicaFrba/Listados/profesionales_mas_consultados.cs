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
    public partial class profesionales_mas_consultados : Form
    {
        public DBAccess Access { get; set; }
        private string anio;
        private string semestre;

        public profesionales_mas_consultados(string anio, string semestre)
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
                combo_plan.Items.Add(dr[0]);;
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

        private void buscar_Click(object sender, EventArgs e)
        {
            if(combo_especialidades.SelectedIndex.Equals(-1) || combo_plan.SelectedIndex.Equals(-1))
            {
                MessageBox.Show("Seleccionar plan y especialidad.", "Error");
            }
            else
            {
                //using (SqlConnection con = new SqlConnection(Access.Conexion))
                //{
                //    Int16 sem = Convert.ToInt16(semestre);
                //    Int16 año = Convert.ToInt16(anio);
                //    using (SqlCommand cmd = new SqlCommand("[UN_CORTADO].[TOP5_PROFESIONAL_PLAN]", con))
                //    {
                //        cmd.CommandType = CommandType.StoredProcedure;

                //        cmd.Parameters.Add("@semestre", SqlDbType.VarChar).Value = sem;
                //        cmd.Parameters.Add("@anio", SqlDbType.VarChar).Value = año;

                //        con.Open();
                //        cmd.ExecuteNonQuery();
                //    }
                //}
            }
        }
        
    }
    }

