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

namespace ClinicaFrba.AbmRol
{
    public partial class AbmRoles : Form
    {
        public string Usuario { get; set; }
        public DBAccess Access { get; set; }

        public AbmRoles()
        {
            InitializeComponent();
            Access = new DBAccess();
            Usuario = "admin";
            CargarRoles();
        }

        private void CargarRoles()
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT r.Id, r.Nombre, r.Estado FROM [GD2C2016].[UN_CORTADO].[ROLES] r");

                SqlCommand cmd = new SqlCommand(query, conexion);

                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    ArrayList roles = new ArrayList();
                    if (dr.HasRows)                    
                        foreach (DbDataRecord item in dr)
                            roles.Add(item);

                    roles_dgrvw.DataSource = roles;                               
                }
                catch
                {

                }
            }

            roles_dgrvw.Columns["Id"].Visible = false;
            roles_dgrvw.Columns["Estado"].Visible = false;            
        }       

        private void AbmRol_Load(object sender, EventArgs e)
        {
            roles_dgrvw.CellEnter += new DataGridViewCellEventHandler(roles_dgrvw_CellEnter_1);
        }

        private void roles_dgrvw_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            nombre_rol_txt.Text = roles_dgrvw.CurrentRow.Cells["Nombre"].Value.ToString();
            habilitado_chbx.Checked = (bool)roles_dgrvw.CurrentRow.Cells["Estado"].Value;

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT f.Nombre  FROM [GD2C2016].[UN_CORTADO].[FUNCIONES] f " +
                                            "INNER JOIN [GD2C2016].[UN_CORTADO].[FUNCIONESPORROL] fxr " +
                                            "ON f.Id = fxr.Id_Funcion " +
                                            "INNER JOIN [GD2C2016].[UN_CORTADO].[ROLES] r " +
                                            "ON fxr.Id_Rol = r.Id " +
                                            "WHERE r.Id = @RolId");

                SqlCommand cmd = new SqlCommand(query, conexion);

                SqlParameter param = new SqlParameter("@RolId", int.Parse(roles_dgrvw.CurrentRow.Cells["Id"].Value.ToString()));
                param.SqlDbType = System.Data.SqlDbType.Int;
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
            checkBox1.Checked = funcionalidades.Contains(label2.Text);
            checkBox2.Checked = funcionalidades.Contains(label3.Text);
            checkBox3.Checked = funcionalidades.Contains(label4.Text);
            checkBox4.Checked = funcionalidades.Contains(label5.Text);
            checkBox5.Checked = funcionalidades.Contains(label6.Text);
            checkBox6.Checked = funcionalidades.Contains(label7.Text);
            checkBox7.Checked = funcionalidades.Contains(label8.Text);
            checkBox8.Checked = funcionalidades.Contains(label9.Text);
            checkBox9.Checked = funcionalidades.Contains(label10.Text);
            checkBox10.Checked = funcionalidades.Contains(label11.Text);
            checkBox11.Checked = funcionalidades.Contains(label12.Text);
            checkBox12.Checked = funcionalidades.Contains(label13.Text);            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                conexion.Open();
                SqlTransaction sqlTransact = conexion.BeginTransaction();
                SqlCommand command = conexion.CreateCommand();
                command.Transaction = sqlTransact;


                try
                {
                    string query = String.Format("UPDATE [UN_CORTADO].[ROLES] SET [Nombre] = @Nombre, [Estado] = @Estado WHERE [Id] = @Id");
                    command.CommandText = query;

                    SqlParameter param = new SqlParameter("@Nombre", nombre_rol_txt.Text);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@Estado", habilitado_chbx.Checked ? 1 : 0);
                    param.SqlDbType = System.Data.SqlDbType.Bit;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@Id", int.Parse(roles_dgrvw.CurrentRow.Cells["Id"].Value.ToString()));
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    command.Parameters.Add(param);

                    command.ExecuteNonQuery();

                    query = String.Format("DELETE FROM [UN_CORTADO].[FUNCIONESPORROL] WHERE [Id_Rol] = @IdRol");
                    command.CommandText = query;

                    param = new SqlParameter("@IdRol", int.Parse(roles_dgrvw.CurrentRow.Cells["Id"].Value.ToString()));
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    command.Parameters.Add(param);

                    command.ExecuteNonQuery();


                    StringBuilder insertQuery = new StringBuilder();
                    insertQuery.Append("INSERT INTO [UN_CORTADO].[FUNCIONESPORROL] ");
                    insertQuery.Append("([Id_Funcion] ");
                    insertQuery.Append(" ,[Id_Rol])");
                    insertQuery.Append(" VALUES  ");
                    int contador = 1;
                    bool primerInsert = true;
                    foreach (Control c in groupBox2.Controls.Cast<Control>().OrderBy(c => c.TabIndex))
                    {
                        if (c is CheckBox)
                        {
                            if (((CheckBox)c).Checked == true)
                            {
                                if (primerInsert)
                                {
                                    insertQuery.Append("(" + contador + "");
                                    insertQuery.Append(", " + int.Parse(roles_dgrvw.CurrentRow.Cells["Id"].Value.ToString()) + ")");
                                    primerInsert = false;
                                }
                                else
                                {
                                    insertQuery.Append(",(" + contador + "");
                                    insertQuery.Append(", " + int.Parse(roles_dgrvw.CurrentRow.Cells["Id"].Value.ToString()) + ")");
                                }
                            }
                            contador++;
                        }
                    }

                    if (!primerInsert)
                    {
                        query = insertQuery.ToString();
                        command.CommandText = query;
                        command.ExecuteNonQuery();
                    }                    

                    if (!habilitado_chbx.Checked)
                    {
                        query = String.Format("DELETE FROM [UN_CORTADO].[ROLPORUSUARIO] WHERE [Id_Rol] = @IdRolPorUsuario");
                        command.CommandText = query;

                        param = new SqlParameter("@IdRolPorUsuario", int.Parse(roles_dgrvw.CurrentRow.Cells["Id"].Value.ToString()));
                        param.SqlDbType = System.Data.SqlDbType.Int;
                        command.Parameters.Add(param);

                        command.ExecuteNonQuery();
                    }

                    sqlTransact.Commit();

                    CargarRoles();
                    MessageBox.Show("La modificacion del rol fue exitosa", "EXITO");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un error al modificar el rol", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sqlTransact.Rollback();
                }
                finally
                {
                    if (conexion.State == System.Data.ConnectionState.Open)
                        conexion.Dispose();
                }
            }
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NuevoRol nuevoRol = new NuevoRol();

            if (nuevoRol.ShowDialog() == DialogResult.OK)
                CargarRoles();
        }
    }
}
