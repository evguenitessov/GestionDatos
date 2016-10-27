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
                //abre formulario de modificacion y carga datos
            }
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

            //if (!(mail.Equals("")))
            //{
            //    nombre += string.Format("{0} Mail = '{1}'", condicion, email);
            //    condicion = "AND";
            //}

            //if (!(tipodoc.Equals("")))
            //{
            //    nombre += string.Format("{0} Contacto_Mail LIKE '%{1}%'", condicion, tipodoc);
            //    condicion = "AND";
            //}

            cargarenlagrid(nombre);
        }

        private void cargarenlagrid(string filtros)
        {
            SqlConnection conexion = new SqlConnection(Access.Conexion);
            conexion.Open();

            //crear vista datosafiliados
            pagingAdapter = new SqlDataAdapter("SELECT * FROM UN_CORTADO.AFILIADOS " + filtros + "", conexion); 
            pagingDS = new DataSet();
            pagingAdapter.Fill(pagingDS);
            conexion.Close();
            grid_afiliados.DataSource = pagingDS.Tables[0];
            pagingAdapter.Update(pagingDS.Tables[0]);
        }

    }
}
