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
    public partial class modif_afiliado : Form
    {
        private string usu;
        private string eciv;
        private string canthijos;
        private string nombreplan;
        private string direc1;
        private string telef1;
        private string mail1;
        private int id_plan;

        public DBAccess Access { get; set; }

        public modif_afiliado()
        {
            InitializeComponent();
            Access = new DBAccess();
            cargardatos();
            cargarcomboboxes();
        }

        public modif_afiliado(string usu, string eciv, string canthijos, string nombreplan, string direc1, string telef1, string mail1)
        {
            InitializeComponent();
            Access = new DBAccess();

            this.usu = usu;
            this.eciv = eciv;
            this.canthijos = canthijos;
            this.nombreplan = nombreplan;
            this.direc1 = direc1;
            this.telef1 = telef1;
            this.mail1 = mail1;

            cargardatos();
            cargarcomboboxes();
        }

        private void cargardatos()
        {
            direc.Text = direc1;
            telef.Text = telef1;
            mail.Text = mail1;
            ecivil.Text = eciv;
            canthijosfamcargo.Text = canthijos;
            planmed.Text = nombreplan;
        }

        private void cargarcomboboxes()
        {
            ecivil.Items.Add("Soltera/o");
            ecivil.Items.Add("Casada/o");
            ecivil.Items.Add("Viuda/o");
            ecivil.Items.Add("Concubinato");
            ecivil.Items.Add("Divorciada/o");

            SqlConnection conexion = new SqlConnection(Access.Conexion);
            conexion.Open();
            string planmedico = " ";
            string query = "SELECT Nombre FROM UN_CORTADO.PLANES";
            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                planmed.Items.Add(dr[0]);
                planmedico = dr.GetString(0);
            }
        }

        private void bot_borrar_Click(object sender, EventArgs e)
        {
            direc.Clear();
            telef.Clear();
            mail.Clear();
            ecivil.SelectedIndex = -1;
            canthijosfamcargo.Clear();
            planmed.SelectedIndex = -1;
        }

        private void bot_guardar_Click(object sender, EventArgs e)
        {
            if (verificardatos().Equals(true))
            {
                //actualizarafiliados();
                actualizarcontacto();
            }
        }

        private void actualizarcontacto()
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                conexion.Open();
                SqlTransaction sqlTransact = conexion.BeginTransaction();
                SqlCommand command = conexion.CreateCommand();
                command.Transaction = sqlTransact;
                try
                {
                    string query = String.Format("UPDATE [UN_CORTADO].[CONTACTO] SET Direccion=@direc,Mail=@mail,Telefono=@telef WHERE Nombre_Usuario=@usuario");
                    command.CommandText = query;

                    SqlParameter param = new SqlParameter("@usuario", usu);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@direc", direc.Text);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@tel", telef.Text);
                    param.SqlDbType = System.Data.SqlDbType.NVarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@mail", mail.Text);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    command.ExecuteNonQuery();
                    sqlTransact.Commit();
                    MessageBox.Show("El afiliado ha sido modificado exitosamente.", "Exito");
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

        private void actualizarafiliados()
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                conexion.Open();
                SqlTransaction sqlTransact = conexion.BeginTransaction();
                SqlCommand command = conexion.CreateCommand();
                command.Transaction = sqlTransact;
                try
                {
                    string query = String.Format("UPDATE [UN_CORTADO].[AFILIADOS] SET Estado_Civil=@ecivil,Cantidad_Hijos=@canthijos,Id_Plan=@idplan WHERE Nombre_Usuario=@usuario");
                    command.CommandText = query;

                    SqlParameter param = new SqlParameter("@usuario", usu);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@ecivil", ecivil.SelectedItem);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    int hijosfamacargo = Int32.Parse(canthijosfamcargo.Text);
                    param = new SqlParameter("@canthijos", hijosfamacargo);
                    param.SqlDbType = System.Data.SqlDbType.TinyInt;
                    command.Parameters.Add(param);

                    buscaridplan();
                    param = new SqlParameter("@idplan", id_plan);
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    command.Parameters.Add(param);

                    command.ExecuteNonQuery();
                    sqlTransact.Commit();
                    MessageBox.Show("El afiliado ha sido modificado exitosamente.", "Exito");
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

        private void buscaridplan()
        {            
            SqlConnection conexion = new SqlConnection(Access.Conexion);
            conexion.Open();
            string query = "SELECT Id FROM UN_CORTADO.PLANES WHERE Nombre=@nombreplan";
            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@nombreplan", planmed.SelectedItem);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                id_plan = dr.GetInt32(0);
            }
        }

        private bool verificardatos()
        {
            if (direc.Text.Equals("") || telef.Text.Equals("") || mail.Text.Equals("") ||
                canthijosfamcargo.Text.Equals("") || IsNumeric(telef.Text).Equals(false) ||
                IsNumeric(canthijosfamcargo.Text).Equals(false))
            {
                MessageBox.Show("Verifique que los tipos de datos ingresados son correctos y/o que los campos estén completos.", "Error");
                return false;
            }
            else
            {
                return true;
            }

        }

        public static bool IsNumeric(string s) //verifica si todos los caracteres son numericos
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c) && c != '.')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
