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

namespace ClinicaFrba.Compra_Bono
{
    public partial class compraBono : Form
    {
        private string rol;
        private string usuario;
        private decimal total;
        private decimal cantid;
        public DBAccess Access { get; set; }
        public compraBono(string rol, string usuario)
        {
            InitializeComponent();
            Access = new DBAccess();
            this.rol= rol;
            this.usuario = usuario;
            verificarelrol();
        }

        private void verificarelrol()
        {
            if(rol.Equals("Administrativo"))
            {
                groupBox_bonosafi.Hide();
            }
            if (rol.Equals("Afiliado"))
            {
                groupBox_bonosadmi.Hide();
            }   

        }

        private void confirmar_Click(object sender, EventArgs e)
        {
            if (rol.Equals("Administrativo"))
            {
                cantid = Decimal.Parse(cantidad2.Text);
                total = obtenermontosegunplan(cantid);
                montoapagar2.Text = total.ToString();
                cargarenlabd(obtenerusuario());
            }

            if (rol.Equals("Afiliado"))
            {
                cantid = Decimal.Parse(cantidad.Text);
                total = obtenermontoconusuario(cantid);
                montoapagar.Text = total.ToString();
                cargarenlabd(usuario);
            }
        }

        private void cargarenlabd(string user)
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                conexion.Open();
                SqlTransaction sqlTransact = conexion.BeginTransaction();
                SqlCommand command = conexion.CreateCommand();
                command.Transaction = sqlTransact;
                try
                {
                    string query = String.Format("INSERT INTO [UN_CORTADO].[COMPRABONOS] ([Nombre_Usuario], [Cantidad_Bonos],[Precio_Total]) VALUES (@usuario,@cantbonos,@total)");
                    command.CommandText = query;

                    SqlParameter param = new SqlParameter("@usuario", user);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@cantbonos", cantid);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@total", total);
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    command.Parameters.Add(param);

                    command.ExecuteNonQuery();
                    sqlTransact.Commit();
                    MessageBox.Show("Operación realizada exitosamente.", "Exito");
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

        private decimal obtenermontoconusuario(decimal canti)
        {
            SqlConnection conexion = new SqlConnection(Access.Conexion);
            conexion.Open();
            string query = "SELECT Precio_Bono_Consulta FROM UN_CORTADO.PLANES WHERE Id=@idplan";
            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@idplan", obteneridplanconusuario());
            Decimal monto = Convert.ToDecimal(cmd.ExecuteScalar());
            return monto * canti;
        }

        private decimal obteneridplanconusuario()
        {
            SqlConnection conexion = new SqlConnection(Access.Conexion);
            conexion.Open();
            string query = "SELECT Id_Plan FROM UN_CORTADO.listado_afiliados WHERE Nombre_Usuario=@usuario";
            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            Decimal idplan = Convert.ToDecimal(cmd.ExecuteScalar());
            return idplan;
        }

        private Decimal obtenermontosegunplan(decimal cant)
        {
            SqlConnection conexion = new SqlConnection(Access.Conexion);
            conexion.Open();
            string query = "SELECT Precio_Bono_Consulta FROM UN_CORTADO.PLANES WHERE Id=@idplan";
            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@idplan", obteneridplansinusuario());
            Decimal monto = Convert.ToDecimal(cmd.ExecuteScalar());
            return monto*cant;
        }

        private Decimal obteneridplansinusuario()
        {
            SqlConnection conexion = new SqlConnection(Access.Conexion);
            conexion.Open();
            string query = "SELECT Id_Plan FROM UN_CORTADO.listado_afiliados WHERE Nombre_Usuario=@usuario";
            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@usuario", obtenerusuario());
            Decimal idplan = Convert.ToDecimal(cmd.ExecuteScalar());
            return idplan;
        }
    

        private void confirmar2_Click(object sender, EventArgs e)
        {
            if (verificarusuarioactivo().Equals(1))
            {
                confirmar_Click(sender, e);
            }
            else
            {
                MessageBox.Show("El afiliado ingresado se encuentra deshabilitado.", "Error");
            }


        }

        private string obtenerusuario()
        {
            string nroafiliadolargo = nroafi.Text;
            string nrofamilia = nroafiliadolargo.Substring(nroafiliadolargo.Length - 1);
            string nroafiliado = nroafiliadolargo.Remove(nroafiliadolargo.Length - 1);

            SqlConnection conexion = new SqlConnection(Access.Conexion);
            conexion.Open();
            string query = "SELECT Nombre_Usuario FROM UN_CORTADO.listado_afiliados WHERE Numero_Afiliado=@nroafiliado AND Numero_Familia=@nrofamilia";
            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@nroafiliado", nroafiliado);
            cmd.Parameters.AddWithValue("@nrofamilia", nrofamilia);
            string usuario = Convert.ToString(cmd.ExecuteScalar());
            return usuario;
        }

        private Decimal verificarusuarioactivo()
        {
            string nroafiliadolargo = nroafi.Text;
            string nrofamilia= nroafiliadolargo.Substring(nroafiliadolargo.Length - 1);
            string nroafiliado = nroafiliadolargo.Remove(nroafiliadolargo.Length - 1);

            SqlConnection conexion = new SqlConnection(Access.Conexion);
            conexion.Open();
            string query = "SELECT Habilitado FROM UN_CORTADO.listado_afiliados WHERE Numero_Afiliado=@nroafiliado AND Numero_Familia=@nrofamilia";
            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@nroafiliado", nroafiliado);
            cmd.Parameters.AddWithValue("@nrofamilia", nrofamilia);
            Decimal habilitado = Convert.ToDecimal(cmd.ExecuteScalar());
            return habilitado;
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
