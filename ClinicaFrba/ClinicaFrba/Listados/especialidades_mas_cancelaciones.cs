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
    public partial class especialidades_mas_cancelaciones : Form
    {
        private string anio;
        private string semestre;
        public DBAccess Access { get; set; }

        public especialidades_mas_cancelaciones(string anio, string semestre)
        {
            InitializeComponent();
            Access = new DBAccess();
            this.anio = anio;
            this.semestre = semestre;
            cargargrid();
        }

        private void cargargrid()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Access.Conexion))
            {
                Int16 sem = Convert.ToInt16(semestre.ToString());
                Int16 año = Convert.ToInt16(anio.ToString());
                using (SqlCommand cmd = new SqlCommand("[UN_CORTADO].[TOP5_ESPECIALIDADES_CAN]", con))
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
