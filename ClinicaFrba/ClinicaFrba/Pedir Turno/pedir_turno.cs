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

namespace ClinicaFrba.Pedir_Turno
{
    public partial class pedir_turno : Form
    {
       public DBAccess Access { get; set; }
       public pedir_turno()
        {
            InitializeComponent();
            Access = new DBAccess();
            profesional.Hide();
            fecha.Hide();
            horario.Hide();
            cargarespecialidades();
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

        private void aceptar_especialidad_Click(object sender, EventArgs e)
        {            
            {
                profesional.Show();
                cargarprofesionales();
            }
        }

        private void cargarprofesionales()
        {
            String query = " SELECT NOMBRE_PROFESIONAL,APELLIDO_PROFESIONAL FROM UN_CORTADO.ProfesionalesYSusEspecialidades WHERE NOMBRE_ESPECIALIDAD=@especialidad";
            SqlConnection con = new SqlConnection(Access.Conexion);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@especialidad", combo_especialidades.SelectedItem.ToString());
            SqlDataReader dr;
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string nombre_completo = dr["APELLIDO_PROFESIONAL"] + "," + dr["NOMBRE_PROFESIONAL"];
                    combo_profesionales.Items.Add(nombre_completo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error","ERROR");
            }
        }

        private void aceptar_profesional_Click(object sender, EventArgs e)
        {
            fecha.Show();
            cargarfechas();
        }

        private void cargarfechas()
        {

        }

        private void aceptar_fecha_Click(object sender, EventArgs e)
        {
            horario.Show();
        }
    }
}


