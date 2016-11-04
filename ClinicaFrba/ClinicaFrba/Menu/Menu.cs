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
                                            "WHERE r.Nombre = @Rol");

                SqlCommand cmd = new SqlCommand(query, conexion);

                SqlParameter param = new SqlParameter("@Rol", rol);
                param.SqlDbType = System.Data.SqlDbType.VarChar;
                cmd.Parameters.Add(param);

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

        private void button5_Click(object sender, EventArgs e)
        {
            Registrar_Agenta_Medico.registrar_agenda abmAgenda = new Registrar_Agenta_Medico.registrar_agenda();
            abmAgenda.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Registro_Llegada.registrar_llegada registroLlegada = new Registro_Llegada.registrar_llegada();
            registroLlegada.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta opción no está disponible por el momento", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Registro_Resultado.registroResultado registroResultado = new Registro_Resultado.registroResultado();
            registroResultado.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta opción no está disponible por el momento", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.menu_abmafiliado afi_menu = new Abm_Afiliado.menu_abmafiliado();
            afi_menu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta opción no está disponible por el momento", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Cancelar_Atencion.cancelarAtencion cancelAtencion = new Cancelar_Atencion.cancelarAtencion();
            cancelAtencion.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Este deberia ser el registrar un nuevo usuario?
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if(Rol.Equals("Afiliado"))
            {
                Compra_Bono.compraBono compraBono = new Compra_Bono.compraBono("Afiliado",Usuario);
                compraBono.Show();
                this.Hide();
            }
            if (Rol.Equals("Administrativo"))
            {
                Compra_Bono.compraBono compraBono = new Compra_Bono.compraBono("Administrativo", null);
                compraBono.Show();
                this.Hide();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Pedir_Turno.pedir_turno pedirTurno = new Pedir_Turno.pedir_turno();
            pedirTurno.Show();
        }
        
    }
}
