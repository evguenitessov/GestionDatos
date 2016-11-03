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

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class motivo_cambio : Form
    {
        private string usu;
        private string nombreplan;
        public DBAccess Access { get; set; }

        public motivo_cambio(string usu, string nombreplan)
        {
            InitializeComponent();
            this.usu = usu;
            this.nombreplan = nombreplan;
            Access = new DBAccess();
        }

        private void confirmar_Click(object sender, EventArgs e)
        {
            cargarenlabd();
            this.Close();
        }

        private void cargarenlabd()
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                conexion.Open();
                SqlTransaction sqlTransact = conexion.BeginTransaction();
                SqlCommand command = conexion.CreateCommand();
                command.Transaction = sqlTransact;
                try
                {
                    string query = String.Format("INSERT INTO [UN_CORTADO].[MODIFICACIONES] ([Nombre_Usuario],[Detalle],[Plan_Anterior]) VALUES (@usuario,@detalle,@planant)");
                    command.CommandText = query;

                    SqlParameter param = new SqlParameter("@usuario", usu);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@detalle",txt_motivo.Text);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@planant", nombreplan);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    command.ExecuteNonQuery();
                    sqlTransact.Commit();

                    MessageBox.Show("La modificación ha sido registrada correctamente.", "Modificación de plan.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error, vuelva a intentarlo", "Error");
                    sqlTransact.Rollback();
                }
                finally
                {
                    if (conexion.State == System.Data.ConnectionState.Open)
                        conexion.Dispose();
                }
            }
        }
    }
}
