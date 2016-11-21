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

        private void buscar_Click(object sender, EventArgs e)
        {
            if(combo_especialidades.SelectedIndex.Equals(-1) || combo_plan.SelectedIndex.Equals(-1))
            {
                MessageBox.Show("Seleccionar plan y especialidad.", "Error");
            }
            else
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(Access.Conexion))
                {
                    Int16 sem = Convert.ToInt16(semestre.ToString());
                    Decimal plan = Convert.ToDecimal(combo_plan.SelectedItem.ToString());
                    Int16 año = Convert.ToInt16(anio.ToString());
                    using (SqlCommand cmd = new SqlCommand("[UN_CORTADO].[TOP5_PROFESIONAL_MENOSHORAS]", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@semestre", SqlDbType.Int).Value = sem;
                        cmd.Parameters.Add("@year", SqlDbType.Int).Value = año;
                        cmd.Parameters.Add("@plan", SqlDbType.Int).Value = plan;
                        cmd.Parameters.Add("@especialidad", SqlDbType.VarChar).Value = id_especialidad(combo_especialidades.SelectedItem.ToString());
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        try
                        {
                            con.Open();
                            da.Fill(dt);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Ocurrio un error", "Error");
                        }
                        finally
                        {
                            if (con.State == ConnectionState.Open)
                                con.Close();
                        }

                        dataGridView1.DataSource = dt;
                    }
                }
        }
    }

        private decimal id_especialidad(string especialidad)
        {
            SqlConnection conexion = new SqlConnection(Access.Conexion);
            conexion.Open();
            string query = "SELECT Id FROM UN_CORTADO.ESPECIALIDADES WHERE Nombre=@nombreespec";
            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@nombreespec", especialidad);
            Decimal id_espec = Convert.ToDecimal(cmd.ExecuteScalar());
            return id_espec; 
        }
    }
}
