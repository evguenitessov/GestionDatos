﻿using System;
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
        public DBAccess Access { get; set; }

        public registro_resultado(string usuario)
        {            
            InitializeComponent();
            Access = new DBAccess();
            this.usuario = usuario;
            groupBox_diag.Hide();
        }

        private void button_confirmar_Click(object sender, EventArgs e)
        {
            groupBox_diag.Show();
        }

        private void button_atras_Click(object sender, EventArgs e)
        {            
            this.Hide();
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
                    string query = String.Format("UPDATE [UN_CORTADO].[ATENCIONMEDICA] SET Nombre_Profecional=@usuario,Enfermedad=@enfermedad,Sintomas=@sintoma,Fecha_Hora=@fechahora WHERE Id=(SELECT max(Id) FROM UN_CORTADO.ATENCIONMEDICA)");
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

                    param = new SqlParameter("@fechahora", conseguirfechayhora());
                    param.SqlDbType = System.Data.SqlDbType.DateTime;
                    command.Parameters.Add(param);

                    command.ExecuteNonQuery();
                    sqlTransact.Commit();
                    MessageBox.Show("Consulta médica registrada correctamente.", "Exito");
                    this.Hide();
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

        private DateTime conseguirfechayhora()
        {
            DateTime resultado = Convert.ToDateTime(DBAccess.fechaSystem()) + conseguirhora();
            return resultado;
        }

        private TimeSpan conseguirhora()
        {
            SqlConnection conexion = new SqlConnection(Access.Conexion);
            conexion.Open();
            string query = "SELECT Hora_Llegada_Afiliado  from UN_CORTADO.TURNOS where Id=(select Id_turno from UN_CORTADO.ATENCIONMEDICA where Id= (select max(Id) from UN_CORTADO.ATENCIONMEDICA))";
            SqlCommand cmd = new SqlCommand(query, conexion);
            TimeSpan hora = (TimeSpan) cmd.ExecuteScalar();
            return hora;
        }

    }
}
