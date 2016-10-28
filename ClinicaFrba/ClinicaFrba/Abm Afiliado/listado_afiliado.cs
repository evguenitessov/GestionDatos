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
    public partial class listado_afiliado : Form
    {
        public DBAccess Access { get; set; }
        SqlDataAdapter pagingAdapter;
        DataSet pagingDS;
        private string nombreplan;

        public listado_afiliado()
        {
            InitializeComponent();
            Access = new DBAccess();
        }

        private void bot_borrar_Click(object sender, EventArgs e)
        {
            usuario.Clear();
            nroafiliado.Clear();
        }

        private void grid_afiliados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.grid_afiliados.Columns[e.ColumnIndex].Name == "baja")
            {
                bajaparaelmiembro();
            }
            if (this.grid_afiliados.Columns[e.ColumnIndex].Name == "modificar")
            {
                string usu = (string)grid_afiliados.Rows[e.RowIndex].Cells["Nombre_Usuario"].Value.ToString();
                string eciv = (string)grid_afiliados.Rows[e.RowIndex].Cells["Estado_Civil"].Value.ToString();
                string canthijos = (string)grid_afiliados.Rows[e.RowIndex].Cells["Cantidad_Hijos"].Value.ToString();
                string idplan = (string)grid_afiliados.Rows[e.RowIndex].Cells["Id_Plan"].Value.ToString();
                string direc = (string)grid_afiliados.Rows[e.RowIndex].Cells["Direccion"].Value.ToString();
                string telef = (string)grid_afiliados.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                string mail = (string)grid_afiliados.Rows[e.RowIndex].Cells["Mail"].Value.ToString();

                
                string nombreplan= buscarnombreplan(idplan);

                Abm_Afiliado.modif_afiliado modifafi = new Abm_Afiliado.modif_afiliado(usu, eciv, canthijos, nombreplan, direc, telef, mail);
                this.Hide();
                modifafi.Show();
            }
        }

        private string buscarnombreplan(string idplanmed)
        {
            SqlConnection conexion = new SqlConnection(Access.Conexion);
            conexion.Open();
            string planmedico = " ";
            string query = "SELECT Id,Nombre FROM UN_CORTADO.PLANES WHERE Id=@idplanmed";
            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@idplanmed", idplanmed);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                planmedico = dr.GetString(1);
            }

            return planmedico;
        }

        private void bajaparaelmiembro()
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
                                                 "SET Habilitado = 0 WHERE Nombre_Usuario = '{0}'",
                                                 usuario.Text);
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    MessageBox.Show("El usuario fue dado de baja exitosamente.", "Exito");
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrió un error, vuelva a intentarlo.", "Error");
                    transaction.Rollback();
                }
                finally
                {
                    if (conexion.State == System.Data.ConnectionState.Open)
                        conexion.Dispose();
                }
            }
        }

        private void bot_buscar_Click(object sender, EventArgs e)
        {
            string nombre = "";
            string condicion = "WHERE";
            string nombreusuario = usuario.Text;
            string nroafi = nroafiliado.Text;
            string email = mail.Text;
            //crear vista datosafiliados
            if (!(nombreusuario.Equals("")))
            {
                nombre += string.Format("{0} Nombre_Usuario LIKE '%{1}%'", condicion, nombreusuario);
                condicion = "AND";

            }

            //if (!(nroafi.Equals("")))
            //{
            //    nombre += string.Format("{0} Numero_Afiliado LIKE '%{1}%'", condicion, nroafi);
            //    condicion = "AND";

            //}

            if (!(mail.Equals("")))
            {
                nombre += string.Format("{0} Mail = '{1}'", condicion, email);
                condicion = "AND";
            }

            cargarenlagrid(nombre);
        }

        private void cargarenlagrid(string filtros)
        {
            SqlConnection conexion = new SqlConnection(Access.Conexion);
            conexion.Open();

            pagingAdapter = new SqlDataAdapter("SELECT * FROM UN_CORTADO.listado_afiliados " + filtros + "", conexion); 
            pagingDS = new DataSet();
            pagingAdapter.Fill(pagingDS);
            conexion.Close();
            grid_afiliados.DataSource = pagingDS.Tables[0];
            pagingAdapter.Update(pagingDS.Tables[0]);
        }

    }
}
