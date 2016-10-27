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
    public partial class alta_afiliado : Form
    {
        public DBAccess Access { get; set; }
        private string usuario;

        public alta_afiliado(string usuario)
        {
            InitializeComponent();
            Access = new DBAccess();
            inicializarcombobox();
            this.usuario = usuario;
        }

        private void inicializarcombobox()
        {
            inicializarcombofacil();
            inicializarcomboplanes();
        }

        private void inicializarcombofacil()
        {
            tipodoc.Items.Add("DNI");
            tipodoc.Items.Add("CI");
            tipodoc.Items.Add("LC");

            sexo.Items.Add("F");
            sexo.Items.Add("M");

            ecivil.Items.Add("Soltera/o");
            ecivil.Items.Add("Casada/o");
            ecivil.Items.Add("Viuda/o");
            ecivil.Items.Add("Concubinato");
            ecivil.Items.Add("Divorciada/o");
        }

        private void inicializarcomboplanes()
        {
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

        private void bot_borrar_Click(object sender, EventArgs e) //borra campos
        {
            nombre.Clear();
            apellido.Clear();
            tipodoc.SelectedIndex = -1;
            nrodoc.Clear();
            direccion.Clear();
            telef.Clear();
            mail.Clear();
            fechanac.Value = DateTime.Today;
            sexo.SelectedIndex = -1;
            ecivil.SelectedIndex = -1;
            canthijosfamcargo.Clear();
            planmed.SelectedIndex = -1;
        }

        private void bot_guardar_Click(object sender, EventArgs e) //guarda si son correctos en la bd
        {
            if (chequeartodoscamposcompletos().Equals(0) && chequeartipodatos().Equals(0))
            {
                cargarenlabd();
            }
            else 
            {
                MessageBox.Show("Verifique que todos los campos estén completados adecuadamente y los datos correctamente ingresados.", "Error al guardar");            
            }
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
                    string query = String.Format("INSERT INTO [UN_CORTADO].[AFILIADOS] ([Nombre_Usuario], [Estado_Civil],[Cantidad_Hijos],[Id_Plan]) VALUES (@usuario, @ecivil, @cant_hijos, @id_plan)");
                    command.CommandText = query;

                    SqlParameter param = new SqlParameter("@usuario", usuario);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@ecivil", ecivil.SelectedItem);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    int hijosfamacargo = Int32.Parse(canthijosfamcargo.Text);
                    param = new SqlParameter("@cant_hijos", hijosfamacargo);
                    param.SqlDbType = System.Data.SqlDbType.TinyInt;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@id_plan", ecivil.SelectedItem);
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    command.Parameters.Add(param);

                    command.ExecuteNonQuery();
                    sqlTransact.Commit();
                    MessageBox.Show("El afiliado ha sido registrado exitosamente.", "Exito");
                    verificarparapreguntar();
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

        private void verificarparapreguntar()
        {
            chequearhijosfamacargo();
            chequearestcivil();
        }

        private void chequearestcivil()
        {
            int hijosfamacargo= Int32.Parse(canthijosfamcargo.Text);
            if (ecivil.SelectedItem.Equals("Casada/o") || ecivil.SelectedItem.Equals("Concubinato") || hijosfamacargo > 0)
            {

            }
        }

        private void chequearhijosfamacargo()
        {
            throw new NotImplementedException();
        }

        private int chequeartodoscamposcompletos() //chequea que estén completos
        {
            if (nombre.Text.Equals("") || apellido.Text.Equals("") || tipodoc.SelectedIndex.Equals(-1) ||
                nrodoc.Text.Equals("") || direccion.Text.Equals("") || mail.Text.Equals("") || telef.Text.Equals("") ||
                sexo.SelectedIndex.Equals(-1) || ecivil.SelectedIndex.Equals(-1) || canthijosfamcargo.Text.Equals("") ||
                planmed.SelectedIndex.Equals(-1))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private int chequeartipodatos() //chequea los tipos de datos
        {
            if (IsNumeric(nombre.Text).Equals(true) || IsNumeric(apellido.Text).Equals(true) ||
                IsNumeric(nrodoc.Text).Equals(false) || IsNumeric(telef.Text).Equals(false) ||
                IsNumeric(canthijosfamcargo.Text).Equals(false))
            {
                return 1;
            }
            else
            {
                return 0;
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
