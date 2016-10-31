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

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class alta_usuario_afiliado : Form
    {
        public DBAccess Access { get; set; }
        public bool conyuge;
        public string ecivil;
        public decimal id_plan;

        public alta_usuario_afiliado(bool p1, decimal p2, string p3)
        {
            InitializeComponent();
            Access = new DBAccess();
            this.conyuge = p1;
            this.id_plan = p2;
            this.ecivil = p3;
            MessageBox.Show(conyuge.ToString());
        }

        private void verificaragregarconyuge()
        {
            if (conyuge.Equals(true))
            {
                Abm_Afiliado.alta_afiliado alta_afi = new Abm_Afiliado.alta_afiliado(usuario.Text,true,ecivil,id_plan);
                this.Hide();
                alta_afi.Show();
            }
            else
            {
                MessageBox.Show("sin conyu");
                Abm_Afiliado.alta_afiliado alta_afi = new Abm_Afiliado.alta_afiliado(usuario.Text, false, null, 0);
                this.Hide();
                alta_afi.Show();
            }
        }

        private void bot_borrar_Click(object sender, EventArgs e)
        {
            usuario.Clear();
            contra.Clear();
        }

        private void bot_siguiente_Click(object sender, EventArgs e)
        {
           if(verificacioncamposcompletos().Equals(true))
           {
               if(verificacionusuario().Equals(true))
               {   
                   cargarusuarioenbd();
                   verificaragregarconyuge();
               }
           }
        }

        private void cargarusuarioenbd()
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                conexion.Open();
                SqlTransaction sqlTransact = conexion.BeginTransaction();
                SqlCommand command = conexion.CreateCommand();
                command.Transaction = sqlTransact;
                try
                {
                    string query = String.Format("INSERT INTO [UN_CORTADO].[USUARIOS] ([Nombre_Usuario], [Contraseña]) VALUES (@Usuario, HASHBYTES('SHA2_256', @Contraseña))");
                    command.CommandText = query;

                    SqlParameter param = new SqlParameter("@Usuario", usuario.Text);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@Contraseña", contra.Text);
                    param.SqlDbType = System.Data.SqlDbType.NVarChar;
                    command.Parameters.Add(param);

                    command.ExecuteNonQuery();
                    sqlTransact.Commit();
                    MessageBox.Show("El usuario ha sido registrado exitosamente.", "Exito");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error, vuelva a intentarlo", "Error");
                    sqlTransact.Rollback();
                }
                finally
                {
                    if (conexion.State == System.Data.ConnectionState.Open)
                        conexion.Dispose();
                }
            }
        }


        private bool verificacioncamposcompletos()
        {
 	        if(usuario.Text.Equals("") || contra.Text.Equals(""))
            {
                MessageBox.Show("Completar todos los campos","Error");
                return false;
             }
             return true;
        }

        private bool verificacionusuario()
        {
            SqlConnection conexion = new SqlConnection(Access.Conexion);
            SqlCommand cmd = new SqlCommand("SELECT * FROM UN_CORTADO.USUARIOS WHERE Nombre_Usuario=@usuario", conexion);
            cmd.Parameters.AddWithValue("@usuario",usuario.Text);
            conexion.Open();
            SqlDataReader dr = cmd.ExecuteReader();
                
                if (dr.Read())
                {
                    MessageBox.Show("El usuario ingresado ya existe", "Error");
                    conexion.Close();
                    return false;     
                }
                else
                {
                    conexion.Close();
                    return true;
                }
            }


    }
    }

