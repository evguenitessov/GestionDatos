using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Linq.Expressions;
using System.Data.SqlClient;
using System.Collections;

namespace ClinicaFrba.Registrar_Agenta_Medico
{
    public partial class registrar_agenda : Form
    {
        public string Usuario { get; set; }
        public DBAccess Access { get; set; }

        public registrar_agenda(string usr)
        {
            InitializeComponent();
            desde.CustomFormat = "HH";
            hasta.CustomFormat = "HH";
            desde_sab.CustomFormat = "HH";
            hasta_sab.CustomFormat = "HH";
            Access = new DBAccess();
            Usuario = usr;

            CargarEspecialidades();
        }

        private void CargarEspecialidades()
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT EP.Id, E.Nombre FROM [UN_CORTADO].[ESPECIALIDADES] E, [UN_CORTADO].[ESPECIALIDADPORPROFESIONAL] EP " +
                                             "WHERE E.Id = EP.Id_Especialidad AND EP.Id_Medico = @UserName");

                SqlCommand cmd = new SqlCommand(query, conexion);

                SqlParameter param = new SqlParameter("@UserName", Usuario);
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

                    roles_cbx.DataSource = new BindingSource(comboSource, null);
                    roles_cbx.DisplayMember = "Value";
                    roles_cbx.ValueMember = "Key";

                    roles_cbx.SelectedIndex = 0;
                }
                catch
                {

                }
            }
        }

        private void aceptar_dias_Click(object sender, EventArgs e)
        {            
            if ((checkedlist_dias.CheckedItems.Count == 0) && (checkedlist_dia_sab.CheckedItems.Count == 0))
            {
                MessageBox.Show("Seleccione al menos un dia", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!(checkedlist_dias.CheckedItems.Count == 0))
                box_rango.Enabled = true;

            if (checkedlist_dia_sab.GetItemCheckState(0) == CheckState.Checked)
                box_rango_sab.Enabled = true;

            box_dias.Enabled = false;

            rango_dias_habiles();
            rango_sabados();

            box_rango.Show();
            box_rango_sab.Show();
            aceptar_rango.Show();

            aceptar_rango.Enabled = true;
        }

        private void rango_sabados()
        {
            desde_sab.MaxDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 15, 0, 0);
            desde_sab.MinDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 0, 0);
            hasta_sab.MaxDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 15, 0, 0);
            hasta_sab.MinDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 0, 0);
        }

        private void rango_dias_habiles()
        {
            desde.MaxDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 20, 0, 0);
            desde.MinDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0);
            hasta.MaxDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 20, 0, 0);
            hasta.MinDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0);
        }

        private void aceptar_rango_Click(object sender, EventArgs e)
        {
            if ((box_rango.Enabled) && (!(desde.Value.Hour < hasta.Value.Hour)))
            {
                MessageBox.Show("El horario hasta debe ser mayor al horario desde de lun a vie.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((box_rango_sab.Enabled) && (!(desde_sab.Value.Hour < hasta_sab.Value.Hour)))
            {
                MessageBox.Show("El horario hasta debe ser mayor al horario desde del sabado.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            box_rango.Enabled = box_rango_sab.Enabled = aceptar_rango.Enabled = false;
            box_fechas.Show();
            box_fechas.Enabled = true;
        }        

        private void confirmar_Click(object sender, EventArgs e)
        {
            if (ChequearAgendaExistente() == 1)
            {
                if (ChequearCantidadHoras() == 1)
                    CargarAgenda();
                else
                    MessageBox.Show("Se han superado las 48 horas semanales.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                CargarAgenda();

            confirmar.Enabled = false;
            agregar.Enabled = true;
                            
        }

        private int ChequearAgendaExistente()
        {
            int dr = 0;
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT [UN_CORTADO].[CONTROL_AGENDA_EXISTENTE] (@Id_Especialidad_Medico, @Fecha_Desde)");

                SqlCommand cmd = new SqlCommand(query, conexion);

                SqlParameter param = new SqlParameter("@Id_Especialidad_Medico", ((KeyValuePair<int, string>)roles_cbx.SelectedItem).Key);
                param.SqlDbType = System.Data.SqlDbType.Int;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Fecha_Desde", Convert.ToDateTime(desde_fecha.Text));
                param.SqlDbType = System.Data.SqlDbType.Date;
                cmd.Parameters.Add(param);                

                try
                {
                    conexion.Open();
                    dr = (Int32)cmd.ExecuteScalar();

                }
                catch (Exception ex)
                {

                }
            }
            return dr;
        }

        private int ChequearCantidadHoras()
        {
            int dr = 0;
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT [UN_CORTADO].[CONTROL_HORAS] (@Id_Especialidad_Medico, @Fecha_Desde, @Fecha_Hasta, @CantHoras)");

                SqlCommand cmd = new SqlCommand(query, conexion);

                SqlParameter param = new SqlParameter("@Id_Especialidad_Medico", ((KeyValuePair<int, string>)roles_cbx.SelectedItem).Key);
                param.SqlDbType = System.Data.SqlDbType.Int;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Fecha_Desde", Convert.ToDateTime(desde_fecha.Text));
                param.SqlDbType = System.Data.SqlDbType.Date;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Fecha_Hasta", Convert.ToDateTime(hasta_fecha.Text));
                param.SqlDbType = System.Data.SqlDbType.Date;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@CantHoras", hasta.Value.Hour - desde.Value.Hour);
                param.SqlDbType = System.Data.SqlDbType.Int;
                cmd.Parameters.Add(param);

                try
                {
                    conexion.Open();
                    dr = (Int32)cmd.ExecuteScalar();

                }
                catch (Exception ex)
                {

                }
            }
            return dr;
        }

        private void CargarAgenda()
        {
            foreach (var dia in checkedlist_dias.CheckedIndices)
            {
                using (SqlConnection conexion = new SqlConnection(Access.Conexion))
                {
                    SqlCommand cmd = new SqlCommand("[UN_CORTADO].[CARGAR_AGENDA]", conexion);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter param = new SqlParameter("@Dia_Atencion", (int)dia + 1);
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    param.Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Id_Especialidad_Medico", ((KeyValuePair<int, string>)roles_cbx.SelectedItem).Key);
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    param.Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fecha_Desde", Convert.ToDateTime(desde_fecha.Text));
                    param.SqlDbType = System.Data.SqlDbType.Date;
                    param.Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fecha_Hasta", Convert.ToDateTime(hasta_fecha.Text));
                    param.SqlDbType = System.Data.SqlDbType.Date;
                    param.Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Hora_Inicio", new TimeSpan(desde.Value.Hour, 0, 0));
                    param.SqlDbType = System.Data.SqlDbType.Time;
                    param.Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Hora_Fin", new TimeSpan(hasta.Value.Hour, 0, 0));
                    param.SqlDbType = System.Data.SqlDbType.Time;
                    param.Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    try
                    {
                        conexion.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

            if (checkedlist_dia_sab.GetItemCheckState(0) == CheckState.Checked)
            {
                using (SqlConnection conexion = new SqlConnection(Access.Conexion))
                {
                    SqlCommand cmd = new SqlCommand("[UN_CORTADO].[CARGAR_AGENDA]", conexion);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter param = new SqlParameter("@Dia_Atencion", 6);
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    param.Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Id_Especialidad_Medico", ((KeyValuePair<int, string>)roles_cbx.SelectedItem).Key);
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    param.Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fecha_Desde", Convert.ToDateTime(desde_fecha.Text));
                    param.SqlDbType = System.Data.SqlDbType.Date;
                    param.Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fecha_Hasta", Convert.ToDateTime(hasta_fecha.Text));
                    param.SqlDbType = System.Data.SqlDbType.Date;
                    param.Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Hora_Inicio", new TimeSpan(desde_sab.Value.Hour, 0, 0));
                    param.SqlDbType = System.Data.SqlDbType.Time;
                    param.Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Hora_Fin", new TimeSpan(hasta_sab.Value.Hour, 0, 0));
                    param.SqlDbType = System.Data.SqlDbType.Time;
                    param.Direction = System.Data.ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    try
                    {
                        conexion.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

            MessageBox.Show("Se agrego la agenda", "EXITO");
        }

        private void aceptar_fechas_Click(object sender, EventArgs e)
        {
            box_dias.Show();
        }

        private void hasta_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void aceptar_fechas_Click_1(object sender, EventArgs e)
        {
            if (desde_fecha.Value.Date > hasta_fecha.Value.Date)
            {
                MessageBox.Show("La fecha hasta debe ser mayor a la fecha desde.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;                
            }

            box_fechas.Enabled = false;
            confirmar.Enabled = true;
        }

        private void agregar_Click(object sender, EventArgs e)
        {
            agregar.Enabled = false;
            box_dias.Enabled = true;
            box_rango_sab.Hide();
            box_rango.Hide();
            aceptar_rango.Hide();
            box_fechas.Hide();

            foreach (int i in checkedlist_dias.CheckedIndices)
            {
                checkedlist_dias.SetItemCheckState(i, CheckState.Unchecked);
                checkedlist_dias.SetSelected(i, false);
            }

            foreach (int i in checkedlist_dia_sab.CheckedIndices)
            {
                checkedlist_dias.SetItemCheckState(i, CheckState.Unchecked);
                checkedlist_dias.SetSelected(i, false);
            }                    
        }
    }
}
