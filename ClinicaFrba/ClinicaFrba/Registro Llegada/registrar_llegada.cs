using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
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
                string query = String.Format("SELECT DISTINCT Apellido +' '+  Nombre  AS Apellido_Y_Nombre  FROM [GD2C2016].[UN_CORTADO].[registro_llegada] ORDER BY Apellido_Y_Nombre");
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
                string query = String.Format("SELECT Especialidades FROM [GD2C2016].[UN_CORTADO].[registro_llegada] WHERE (Apellido + ' ' + Nombre)=@NombreMedico");
                SqlCommand cmd = new SqlCommand(query, conexion);

                SqlParameter param = new SqlParameter("@NombreMedico", comboBusqueda.SelectedItem);
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
        private void CargarProfesionalSegunEspecialidad(){
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT DISTINCT Apellido +' '+  Nombre  AS Apellido_Y_Nombre FROM [GD2C2016].[UN_CORTADO].[registro_llegada] WHERE Especialidades=@NombreEspecialidad ORDER BY Apellido_Y_Nombre");
                SqlCommand cmd = new SqlCommand(query, conexion);

                SqlParameter param = new SqlParameter("@NombreEspecialidad", comboBusqueda.SelectedItem);
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
        private void registrar_llegada_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'gD2C2016DataSet.TURNOS' Puede moverla o quitarla según sea necesario.
            
            pnlCrit.Visible = false;
            checkProfesional.Checked = true;
            checkProfesional.Enabled = false;
            textBox1.Text = "1";
            textBox2.Text = "2";
        }
        private void HabilitarUsuarios()
        {
            groupBox3.Visible = true;
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT Apellido + ' ' + Nombre FROM GD2C2016.UN_CORTADO.CONTACTO C WHERE C.Nombre_Usuario IN (SELECT Nombre_Usuario FROM GD2C2016.UN_CORTADO.listado_afiliados) ORDER BY 1");
                SqlCommand cmd = new SqlCommand(query, conexion);

                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboAfiliado.Items.Add(dr[0]);
                    }

                  comboAfiliado.SelectedIndex = 0;
                }

                catch
                {

                }
            }
            
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
            comboBusqueda2.Items.Clear();
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
            comboBusqueda2.Items.Clear();
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

        private void button1_Click(object sender, EventArgs e)
        {
            cargarTurnos();
        }

        private void cargarTurnos() 
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT T.Id ,T.Hora_Inicio , T.Hora_Fin, T.Fecha FROM UN_CORTADO.TURNOS T WHERE T.Id_Agenda IN (SELECT ID_AGENDA FROM [GD2C2016].[UN_CORTADO].[ProfesionalesYSusEspecialidades] P WHERE ((P.APELLIDO_PROFESIONAL +' '+  P.NOMBRE_PROFESIONAL) =@NombreProfesional AND T.Disponible = 0 AND Id_Afiliado IS NULL AND Hora_Llegada_Afiliado IS NULL)) ");
                SqlCommand cmd = new SqlCommand(query, conexion);

                if (textBox1.Text == "1" && textBox2.Text == "2")
                {
                    SqlParameter param = new SqlParameter("@NombreProfesional", comboBusqueda.SelectedItem);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    cmd.Parameters.Add(param);
                }
                else 
                {
                    SqlParameter param = new SqlParameter("@NombreProfesional", comboBusqueda2.SelectedItem);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    cmd.Parameters.Add(param);
                }
                
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();                   

                    ArrayList turnos = new ArrayList();
                    if (dr.HasRows)
                        foreach (DbDataRecord item in dr)
                            turnos.Add(item);

                    dataGridView1.DataSource = turnos;

                    dataGridView1.Columns["Id"].Visible = false;
                    HabilitarUsuarios();
                }

                catch
                {
                    MessageBox.Show("No hay turnos para el profesional en esa especialidad.", "ADVERTENCIA");
                }                
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
             using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT B.id FROM GD2C2016.UN_CORTADO.BONOS B WHERE B.Id_Compra_Bono IN (SELECT id FROM GD2C2016.UN_CORTADO.compraDeBonos C WHERE C.apellido + ' ' + C.Nombre=@NombreAfiliado) AND Habilitado=@habilitado");
                SqlCommand cmd = new SqlCommand(query, conexion);

                SqlParameter param = new SqlParameter("@NombreAfiliado", comboAfiliado.SelectedItem);
                param.SqlDbType = System.Data.SqlDbType.VarChar;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@habilitado", 1);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();                    

                    ArrayList bonos = new ArrayList();
                    if (dr.HasRows)
                    {
                        foreach (DbDataRecord item in dr)
                            bonos.Add(item);

                        gridBonosDisponibles.DataSource = bonos;

                    }
                    else 
                    {
                        MessageBox.Show("El afiliado no tiene bonos disponibles.","ADVERTENCIA");
                    
                    }
                }

                catch
                {

                }
               
            }
            
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                conexion.Open();
                string query = "UPDATE UN_CORTADO.TURNOS SET Hora_Llegada_Afiliado=GETDATE(),Id_Afiliado=@afiliado WHERE Id=@idturno";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@idturno", Convert.ToInt64(dataGridView1.CurrentRow.Cells["Id"].Value));
                cmd.Parameters.AddWithValue("@afiliado", buscaridafiliado());
                cmd.ExecuteNonQuery();

                string query2 = "INSERT INTO UN_CORTADO.ATENCIONMEDICA(Fecha_Hora,Id_turno,Bono_Usado) VALUES (GETDATE(),@idturno,@bonousado)";
                SqlCommand cmd2 = new SqlCommand(query2, conexion);
                cmd2.Parameters.AddWithValue("@idturno", Convert.ToInt64(dataGridView1.CurrentRow.Cells["Id"].Value));
                cmd2.Parameters.AddWithValue("@bonousado", Convert.ToInt64(gridBonosDisponibles.CurrentRow.Cells["Id"].Value));
                cmd2.ExecuteNonQuery();

                string query3 = "UPDATE UN_CORTADO.BONOS SET Habilitado=@habilitado, Nombre_Usuario_Uso=@NombreUsuario, Fecha_Uso=@fechauso WHERE Id=@idBono";
                SqlCommand cmd3 = new SqlCommand(query3, conexion);
                cmd3.Parameters.AddWithValue("@habilitado", 0);
                cmd3.Parameters.AddWithValue("@fechauso", Convert.ToDateTime(DBAccess.fechaSystem()));
                cmd3.Parameters.AddWithValue("@idBono", Convert.ToInt64(gridBonosDisponibles.CurrentRow.Cells["Id"].Value));
                cmd3.Parameters.AddWithValue("@NombreUsuario", buscaridafiliado());
                cmd3.ExecuteNonQuery();

                MessageBox.Show("Se registró la llegada correctamente", "EXITO");   
            }                     
        }

        private object buscaridafiliado()
        {
            SqlConnection conexion = new SqlConnection(Access.Conexion);
            conexion.Open();
            string query = "SELECT Nombre_Usuario FROM UN_CORTADO.CONTACTO WHERE Nombre=@nombre AND Apellido=@apellido";
            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@nombre", conseguir_nom());
            cmd.Parameters.AddWithValue("@apellido", conseguir_ape());
            string usuario = (string) cmd.ExecuteScalar();
            return usuario; 
        }

        private string conseguir_nom()
        {
            string[] nom = comboAfiliado.SelectedItem.ToString().Split(' ');
            return nom[1];
        }

        private string conseguir_ape()
        {
            string[] ape = comboAfiliado.SelectedItem.ToString().Split(' ');
            return ape[0];
        }

}

}
