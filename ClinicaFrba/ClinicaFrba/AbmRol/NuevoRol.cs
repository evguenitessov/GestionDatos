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

namespace ClinicaFrba.AbmRol
{
    public partial class NuevoRol : Form
    {        
        public DBAccess Access { get; set; }

        public NuevoRol()
        {
            InitializeComponent();
            Access = new DBAccess();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.nombre_rol_txt.Text))
            {
                MessageBox.Show("El campo nombre no puede quedar vacio", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ultimoIdRol = 0;
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                conexion.Open();
                SqlTransaction sqlTransact = conexion.BeginTransaction();
                SqlCommand command = conexion.CreateCommand();
                command.Transaction = sqlTransact;                


                try
                {
                    string query = String.Format("INSERT INTO [UN_CORTADO].[ROLES] ([Nombre] ,[Estado]) VALUES ('{0}', 1); SELECT CAST(scope_identity() AS int)",
                                                  nombre_rol_txt.Text);
                    command.CommandText = query;
                    ultimoIdRol = (Int32)command.ExecuteScalar();

                    StringBuilder insertQuery = new StringBuilder();
                    insertQuery.Append("INSERT INTO [UN_CORTADO].[FUNCIONESPORROL] ");
                    insertQuery.Append("([Id_Funcion] ");
                    insertQuery.Append(" ,[Id_Rol])");
                    insertQuery.Append(" VALUES  ");
                    int contador = 1;
                    bool primerInsert = true;
                    bool rolSinFuncionalidad = true;
                    foreach (Control c in groupBox2.Controls.Cast<Control>().OrderBy(c => c.TabIndex))
                    {
                        if (c is CheckBox)
                        {
                            if (((CheckBox)c).Checked == true)
                            {
                                rolSinFuncionalidad = false;
                                if (primerInsert)
                                {
                                    insertQuery.Append("(" + contador + "");
                                    insertQuery.Append(", " + ultimoIdRol + ")"); 
                                    primerInsert = false;
                                }
                                else
                                {
                                    insertQuery.Append(",(" + contador + "");
                                    insertQuery.Append(", " + ultimoIdRol + ")");
                                }
                            }
                            contador++;
                        }
                    }

                    if (!rolSinFuncionalidad)
                    {
                        query = insertQuery.ToString();
                        command.CommandText = query;
                        command.ExecuteNonQuery();
                    }                    

                    sqlTransact.Commit();

                    
                    MessageBox.Show("La creacion del rol fue exitosa", "EXITO");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un error al crear rol el rol", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sqlTransact.Rollback();
                }
                finally
                {
                    if (conexion.State == System.Data.ConnectionState.Open)
                        conexion.Dispose();
                }
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
