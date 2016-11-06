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
                string query = String.Format("SELECT A.[Id], E.[Nombre] AS Especialidad, CASE WHEN A.[Dia_Atencion] = 1 THEN 'Lunes' " +
                                             "WHEN A.[Dia_Atencion] = 7 THEN 'Domingo' " +
                                             "WHEN A.[Dia_Atencion] = 2 THEN 'Martes' " +
                                             "WHEN A.[Dia_Atencion] = 3 THEN 'Miércoles' " +
                                             "WHEN A.[Dia_Atencion] = 4 THEN 'Jueves' " +
                                             "WHEN A.[Dia_Atencion] = 5 THEN 'Viernes' " +
                                             "WHEN A.[Dia_Atencion] = 6 THEN 'Sábado' END AS Dia_Atencion, " +                                                
                                             "A.[Fecha_Desde], A.[Fecha_Hasta], A.[Hora_Inicio], A.[Hora_Fin] " +
                                             "FROM [GD2C2016].[UN_CORTADO].[AGENDA] A, [UN_CORTADO].[ESPECIALIDADPORPROFESIONAL] EP, [UN_CORTADO].[PROFESIONALES] P, " +
                                             "[GD2C2016].[UN_CORTADO].[ESPECIALIDADES] E " +
                                             "WHERE A.[Id_Especialidad_Medico] = EP.[Id] AND EP.[Id_Medico] = P.[Nombre_Usuario] AND EP.[Id_Especialidad] = E.[Id] " +
                                             "AND P.Nombre_Usuario = @Usr AND EXISTS (SELECT 1 FROM [UN_CORTADO].[TURNOS] WHERE [Id_Agenda] = A.[Id])");

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
                }
                catch
                {

                }
            }

            agenda_dgrvw.Columns["Id"].Visible = false;
            agenda_dgrvw.TopLeftHeaderCell.Value = "Seleccionar";
        }

        private void CargarTurnos()
        {
            profesional_grbx.Visible = false;
            afiliado_grbx.Visible = true;

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT T.Id, T.Hora_Inicio, T.Hora_Fin, T.Fecha, E.Nombre AS Especialidad, T.Hora_Llegada_Afiliado, T.Bono_Usado " + 
                                            "FROM [UN_CORTADO].[TURNOS] T, [UN_CORTADO].[ESPECIALIDADES] E " +
                                            "WHERE T.Especialidad = E.Id AND T.Disponible = 0 AND T.Id_Afiliado = @Usr");

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
                }
                catch
                {

                }
            }

            turnos_dgrvw.Columns["Id"].Visible = false;
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
            List<int> array = TurnosDeAgenda();

            foreach (int item in array)
            {
                using (SqlConnection conexion = new SqlConnection(Access.Conexion))
                {
                    conexion.Open();
                    SqlTransaction sqlTransact = conexion.BeginTransaction();
                    SqlCommand command = conexion.CreateCommand();
                    command.Transaction = sqlTransact;

                    try
                    {
                        string query = String.Format("DELETE FROM [UN_CORTADO].[CANCELACIONES] WHERE [Id_Turno] = @Turno");
                        command.CommandText = query;

                        SqlParameter param = new SqlParameter("@Turno", item);
                        param.SqlDbType = System.Data.SqlDbType.Int;
                        command.Parameters.Add(param);

                        command.ExecuteNonQuery();

                        sqlTransact.Commit();

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

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                conexion.Open();
                SqlTransaction sqlTransact = conexion.BeginTransaction();
                SqlCommand command = conexion.CreateCommand();
                command.Transaction = sqlTransact;

                try
                {
                    string query = "";
                    SqlParameter param = new SqlParameter();

                    query = String.Format("DELETE FROM [GD2C2016].[UN_CORTADO].[TURNOS] WHERE [Id_Agenda] = @Agenda");
                    command.CommandText = query;
                    param = new SqlParameter("@Agenda", int.Parse(agenda_dgrvw.CurrentRow.Cells["Id"].Value.ToString()));
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    command.Parameters.Add(param);

                    command.ExecuteNonQuery();

                    sqlTransact.Commit();

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
            
            CargarDiasAgenda();
            tipo_cancel_txbx.Text = "";
            detalle_txbx.Text = "";
            MessageBox.Show("La cancelación de atención medica fue exitosa", "EXITO");
        }

        private List<int> TurnosDeAgendaPeriodo()
        {
            List<int> turnos = new List<int>();

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT T.[Id] FROM [UN_CORTADO].[TURNOS] T, [UN_CORTADO].[AGENDA] A, [UN_CORTADO].[ESPECIALIDADPORPROFESIONAL] EP " +
                                             "WHERE T.[Fecha] BETWEEN @Fecha_Desde AND @Fecha_Hasta AND T.[Id_Agenda] = A.[Id] AND " + 
                                             "A.[Id_Especialidad_Medico] = EP.[Id] AND EP.[Id_Medico] = @Usr");

                SqlCommand cmd = new SqlCommand(query, conexion);                

                SqlParameter param = new SqlParameter("@Fecha_Desde", Convert.ToDateTime(desde_fecha.Text));
                param.SqlDbType = System.Data.SqlDbType.Date;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Fecha_Hasta", Convert.ToDateTime(hasta_fecha.Text));
                param.SqlDbType = System.Data.SqlDbType.Date;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Usr", Convert.ToDateTime(hasta_fecha.Text));
                param.SqlDbType = System.Data.SqlDbType.VarChar;
                cmd.Parameters.Add(param);

                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                        foreach (DbDataRecord item in dr)
                            turnos.Add(item.GetInt32(0));
                }
                catch
                {

                }
            }

            return turnos;

        }

        private List<int> TurnosDeAgenda()
        {
            List<int> turnos = new List<int>();

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT [Id] FROM [UN_CORTADO].[TURNOS] WHERE [Id_Agenda] = @Agenda");

                SqlCommand cmd = new SqlCommand(query, conexion);

                cmd.CommandText = query;
                SqlParameter param = new SqlParameter("@Agenda", int.Parse(agenda_dgrvw.CurrentRow.Cells["Id"].Value.ToString()));
                param.SqlDbType = System.Data.SqlDbType.Int;
                cmd.Parameters.Add(param);

                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    
                    if (dr.HasRows)
                        foreach (DbDataRecord item in dr)
                            turnos.Add(item.GetInt32(0));                    
                }
                catch
                {

                }
            }

            return turnos;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
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

                    param = new SqlParameter("@Detalle", detalle_txbx.Text);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@Tipo", tipo_cancel_txbx.Text);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@Fecha", Convert.ToDateTime(DBAccess.fechaSystem()));
                    param.SqlDbType = System.Data.SqlDbType.DateTime;
                    command.Parameters.Add(param);

                    command.ExecuteNonQuery();


                    query = String.Format("UPDATE [GD2C2016].[UN_CORTADO].[TURNOS] SET [Disponible] = 1, [Id_Afiliado] = NULL, " +
                                          "[Hora_Llegada_Afiliado] = NULL, [Bono_Usado] = NULL WHERE [Id] = @IdTurno");
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
            List<int> array = TurnosDeAgendaPeriodo();

            foreach (int item in array)
            {
                using (SqlConnection conexion = new SqlConnection(Access.Conexion))
                {
                    conexion.Open();
                    SqlTransaction sqlTransact = conexion.BeginTransaction();
                    SqlCommand command = conexion.CreateCommand();
                    command.Transaction = sqlTransact;

                    try
                    {
                        string query = String.Format("DELETE FROM [UN_CORTADO].[CANCELACIONES] WHERE [Id_Turno] = @Turno");
                        command.CommandText = query;

                        SqlParameter param = new SqlParameter("@Turno", item);
                        param.SqlDbType = System.Data.SqlDbType.Int;
                        command.Parameters.Add(param);

                        command.ExecuteNonQuery();

                        query = String.Format("DELETE FROM [GD2C2016].[UN_CORTADO].[TURNOS] WHERE [Id] = @IdTurno");
                        command.CommandText = query;
                        param = new SqlParameter("@IdTurno", item);
                        param.SqlDbType = System.Data.SqlDbType.Int;
                        command.Parameters.Add(param);

                        command.ExecuteNonQuery();

                        sqlTransact.Commit();

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

            CargarDiasAgenda();
            tipo_cancel_txbx.Text = "";
            detalle_txbx.Text = "";
            MessageBox.Show("La cancelación de atención medica fue exitosa", "EXITO");
        }
    }
}
