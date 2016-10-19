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

namespace ClinicaFrba.Menu
{
    public partial class Menu : Form
    {
        public string Usuario { get; set; }
        public DBAccess Access { get; set; }
        public string Rol { get; set; }

        public Menu(string usuario, string rol)
        {
            InitializeComponent();
            Access = new DBAccess();
            Usuario = usuario;
            Rol = rol;
            CargarFuncionalidades(rol);
        }

        private void CargarFuncionalidades(string rol)
        {            
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT f.Nombre  FROM [GD2C2016].[UN_CORTADO].[FUNCIONES] f " +
                                            "INNER JOIN [GD2C2016].[UN_CORTADO].[FUNCIONESPORROL] fxr " +
                                            "ON f.Id = fxr.Id_Funcion " +
                                            "INNER JOIN [GD2C2016].[UN_CORTADO].[ROLES] r " +
                                            "ON fxr.Id_Rol = r.Id " +
                                            "WHERE r.Nombre = '{0}'", rol);

                SqlCommand cmd = new SqlCommand(query, conexion);

                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<string> funcionalidades = new List<string>();
                    while (dr.Read())
                    {
                        funcionalidades.Add(dr.GetString(0));
                    }
                    
                    MostrarFuncionalidades(funcionalidades);                    
                    
                }
                catch
                {

                }
            }            
        }

        public void MostrarFuncionalidades(List<string> funcionalidades)
        {
            if (!funcionalidades.Contains(button5.Text)) button5.Hide();
            if (!funcionalidades.Contains(button12.Text)) button12.Hide();                                    
            if (!funcionalidades.Contains(button4.Text)) button4.Hide();
            if (!funcionalidades.Contains(btnAbmRol.Text)) btnAbmRol.Hide();
            if (!funcionalidades.Contains(button10.Text)) button10.Hide();
            if (!funcionalidades.Contains(button3.Text)) button3.Hide();
            if (!funcionalidades.Contains(button6.Text)) button6.Hide();
            if (!funcionalidades.Contains(button2.Text)) button2.Hide();
            if (!funcionalidades.Contains(button8.Text)) button8.Hide();
            if (!funcionalidades.Contains(button7.Text)) button7.Hide();
            if (!funcionalidades.Contains(button11.Text)) button11.Hide();
            if (!funcionalidades.Contains(button9.Text)) button9.Hide();            
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {            
            this.DialogResult = DialogResult.OK;
        }

        private void btnAbmRol_Click(object sender, EventArgs e)
        {
             AbmRol.AbmRoles abmRoles = new AbmRol.AbmRoles();
             abmRoles.Show();
        }
        
    }
}
