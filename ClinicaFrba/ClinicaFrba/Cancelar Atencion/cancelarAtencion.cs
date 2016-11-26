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
using System.Web;
using System.Web.UI.WebControls;

namespace ClinicaFrba.Cancelar_Atencion
{
    public partial class cancelarAtencion : Form
    {
        public string Rol { get; set; }
        public string Usuario { get; set; }
        public DBAccess Access { get; set; }

        public cancelarAtencion(string rol, string usuario)
        {
            InitializeComponent();

            Rol = rol;
            Usuario = usuario;
            Access = new DBAccess();

            if (Rol == "Profesional")
                CargarDiasAgenda();
            else if (Rol == "Afiliado")
                CargarTurnos();
            
        }

        private void CargarDiasAgenda()
        {
            afiliado_grbx.Visible = false;
            profesional_grbx.Visible = true;

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT EP.[Id], A.[Id], E.[Nombre] AS Especialidad, CASE WHEN A.[Dia_Atencion] = 1 THEN 'Lunes' " +
                                             "WHEN A.[Dia_Atencion] = 7 THEN 'Domingo' " +
                                             "WHEN A.[Dia_Atencion] = 2 THEN 'Martes' " +
                                             "WHEN A.[Dia_Atencion] = 3 THEN 'Miércoles' " +
                                             "WHEN A.[Dia_Atencion] = 4 THEN 'Jueves' " +
                                             "WHEN A.[Dia_Atencion] = 5 THEN 'Viernes' " +
                                             "WHEN A.[Dia_Atencion] = 6 THEN 'Sábado' END AS Dia_Atencion, " +                                                
                                             "A.[Hora_Inicio], A.[Hora_Fin] " +
                                             "FROM [GD2C2016].[UN_CORTADO].[AGENDA] A, [UN_CORTADO].[ESPECIALIDADPORPROFESIONAL] EP, [UN_CORTADO].[PROFESIONALES] P, " +
                                             "[GD2C2016].[UN_CORTADO].[ESPECIALIDADES] E " +
                                             "WHERE A.[Id_Especialidad_Medico] = EP.[Id] AND EP.[Id_Medico] = P.[Nombre_Usuario] AND EP.[Id_Especialidad] = E.[Id] " +
                                             "AND P.Nombre_Usuario = @Usr AND EXISTS (SELECT 1 FROM [UN_CORTADO].[TURNOS] T WHERE [Id_Agenda] = A.[Id] AND [Disponible] IN (0, 1) " +
                                             "and not exists(select 1 from [UN_CORTADO].[ATENCIONMEDICA] where Id_turno = T.Id))");

                SqlCommand cmd = new SqlCommand(query, conexion);

                SqlParameter param = new SqlParameter("@Usr", Usuario);
                param.SqlDbType = System.Data.SqlDbType.VarChar;
                cmd.Parameters.Add(param);

                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    ArrayList roles = new ArrayList();
                    if (dr.HasRows)
                        foreach (DbDataRecord item in dr)
                            roles.Add(item);

                    agenda_dgrvw.DataSource = roles;

                    if (roles.Count != 0)
                    {
                        agenda_dgrvw.Columns["Id"].Visible = false;
                        agenda_dgrvw.Columns["Id1"].Visible = false;
                    }
                    else 
                    {
                        button1.Enabled = false;
                        groupBox2.Enabled = false;
                        dateTimePicker1.Enabled = false;
                        label7.Enabled = false;
                        tipo_cancel_txbx.Enabled = false;
                        detalle_txbx.Enabled = false;
                        label1.Enabled = false;
                        label2.Enabled = false;
                    }
                }
                catch
                {

                }
            }
                      
            agenda_dgrvw.TopLeftHeaderCell.Value = "Seleccionar";

            CargarEspecialidades();
        }

        private void CargarEspecialidades()
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {               
                string query = String.Format("SELECT DISTINCT EP.[Id], E.[Nombre] " +                                             
                                             "FROM [GD2C2016].[UN_CORTADO].[AGENDA] A, [UN_CORTADO].[ESPECIALIDADPORPROFESIONAL] EP, [UN_CORTADO].[PROFESIONALES] P, " +
                                             "[GD2C2016].[UN_CORTADO].[ESPECIALIDADES] E " +
                                             "WHERE A.[Id_Especialidad_Medico] = EP.[Id] AND EP.[Id_Medico] = P.[Nombre_Usuario] AND EP.[Id_Especialidad] = E.[Id] " +
                                             "AND P.Nombre_Usuario = @Usr AND EXISTS (SELECT 1 FROM [UN_CORTADO].[TURNOS] T WHERE [Id_Agenda] = A.[Id] " +
                                             "and not exists(select 1 from [UN_CORTADO].[ATENCIONMEDICA] where Id_turno = T.Id))");

                SqlCommand cmd = new SqlCommand(query, conexion);

                SqlParameter param = new SqlParameter("@Usr", Usuario);
                param.SqlDbType = System.Data.SqlDbType.VarChar;
                cmd.Parameters.Add(param);

                Dictionary<int, string> comboSource = new Dictionary<int, string>();

                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboSource.Add((int)dr[0], dr[1].ToString());
                    }

                    especialidades_cbx.DataSource = new BindingSource(comboSource, null);
                    especialidades_cbx.DisplayMember = "Value";
                    especialidades_cbx.ValueMember = "Key";

                    especialidades_cbx.SelectedIndex = 0;
                }
                catch(Exception ex)
                {

                }
            }
        }

        private void CargarTurnos()
        {
            profesional_grbx.Visible = false;
            afiliado_grbx.Visible = true;

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {               
                string query = String.Format("SELECT T.Id, T.Hora_Inicio, T.Hora_Fin, T.Fecha, E.Nombre AS Especialidad, T.Hora_Llegada_Afiliado " +
                                             "FROM [UN_CORTADO].[TURNOS] T, [UN_CORTADO].[ESPECIALIDADES] E " +
                                             "WHERE T.Especialidad = E.Id AND T.Disponible = 0 AND T.Id_Afiliado = @Usr and " +
                                             "not exists(select 1 from [UN_CORTADO].[ATENCIONMEDICA] where Id_turno = T.Id)");

                SqlCommand cmd = new SqlCommand(query, conexion);

                SqlParameter param = new SqlParameter("@Usr", Usuario);
                param.SqlDbType = System.Data.SqlDbType.VarChar;
                cmd.Parameters.Add(param);

                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    ArrayList roles = new ArrayList();
                    if (dr.HasRows)
                        foreach (DbDataRecord item in dr)
                            roles.Add(item);

                    turnos_dgrvw.DataSource = roles;

                    if (roles.Count != 0)
                    {
                        turnos_dgrvw.Columns["Id"].Visible = false;
                    }
                    else
                    {
                        button2.Enabled = false;                        
                    }
                }
                catch
                {

                }
            }
            
            turnos_dgrvw.TopLeftHeaderCell.Value = "Seleccionar";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tipo_cancel_txbx.Text) || string.IsNullOrEmpty(detalle_txbx.Text))
            {
                MessageBox.Show("El campo tipo de cancelacion o detalle no pueden quedar vacios.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                SqlCommand cmd = new SqlCommand("[UN_CORTADO].[CANCELAR_UN_DIA]", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@NOMBRE_USUARIO", Usuario);
                param.SqlDbType = System.Data.SqlDbType.VarChar;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ESPECIALIDAD_MEDICO", int.Parse(agenda_dgrvw.CurrentRow.Cells["Id"].Value.ToString()));
                param.SqlDbType = System.Data.SqlDbType.Int;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DETALLE_CANCELACION", detalle_txbx.Text);
                param.SqlDbType = System.Data.SqlDbType.VarChar;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TIPO_CANCELACION", tipo_cancel_txbx.Text);
                param.SqlDbType = System.Data.SqlDbType.VarChar;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FECHA_CAN", Convert.ToDateTime(dateTimePicker1.Text));
                param.SqlDbType = System.Data.SqlDbType.DateTime;
                cmd.Parameters.Add(param);                

                param = new SqlParameter("@FECHA_SISTEMA", Convert.ToDateTime(DBAccess.fechaSystem()));
                param.SqlDbType = System.Data.SqlDbType.DateTime;
                cmd.Parameters.Add(param);

                try
                {
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un error al cancelar la atención medica", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                }
                finally
                {
                    if (conexion.State == System.Data.ConnectionState.Open)
                        conexion.Dispose();
                }
            }                                              
            
            CargarDiasAgenda();
            tipo_cancel_txbx.Text = "";
            detalle_txbx.Text = "";
            MessageBox.Show("La cancelación de atención medica fue exitosa", "EXITO");
        }                

        private void button2_Click(object sender, EventArgs e)
        {            
            string diaTurno = (turnos_dgrvw.CurrentRow.Cells["Fecha"].Value.ToString()).Substring(0, 2);
            string diaSistema = (DBAccess.fechaSystem()).Substring(0, 2);

            if (diaTurno == diaSistema)
            {
                MessageBox.Show("No puede cancelar el turno el mismo dia de atencion.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("El campo tipo de cancelacion o detalle no pueden quedar vacios.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                conexion.Open();
                SqlTransaction sqlTransact = conexion.BeginTransaction();
                SqlCommand command = conexion.CreateCommand();
                command.Transaction = sqlTransact;


                try
                {
                    string query = String.Format("INSERT INTO [UN_CORTADO].[CANCELACIONES] ([Nombre_Usuario],[Id_Turno],[Detalle],[Tipo],[Fecha_Cancelacion]) " +
                                                 "VALUES(@NomUsr, @Turno, @Detalle, @Tipo, @Fecha)");
                    command.CommandText = query;
                    SqlParameter param = new SqlParameter("@NomUsr", Usuario);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@Turno", int.Parse(turnos_dgrvw.CurrentRow.Cells["Id"].Value.ToString()));
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@Detalle", textBox2.Text);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@Tipo", textBox1.Text);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@Fecha", Convert.ToDateTime(DBAccess.fechaSystem()));
                    param.SqlDbType = System.Data.SqlDbType.DateTime;
                    command.Parameters.Add(param);

                    command.ExecuteNonQuery();


                    query = String.Format("UPDATE [GD2C2016].[UN_CORTADO].[TURNOS] SET [Disponible] = 1, [Id_Afiliado] = NULL, " +
                                          "[Hora_Llegada_Afiliado] = NULL WHERE [Id] = @IdTurno");
                    command.CommandText = query;
                    param = new SqlParameter("@IdTurno", int.Parse(turnos_dgrvw.CurrentRow.Cells["Id"].Value.ToString()));
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    command.Parameters.Add(param);

                    command.ExecuteNonQuery();

                    sqlTransact.Commit();

                    CargarTurnos();
                    tipo_cancel_txbx.Text = "";
                    detalle_txbx.Text = "";
                    MessageBox.Show("La cancelación de atención medica fue exitosa", "EXITO");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un error al cancelar la atención medica", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sqlTransact.Rollback();
                }
                finally
                {
                    if (conexion.State == System.Data.ConnectionState.Open)
                        conexion.Dispose();
                }
            } 
        }

        private void aceptar_fechas_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tipo_cancel_txbx.Text) || string.IsNullOrEmpty(detalle_txbx.Text))
            {
                MessageBox.Show("El campo tipo de cancelacion o detalle no pueden quedar vacios.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                SqlCommand cmd = new SqlCommand("[UN_CORTADO].[CANCELAR_RANGO_FECHA]", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@NOMBRE_USUARIO", Usuario);
                param.SqlDbType = System.Data.SqlDbType.VarChar;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FECHA_DESDE", Convert.ToDateTime(desde_fecha.Text));
                param.SqlDbType = System.Data.SqlDbType.Date;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FECHA_HASTA", Convert.ToDateTime(hasta_fecha.Text));
                param.SqlDbType = System.Data.SqlDbType.Date;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ESPECIALIDAD_MEDICO", ((KeyValuePair<int, string>)especialidades_cbx.SelectedItem).Key);
                param.SqlDbType = System.Data.SqlDbType.Int;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DETALLE_CANCELACION", detalle_txbx.Text);
                param.SqlDbType = System.Data.SqlDbType.VarChar;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@TIPO_CANCELACION", tipo_cancel_txbx.Text);
                param.SqlDbType = System.Data.SqlDbType.VarChar;
                cmd.Parameters.Add(param);                

                param = new SqlParameter("@FECHA_SISTEMA", Convert.ToDateTime(DBAccess.fechaSystem()));
                param.SqlDbType = System.Data.SqlDbType.DateTime;
                cmd.Parameters.Add(param);

                try
                {
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un error al cancelar la atención medica", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conexion.State == System.Data.ConnectionState.Open)
                        conexion.Dispose();
                }
            }             

            CargarDiasAgenda();
            tipo_cancel_txbx.Text = "";
            detalle_txbx.Text = "";
            MessageBox.Show("La cancelación de atención medica fue exitosa", "EXITO");
        }
    }
}
