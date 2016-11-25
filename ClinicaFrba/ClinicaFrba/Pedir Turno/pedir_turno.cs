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

namespace ClinicaFrba.Pedir_Turno
{
    public partial class pedir_turno : Form
    {
       public DBAccess Access { get; set; }
       public pedir_turno()
        {
            InitializeComponent();
            Access = new DBAccess();
            profesional.Hide();
            fecha.Hide();
            cargarespecialidades();
        }

        private void cargarespecialidades()
        {
            SqlConnection conexion = new SqlConnection(Access.Conexion);
            conexion.Open();
            string query = "SELECT Nombre FROM UN_CORTADO.ESPECIALIDADES";
            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                combo_especialidades.Items.Add(dr[0]);
            }
        }

        private void cargarprofesionales()
        {
            String query = " SELECT NOMBRE_PROFESIONAL,APELLIDO_PROFESIONAL FROM UN_CORTADO.ProfesionalesYSusEspecialidades WHERE NOMBRE_ESPECIALIDAD=@especialidad";
            SqlConnection con = new SqlConnection(Access.Conexion);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@especialidad", combo_especialidades.SelectedItem.ToString());
            SqlDataReader dr;
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string nombre_completo = dr["APELLIDO_PROFESIONAL"] + "," + dr["NOMBRE_PROFESIONAL"];
                    combo_profesionales.Items.Add(nombre_completo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error","ERROR");
            }
        }

        private void cargarfechas()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Access.Conexion))
            {
                Int16 especialidad = conseguir_id_especialidad();
                String usuario_profesional = conseguir_usuario_profesional();
                using (SqlCommand cmd = new SqlCommand("[UN_CORTADO].[TURNOS_DISPONIBLES]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ESPECIALIDAD", SqlDbType.Int).Value = especialidad;
                    cmd.Parameters.Add("@MEDICO", SqlDbType.VarChar).Value = usuario_profesional;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    try
                    {
                        con.Open();
                        da.Fill(dt);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ocurrio un error", "Error");
                    }
                    finally
                    {
                        if (con.State == ConnectionState.Open)
                            con.Close();
                    }

                    grid_fechas.DataSource = dt;
                }
            }
        }

        private short conseguir_id_especialidad()
        {
            SqlConnection conexion = new SqlConnection(Access.Conexion);
            conexion.Open();
            string query = "SELECT Id FROM UN_CORTADO.ESPECIALIDADES WHERE Nombre=@nombre";
            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@nombre", combo_especialidades.SelectedItem.ToString());
            short id = Convert.ToInt16(cmd.ExecuteScalar());
            return id; 
        }

        private string conseguir_usuario_profesional()
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
            string[] nom = combo_profesionales.SelectedItem.ToString().Split(',');
            return nom[1];
        }

        private string conseguir_ape()
        {
            string[] ape = combo_profesionales.SelectedItem.ToString().Split(',');
            return ape[0];
        }

        private void aceptar_espec_Click(object sender, EventArgs e)
        {
            profesional.Show();
            cargarprofesionales();  
        }

        private void aceptar_profesional_Click_1(object sender, EventArgs e)
        {
            fecha.Show();
            cargarfechas();
        }

        private void aceptar_fecha_Click_1(object sender, EventArgs e)
        {
            //using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            //{
            //    conexion.Open();
            //    SqlTransaction sqlTransact = conexion.BeginTransaction();
            //    SqlCommand command = conexion.CreateCommand();
            //    command.Transaction = sqlTransact;
            //    try
            //    {
            //        string query = String.Format("INSERT INTO [UN_CORTADO].[TURNOS]([Id_Agenda],[Hora_Inicio],[Hora_Fin],[Fecha],[Especialidad],[Disponible]) VALUES (@idagenda,@horainicio,@horafin,@fecha,@especialidad,@disponible)");
            //        command.CommandText = query;

            //        SqlParameter param = new SqlParameter("@idagenda", idagenda);
            //        param.SqlDbType = System.Data.SqlDbType.Int;
            //        command.Parameters.Add(param);

            //        param = new SqlParameter("@horainicio", horainicio);
            //        param.SqlDbType = System.Data.SqlDbType.Time;
            //        command.Parameters.Add(param);

            //        param = new SqlParameter("@horafin", horafin);
            //        param.SqlDbType = System.Data.SqlDbType.Time;
            //        command.Parameters.Add(param);

            //        param = new SqlParameter("@fecha", fecha);
            //        param.SqlDbType = System.Data.SqlDbType.Date;
            //        command.Parameters.Add(param);

            //        param = new SqlParameter("@id_especialidad", id_especialidad);
            //        param.SqlDbType = System.Data.SqlDbType.VarChar;
            //        command.Parameters.Add(param);

            //        param = new SqlParameter("@disponible", 1);
            //        param.SqlDbType = System.Data.SqlDbType.Int;
            //        command.Parameters.Add(param);

            //        command.ExecuteNonQuery();
            //        sqlTransact.Commit();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Ocurrió un error, vuelva a intentarlo", "Error");
            //        sqlTransact.Rollback();
            //    }
            //    finally
            //    {
            //        if (conexion.State == System.Data.ConnectionState.Open)
            //            conexion.Dispose();
            //    }
            //}
        }

    }
}


