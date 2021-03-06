﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Listados
{
    public partial class profesionales_mas_consultados : Form
    {
        public DBAccess Access { get; set; }
        private string anio;
        private string semestre;

        public profesionales_mas_consultados(string anio, string semestre)
        {
            InitializeComponent();
            Access = new DBAccess();
            this.anio = anio;
            this.semestre = semestre;
            cargarplanes();
        }

        private void cargarplanes()
        {
            SqlConnection conexion = new SqlConnection(Access.Conexion);
            conexion.Open();
            string query = "SELECT Id FROM UN_CORTADO.PLANES";
            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                combo_plan.Items.Add(dr[0]);;
            }
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            if(combo_plan.SelectedIndex.Equals(-1))
            {
                MessageBox.Show("Seleccionar plan y especialidad.", "Error");
            }
            else
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(Access.Conexion))
                {
                    Int16 sem = Convert.ToInt16(semestre.ToString());
                    Int16 año = Convert.ToInt16(anio.ToString());                    
                    Decimal plan = Convert.ToDecimal(combo_plan.SelectedItem.ToString());
                    using (SqlCommand cmd = new SqlCommand("[UN_CORTADO].[TOP5_PROFESIONAL_PLAN]", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@semestre", SqlDbType.Int).Value = sem;
                        cmd.Parameters.Add("@year", SqlDbType.Int).Value = año;
                        cmd.Parameters.Add("@planes", SqlDbType.Int).Value = plan;
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

                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }
        
    }
    }

