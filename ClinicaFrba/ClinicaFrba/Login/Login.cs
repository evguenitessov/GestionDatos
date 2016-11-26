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
using System.Security.Cryptography;

namespace ClinicaFrba.Login
{
    public partial class Login : Form
    {
        public DBAccess Access { get; set; }
        public byte[] Contraseña { get; set; }
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
                                             "WHERE u.Nombre_Usuario = @UserName");

                SqlCommand cmd = new SqlCommand(query, conexion);

                SqlParameter param = new SqlParameter("@UserName", user_txt.Text);
                param.SqlDbType = System.Data.SqlDbType.VarChar;
                cmd.Parameters.Add(param);

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
                    
                    Contraseña = (byte[])dr.GetValue(1);
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

            if (!(CompararContraseña(Contraseña, password_txt.Text)))
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

        bool CompararContraseña(byte[] a1, string contraseña)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

            byte[] inputBytes = Encoding.UTF8.GetBytes(contraseña);
            byte[] a2 = provider.ComputeHash(inputBytes);

            if (a1.Length != a2.Length)
                return false;

            for (int i = 0; i < a1.Length; i++)
                if (a1[i] != a2[i])
                    return false;

            return true;
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
                                                 "SET Cantidad_Intentos = 0 WHERE Nombre_Usuario = @UserName");
                    command.CommandText = query;

                    SqlParameter param = new SqlParameter("@UserName", user_txt.Text);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

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
                                                 "SET Cantidad_Intentos = @Intentos WHERE Nombre_Usuario = @UserName");
                    command.CommandText = query;

                    SqlParameter param = new SqlParameter("@UserName", user_txt.Text);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@Intentos", intentos);
                    param.SqlDbType = System.Data.SqlDbType.TinyInt;
                    command.Parameters.Add(param);

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
                                                 "SET Habilitado = 0, Cantidad_Intentos = @Intentos WHERE Nombre_Usuario = @UserName");
                    command.CommandText = query;

                    SqlParameter param = new SqlParameter("@UserName", user_txt.Text);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@Intentos", intentos);
                    param.SqlDbType = System.Data.SqlDbType.TinyInt;
                    command.Parameters.Add(param);

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

        private void IngresarAlSistema(byte[] contraseña, bool estado)
        {            
            if (CompararContraseña(contraseña, password_txt.Text))            
            {
                MessageBox.Show("Bienvenido/a" + " " + user_txt.Text, "EXITO");                
                Roles.Rol roles = new Roles.Rol(user_txt.Text);
                this.Hide();                
                roles.ShowDialog();
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