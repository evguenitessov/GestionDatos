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

namespace ClinicaFrba.Login
{
    public partial class Login : Form
    {
        public DBAccess Access { get; set; }
        public string Contraseña { get; set; }
        public bool Estado { get; set; }
        public int Intentos { get; set; }

        public Login()
        {
            InitializeComponent();
            Access = new DBAccess();
        }        

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (user_txt.Text.Equals(""))
            {
                MessageBox.Show("El usuario no puede quedar vacio", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password_txt.Text.Equals(""))
            {
                MessageBox.Show("La contraseña no puede quedar vacia!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT u.Nombre_Usuario, u.Contraseña, u.Habilitado, u.Cantidad_Intentos FROM [GD2C2016].[UN_CORTADO].[USUARIOS] u " +
                                             "INNER JOIN [GD2C2016].[UN_CORTADO].[ROLPORUSUARIO] rxu " +
                                             "ON u.Nombre_Usuario = rxu.Nombre_Usuario " +
                                             "INNER JOIN [GD2C2016].[UN_CORTADO].[ROLES] r " +
                                             "ON r.Id = rxu.Id_Rol " +
                                             "WHERE u.Nombre_Usuario = '{0}'", user_txt.Text);

                SqlCommand cmd = new SqlCommand(query, conexion);

                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (!dr.Read())
                    {
                        MessageBox.Show("Acceso denegado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        user_txt.Text = "";
                        password_txt.Text = "";
                        user_txt.Focus();

                        return;
                    }

                    Contraseña = dr.GetString(1);
                    Estado = dr.GetBoolean(2);
                    Intentos = dr.GetInt16(3);
                }
                catch
                {

                }
            }

            if (!Estado) 
            {
                MessageBox.Show("La cuenta no esta habilitada", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }                

            if (!(Contraseña.Equals(password_txt.Text)))
            {
                Intentos++;
                if (Intentos == 3)
                    InhabilitarCuenta(Intentos);                                   
                else
                    SumarIntentosFallidos(Intentos);                 

                password_txt.Text = "";
                password_txt.Focus();
                return;
            }            
            else
            {
                ResetearIntentosDeIngreso(); 
            }

            IngresarAlSistema(Contraseña, Estado);                       
        }

        private void ResetearIntentosDeIngreso()
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                conexion.Open();
                SqlTransaction transaction = conexion.BeginTransaction();
                SqlCommand command = conexion.CreateCommand();
                command.Transaction = transaction;

                try
                {
                    string query = String.Format("UPDATE [GD2C2016].[UN_CORTADO].[USUARIOS] " +
                                                 "SET Cantidad_Intentos = 0 WHERE Nombre_Usuario = '{0}'",
                                                 user_txt.Text);
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
                finally
                {
                    if (conexion.State == System.Data.ConnectionState.Open)
                        conexion.Dispose();
                }
            }
        }

        private void SumarIntentosFallidos(int intentos)
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                conexion.Open();
                SqlTransaction transaction = conexion.BeginTransaction();
                SqlCommand command = conexion.CreateCommand();
                command.Transaction = transaction;

                try
                {
                    string query = String.Format("UPDATE [GD2C2016].[UN_CORTADO].[USUARIOS] " +
                                                 "SET Cantidad_Intentos = {0} WHERE Nombre_Usuario = '{1}'",
                                                 intentos, user_txt.Text);
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    transaction.Commit();

                    MessageBox.Show("Contraseña no válida", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
                finally
                {
                    if (conexion.State == System.Data.ConnectionState.Open)
                        conexion.Dispose();
                }
            }
        }

        private void InhabilitarCuenta(int intentos)
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                conexion.Open();
                SqlTransaction transaction = conexion.BeginTransaction();
                SqlCommand command = conexion.CreateCommand();
                command.Transaction = transaction;

                try
                {
                    string query = String.Format("UPDATE [GD2C2016].[UN_CORTADO].[USUARIOS] " +
                                                 "SET Habilitado = 0, Cantidad_Intentos = {0} WHERE Nombre_Usuario = '{1}'",
                                                 intentos, user_txt.Text);
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    transaction.Commit();

                    MessageBox.Show("Su cuenta ha sido inhabilitada por demasiados intentos fallidos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
                finally
                {
                    if (conexion.State == System.Data.ConnectionState.Open)
                        conexion.Dispose();
                }
            }
        }

        private void IngresarAlSistema(string contraseña, bool estado)
        {
            if (contraseña.Equals(password_txt.Text) && estado)
            {
                MessageBox.Show("Bienvenido/a" + " " + user_txt.Text, "EXITO");                
                Roles.Rol roles = new Roles.Rol(user_txt.Text);
                this.Hide();
                //roles.Activate();
                roles.ShowDialog();
                this.Show();
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {           
        }

        private void password_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void user_txt_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
