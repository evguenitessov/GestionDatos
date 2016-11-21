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
    public partial class especialidades_mas_bonos : Form
    {
        public DBAccess Access { get; set; }
        private string anio;
        private string semestre;

        public especialidades_mas_bonos(string anio, string semestre)
        {
            InitializeComponent();
            Access = new DBAccess();
            this.anio = anio;
            this.semestre = semestre;
            cargar_grid();
        }

        private void cargar_grid()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Access.Conexion))
            {
                Int16 sem = Convert.ToInt16(semestre);
                Int16 año = Convert.ToInt16(anio);
                using (SqlCommand cmd = new SqlCommand("UN_CORTADO.TOP5_ESPECIALIDADES_MASBONOS ", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@semestre", SqlDbType.Int).Value = sem;
                    cmd.Parameters.Add("@year", SqlDbType.Int).Value = año;
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
}
