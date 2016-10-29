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

namespace ClinicaFrba.Registro_Llegada
{
    public partial class registrar_llegada : Form
    {
        public DBAccess Access { get; set; }
        public registrar_llegada()
        {
            InitializeComponent();
            Access = new DBAccess();
            CargarProfesionales();
        }

        private void CargarProfesionales()
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT Apellido +' '+ Nombre as Apellido_Y_Nombre FROM [GD2C2016].[UN_CORTADO].[CONTACTO] C ,[GD2C2016].[UN_CORTADO].[PROFESIONALES] P WHERE C.Nombre_Usuario=P.Nombre_Usuario ORDER BY Apellido");

                SqlCommand cmd = new SqlCommand(query, conexion);

               try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBusqueda.Items.Add(dr[0]);
                    }

                    comboBusqueda.SelectedIndex = 0;
                }
                catch
                {

                }
            }
        }
        private void CargarEspecialidades()
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT Nombre FROM [GD2C2016].[UN_CORTADO].ESPECIALIDADES ORDER BY Nombre");

                SqlCommand cmd = new SqlCommand(query, conexion);

               try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBusqueda.Items.Add(dr[0]);
                    }

                        comboBusqueda.SelectedIndex = 0;
                }
                catch
                {

                }
            }
        }
        private void CargarEspecialidadSegunProfesional()
        {   
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT E.Nombre FROM [GD2C2016].[UN_CORTADO].ESPECIALIDADES E WHERE E.Id IN(SELECT Id_Especialidad FROM [GD2C2016].[UN_CORTADO].ESPECIALIDADPORPROFESIONAL EP WHERE EP.Id_Medico=(SELECT Nombre_Usuario FROM [GD2C2016].[UN_CORTADO].CONTACTO C WHERE (C.Apellido + ' ' + C.Nombre)= 'Acosta SAYA' ))");

                SqlCommand cmd = new SqlCommand(query, conexion);


                SqlParameter param = new SqlParameter("@NombreMedico", comboBusqueda.SelectedText);
                param.SqlDbType = System.Data.SqlDbType.VarChar;
                cmd.Parameters.Add(param);


               try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBusqueda2.Items.Add(dr[0]);
                    }

                        comboBusqueda2.SelectedIndex = 0;
                     }
                    
                catch
                {
                   
                }
            }
        }
        private void CargarProfesionalSegunEspecialidad(){}
        private void registrar_llegada_Load(object sender, EventArgs e)
        {
            pnlCrit.Visible = false;
            checkProfesional.Checked = true;
            checkProfesional.Enabled = false;
            textBox1.Text = "1";
            textBox2.Text = "2";
        }

        private void btnCrit_Click(object sender, EventArgs e)
        {
            if (pnlCrit.Visible == false)
            {
                pnlCrit.Visible = true;
            }
            else {
                pnlCrit.Visible = false;
            }
        }

        private void checkProfesional_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "2" && textBox2.Text == "1")
            {
                checkEspecialidad.Checked = false;
                checkProfesional.Checked = true;                
                pnlCrit.Visible = false;
                groupBox1.Text = "Búsqueda por Profesional";
                groupBox2.Text = "Seleccionar Especialidad";
                comboBusqueda.Items.Clear();
                CargarProfesionales();
            }
            textBox1.Text = "1";
            textBox2.Text = "2";
            checkEspecialidad.Enabled = true;
            checkProfesional.Enabled = false;
        }

        private void checkEspecialidad_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "1" && textBox2.Text == "2")
            {
                checkProfesional.Checked = false;
                checkEspecialidad.Checked = true;
                pnlCrit.Visible = false;
                groupBox1.Text = "Búsqueda por Especialidad";
                groupBox2.Text = "Seleccionar Profesional";
                comboBusqueda.Items.Clear();
                CargarEspecialidades();
            }
            textBox1.Text = "2";
            textBox2.Text = "1";
            checkEspecialidad.Enabled = false;            
            checkProfesional.Enabled = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            comboBusqueda2.Items.Clear();
            if (checkProfesional.Checked==true)
            {   
                CargarEspecialidadSegunProfesional();
            }
            else
            {
                CargarProfesionalSegunEspecialidad();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
