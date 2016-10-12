using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba
{
    public class DBAccess
    {
        public string Conexion { get; set; }

        public DBAccess() 
        {
            Conexion = @"Data Source=DESKTOP-JH5F50Q\SQLSERVER2012;Initial Catalog=GD2C2016;User ID=gd;Password=gd2016";
        }
    }
}
