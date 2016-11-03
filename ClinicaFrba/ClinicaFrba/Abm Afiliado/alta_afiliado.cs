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
    public partial class alta_afiliado : Form
    {
        public DBAccess Access { get; set; }
        private string usuario;
        public bool conyuge;
        public string estado_civil;
        private decimal id_plan;

        public alta_afiliado(string usuario, bool p2, string ecivil1, decimal idplan)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            Access = new DBAccess();
            this.usuario = usuario;
            this.conyuge = p2;
            this.estado_civil = ecivil1;
            this.id_plan = idplan;
            cargarobjetos();
        }

        private void cargarobjetos()
        {
            if (conyuge.Equals(true))
            {
                ecivil.Hide();
                label_ecivil.Hide();
                label_planmed.Hide();
                planmed.Hide();

                tipodoc.Items.Add("DNI");
                tipodoc.Items.Add("CI");
                tipodoc.Items.Add("LC");

                sexo.Items.Add("F");
                sexo.Items.Add("M");

            }
            else if (conyuge.Equals(false) && id_plan > 0)
            {
                tipodoc.Items.Add("DNI");
                tipodoc.Items.Add("CI");
                tipodoc.Items.Add("LC");

                sexo.Items.Add("F");
                sexo.Items.Add("M");

                ecivil.Items.Add("SOLTERO/A");
                ecivil.Items.Add("CASADO/A");
                ecivil.Items.Add("VIUDO/A");
                ecivil.Items.Add("CONCUBINATO");
                ecivil.Items.Add("DIVORCIADO/A");

                planmed.Hide();
                label_planmed.Hide();
            }
            else
            {
                inicializarcombobox(); 
            }
        }

        private decimal maximoNroFamilia()
        {
            SqlConnection conexion = new SqlConnection(Access.Conexion);
            conexion.Open();
            string query = "SELECT MAX(Numero_Familia) FROM UN_CORTADO.AFILIADOS WHERE Numero_Afiliado=@nroafiliado";
            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@nroafiliado", mismonrodeafiliado());
            Decimal maxNroFlia = Convert.ToDecimal(cmd.ExecuteScalar());
            return maxNroFlia + 1; 
        }


        private void inicializarcombobox()
        {
            inicializarcombofacil();
            inicializarcomboplanes();
        }

        private void inicializarcombofacil()
        {
            tipodoc.Items.Add("DNI");
            tipodoc.Items.Add("CI");
            tipodoc.Items.Add("LC");

            sexo.Items.Add("F");
            sexo.Items.Add("M");

            ecivil.Items.Add("SOLTERO/A");
            ecivil.Items.Add("CASADO/A");
            ecivil.Items.Add("VIUDO/A");
            ecivil.Items.Add("CONCUBINATO");
            ecivil.Items.Add("DIVORCIADO/A");
        }

        private void inicializarcomboplanes()
        {
            SqlConnection conexion = new SqlConnection(Access.Conexion);
            conexion.Open();
            string planmedico = " ";
            string query = "SELECT Nombre FROM UN_CORTADO.PLANES";
            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                planmed.Items.Add(dr[0]);
                planmedico = dr.GetString(0);
            }
        }

        private void bot_borrar_Click(object sender, EventArgs e) //borra campos
        {
            nombre.Clear();
            apellido.Clear();
            tipodoc.SelectedIndex = -1;
            nrodoc.Clear();
            direccion.Clear();
            telef.Clear();
            mail.Clear();
            fechanac.Value = DateTime.Today;
            sexo.SelectedIndex = -1;
            ecivil.SelectedIndex = -1;
            canthijosfamcargo.Clear();
            planmed.SelectedIndex = -1;
        }

        private void bot_guardar_Click(object sender, EventArgs e) //guarda si son correctos en la bd
        {
            if (chequeartipodatos().Equals(0))
               {
                if (chequeartodoscamposcompletos().Equals(0))
                {
                    cargarenlabdafiliados();
                    cargarenlabdcontacto();
                    MessageBox.Show("El afiliado ha sido registrado exitosamente.", "Exito");
                    verificarconyugeyfamiliares();
                }

                else if (chequeartodoscamposcompletosconyuge().Equals(0) && conyuge.Equals(true))
                {
                    cargarenlabdafiliadoconyuge();
                    cargarenlabdcontacto();
                    MessageBox.Show("El cónyuge ha sido registrado exitosamente.", "Exito");
                    this.Hide();
                    //ir al menu principal
                }
                else if (conyuge.Equals(false) && id_plan > 0)
                {
                    cargarenlabdafiliadofamiliar();
                    cargarenlabdcontacto();
                    MessageBox.Show("El hijo/familiar ha sido registrado exitosamente.", "Exito");
                    this.Hide();
                }
            }
                else
                {
                    MessageBox.Show("Verifique que todos los campos estén completados adecuadamente y los datos correctamente ingresados.", "Error al guardar");
                }

        }

        private void cargarenlabdafiliadofamiliar()
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                conexion.Open();
                SqlTransaction sqlTransact = conexion.BeginTransaction();
                SqlCommand command = conexion.CreateCommand();
                command.Transaction = sqlTransact;
                try
                {
                    string query = String.Format("INSERT INTO [UN_CORTADO].[AFILIADOS] VALUES (@usuario,@nroafi,@nroflia,@ecivil, @cant_hijos, @id_plan)");
                    command.CommandText = query;

                    SqlParameter param = new SqlParameter("@usuario", usuario);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@nroafi", mismonrodeafiliado());
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@nroflia", maximoNroFamilia());
                    param.SqlDbType = System.Data.SqlDbType.TinyInt;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@ecivil", ecivil.SelectedItem.ToString());
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@cant_hijos", Decimal.Parse(canthijosfamcargo.Text));
                    param.SqlDbType = System.Data.SqlDbType.TinyInt;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@id_plan", id_plan);
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    command.Parameters.Add(param);

                    command.ExecuteNonQuery();
                    sqlTransact.Commit();
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

        private object chequeartipodatosconyuge()
        {
            if (IsNumeric(nombre.Text).Equals(true) || IsNumeric(apellido.Text).Equals(true) ||
            IsNumeric(nrodoc.Text).Equals(false) || IsNumeric(telef.Text).Equals(false) ||
            IsNumeric(canthijosfamcargo.Text).Equals(false))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private object chequeartodoscamposcompletosconyuge()
        {
            if (nombre.Text.Equals("") || apellido.Text.Equals("") || tipodoc.SelectedIndex.Equals(-1) ||
            nrodoc.Text.Equals("") || direccion.Text.Equals("") || mail.Text.Equals("") || telef.Text.Equals("") ||
            sexo.SelectedIndex.Equals(-1) || canthijosfamcargo.Text.Equals(""))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private void cargarenlabdafiliadoconyuge()
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                conexion.Open();
                SqlTransaction sqlTransact = conexion.BeginTransaction();
                SqlCommand command = conexion.CreateCommand();
                command.Transaction = sqlTransact;
                try
                {
                    string query = String.Format("INSERT INTO [UN_CORTADO].[AFILIADOS] VALUES (@usuario,@nroafi,@nroflia,@ecivil, @cant_hijos, @id_plan)");
                    command.CommandText = query;

                    SqlParameter param = new SqlParameter("@usuario", usuario);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@nroafi", mismonrodeafiliado());
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@nroflia", maximoNroFamilia());
                    param.SqlDbType = System.Data.SqlDbType.TinyInt;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@ecivil", estado_civil);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@cant_hijos", Decimal.Parse(canthijosfamcargo.Text));
                    param.SqlDbType = System.Data.SqlDbType.TinyInt;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@id_plan", id_plan);
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    command.Parameters.Add(param);

                    command.ExecuteNonQuery();
                    sqlTransact.Commit();
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

        private Decimal mismonrodeafiliado()
        {
            SqlConnection conexion = new SqlConnection(Access.Conexion);
            conexion.Open();
            string query = "SELECT MAX(Numero_Afiliado) FROM UN_CORTADO.AFILIADOS";
            SqlCommand cmd = new SqlCommand(query, conexion);
            Decimal maxNroAfiliado = Convert.ToDecimal(cmd.ExecuteScalar());
            return maxNroAfiliado;
        }


        private void cargarenlabdcontacto()
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                conexion.Open();
                SqlTransaction sqlTransact = conexion.BeginTransaction();
                SqlCommand command = conexion.CreateCommand();
                command.Transaction = sqlTransact;
                try
                {
                    string query = String.Format("INSERT INTO [UN_CORTADO].[CONTACTO] ([Nombre_Usuario], [Nombre],[Apellido],[Tipo_Documento],[Genero],[Numero_Documento], [Direccion], [Telefono], [Mail] ,[Fecha_Nacimiento]) VALUES (@usuario,@nombre,@apellido,@tipodoc, @genero, @nrodoc, @direccion, @telefono, @mail, @fechanac)");
                    command.CommandText = query;

                    SqlParameter param = new SqlParameter("@usuario", usuario);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@nombre", nombre.Text);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@apellido", apellido.Text);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@tipodoc", tipodoc.SelectedItem.ToString());
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@genero", sexo.SelectedItem.ToString());
                    param.SqlDbType = System.Data.SqlDbType.Char;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@nrodoc",Convert.ToDecimal(nrodoc.Text));
                    param.SqlDbType = System.Data.SqlDbType.Decimal;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@direccion", direccion.Text);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@telefono", Convert.ToDecimal(telef.Text));
                    param.SqlDbType = System.Data.SqlDbType.Decimal;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@mail", mail.Text);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@fechanac", fechanac.Value.ToShortDateString());
                    param.SqlDbType = System.Data.SqlDbType.Date;
                    command.Parameters.Add(param);

                    command.ExecuteNonQuery();
                    sqlTransact.Commit();
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

        private Decimal buscaridplan()
        {
            SqlConnection conexion = new SqlConnection(Access.Conexion);
            conexion.Open();
            string query = "SELECT Id FROM UN_CORTADO.PLANES WHERE Nombre=@nombreplan";
            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@nombreplan", planmed.SelectedItem);
            Decimal idplan = Convert.ToDecimal(cmd.ExecuteScalar());
            return idplan;
        }

        private Decimal nuevonrodeafiliado()
        {
            SqlConnection conexion = new SqlConnection(Access.Conexion);
            conexion.Open();
            string query = "SELECT MAX(Numero_Afiliado) FROM UN_CORTADO.AFILIADOS";
            SqlCommand cmd = new SqlCommand(query, conexion);
            Decimal maxNroAfiliado = Convert.ToDecimal(cmd.ExecuteScalar());
            return (maxNroAfiliado + 1);
        }

        private void cargarenlabdafiliados()
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                conexion.Open();
                SqlTransaction sqlTransact = conexion.BeginTransaction();
                SqlCommand command = conexion.CreateCommand();
                command.Transaction = sqlTransact;
                try
                {
                    string query = String.Format("INSERT INTO [UN_CORTADO].[AFILIADOS] VALUES (@usuario,@nroafi,@nroflia,@ecivil, @cant_hijos, @id_plan)");
                    command.CommandText = query;

                    SqlParameter param = new SqlParameter("@usuario", usuario);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@nroafi", nuevonrodeafiliado());
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    command.Parameters.Add(param);

                    Int16 nrofamilia = 0;
                    param = new SqlParameter("@nroflia",nrofamilia);
                    param.SqlDbType = System.Data.SqlDbType.TinyInt;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@ecivil", ecivil.SelectedItem.ToString());
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@cant_hijos", Decimal.Parse(canthijosfamcargo.Text));
                    param.SqlDbType = System.Data.SqlDbType.TinyInt;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@id_plan", buscaridplan());
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    command.Parameters.Add(param);

                    command.ExecuteNonQuery();
                    sqlTransact.Commit();
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

        private void verificarconyugeyfamiliares()
        {
            decimal cantfamiacargo= Convert.ToDecimal(canthijosfamcargo.Text);
            if (ecivil.SelectedItem.Equals("CASADO/A") || ecivil.SelectedItem.Equals("CONCUBINATO"))
            {
                DialogResult opcionelegida = MessageBox.Show("¿Le gustaría asociar a su cónyuge?", "Alta de afiliado", MessageBoxButtons.YesNo);
                if (opcionelegida.Equals(DialogResult.Yes))
                {
                    Abm_Afiliado.alta_usuario_afiliado altausuafiliado = new Abm_Afiliado.alta_usuario_afiliado(true, buscaridplan(), ecivil.SelectedItem.ToString());
                    altausuafiliado.Show();
                }
                else if (opcionelegida.Equals(DialogResult.No))
                {
                    //no hace nada
                }
            }
            if (cantfamiacargo>0)
            {
                DialogResult opcionelegida = MessageBox.Show("¿Le gustaría asociar a sus hijos/familiares a su cargo?", "Alta de afiliado", MessageBoxButtons.YesNo);
                if (opcionelegida.Equals(DialogResult.Yes))
                {

                    for (int i = 0; i < cantfamiacargo; i++)
                    {
                        Abm_Afiliado.alta_usuario_afiliado altausuafiliado = new Abm_Afiliado.alta_usuario_afiliado(false, buscarplan(), null);
                        altausuafiliado.Show();
                    }
                }
                else if (opcionelegida.Equals(DialogResult.No))
                {
                    //menu principal                  
                }
            }
            this.Hide();
        }

        private decimal buscarplan()
        {
             SqlConnection conexion = new SqlConnection(Access.Conexion);
             conexion.Open();
             string query = "SELECT Id_Plan FROM UN_CORTADO.listado_afiliados WHERE Numero_Afiliado=@nroafi";
             SqlCommand cmd = new SqlCommand(query, conexion);
             cmd.Parameters.AddWithValue("@nroafi", mismonrodeafiliado());
             Decimal idplan = Convert.ToDecimal(cmd.ExecuteScalar());
             return idplan;
        }

        private void verificarfamacargo()
        {
            int hijosfamacargo= Int32.Parse(canthijosfamcargo.Text);
            if (hijosfamacargo > 0)
            {
                DialogResult opcionelegida = MessageBox.Show("¿Le gustaría asociar a los familiares a su cargo?", "Alta de afiliado", MessageBoxButtons.YesNo);
                if (opcionelegida.Equals(DialogResult.Yes))
                {
                    //do something
                }
                else if (opcionelegida.Equals(DialogResult.No))
                {
                    //do something else
                }
            }
        }

        private int chequeartodoscamposcompletos() //chequea que estén completos
        {
            if (nombre.Text.Equals("") || apellido.Text.Equals("") || tipodoc.SelectedIndex.Equals(-1) ||
                nrodoc.Text.Equals("") || direccion.Text.Equals("") || mail.Text.Equals("") || telef.Text.Equals("") ||
                sexo.SelectedIndex.Equals(-1) || ecivil.SelectedIndex.Equals(-1) || canthijosfamcargo.Text.Equals("") ||
                planmed.SelectedIndex.Equals(-1))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private int chequeartipodatos() //chequea los tipos de datos
        {
            if (IsNumeric(nombre.Text).Equals(true) || IsNumeric(apellido.Text).Equals(true) ||
                IsNumeric(nrodoc.Text).Equals(false) || IsNumeric(telef.Text).Equals(false) ||
                IsNumeric(canthijosfamcargo.Text).Equals(false))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static bool IsNumeric(string s) //verifica si todos los caracteres son numericos
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c) && c != '.')
                {
                    return false;
                }
            }

            return true;
        }

    }
}
