using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Listados
{
    public partial class Form1 : Form
    {
        public DBAccess Access { get; set; }

        public Form1()
        {
            InitializeComponent();

            Access = new DBAccess();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT * FROM [GD2C2016].[UN_CORTADO].[TOP5_ESPECIALIDADES]");

                SqlCommand cmd = new SqlCommand(query, conexion);

                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    ArrayList listado = new ArrayList();
                    if (dr.HasRows)
                        foreach (DbDataRecord item in dr)
                            listado.Add(item);

                    listado_estadistico_dgrvw.DataSource = listado;
                }
                catch
                {

                }
            }
        }
    }
}
