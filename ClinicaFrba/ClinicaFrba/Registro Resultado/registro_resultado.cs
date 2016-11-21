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

namespace ClinicaFrba.Registro_Resultado
{
    public partial class registro_resultado : Form
    {
        private string usuario;
        private char p;
        public DBAccess Access { get; set; }

        public registro_resultado(string usuario)
        {            
            InitializeComponent();
            this.usuario = usuario;
            groupBox_diag.Hide();
        }

        private void button_confirmar_Click(object sender, EventArgs e)
        {
            groupBox_diag.Show();
        }

        private void button_atras_Click(object sender, EventArgs e)
        {
            //Menu.Menu menu = new Menu.Menu(Usuario, "Profesional");
            //this.Hide();
            //menu.Show();
        }

        private void confirmar_todo_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                conexion.Open();
                SqlTransaction sqlTransact = conexion.BeginTransaction();
                SqlCommand command = conexion.CreateCommand();
                command.Transaction = sqlTransact;
                try
                {
                    string query = String.Format("INSERT INTO [UN_CORTADO].[ATENCIONMEDICA] VALUES (@usuario,@enfermedad,@sintoma, @idturno, @bonousado)");
                    command.CommandText = query;

                    SqlParameter param = new SqlParameter("@usuario", usuario);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@enfermedad", enfermedad.Text);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@sintoma", sintoma.Text);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@idturno", conseguiridturno());
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@bonousado", conseguirbonousado());
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    command.Parameters.Add(param);

                    command.ExecuteNonQuery();
                    sqlTransact.Commit();
                    MessageBox.Show("Consulta médica registrada correctamente.", "Exito");
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

        private object conseguiridturno()
        {
            throw new NotImplementedException();
        }

        private object conseguirbonousado()
        {
            throw new NotImplementedException();
        }

        private object conseguirfechayhora()
        {
            throw new NotImplementedException();
        }

    }
}
