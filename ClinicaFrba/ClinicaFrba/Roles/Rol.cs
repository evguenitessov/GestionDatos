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

namespace ClinicaFrba.Roles
{
    public partial class Rol : Form
    {
        public string Usuario { get; set; }
        public DBAccess Access { get; set; }    

        public Rol(string usuario)
        {
            InitializeComponent();            
            Access = new DBAccess();
            Usuario = usuario;
            CargarRoles();
        }

        private void CargarRoles()
        {                        
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT r.Nombre FROM [GD2C2016].[UN_CORTADO].[ROLES] r INNER JOIN [GD2C2016].[UN_CORTADO].[ROLPORUSUARIO] rxu " +
                                             "ON r.Id = rxu.Id_Rol WHERE rxu.Nombre_Usuario = '{0}'", Usuario);

                SqlCommand cmd = new SqlCommand(query, conexion);

                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        roles_cbx.Items.Add(dr[0]);
                    }

                    roles_cbx.SelectedIndex = 0;
                }
                catch
                {
                                        
                }                
            }            
        }

        private void Rol_FormClosing(object sender, FormClosingEventArgs e)
        {            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string rol = roles_cbx.SelectedItem.ToString();
            this.Hide();
            Menu.Menu menu = new Menu.Menu(Usuario, rol);            
            menu.ShowDialog();
            this.Show();
        }
    }
}
