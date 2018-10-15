using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace GestionNegocio_WebApp.Models
{
    public class ConexionModel
    {
        public SqlConnection getConexion(){
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-MKUMQS4;Initial Catalog=DB_GESTIONNEGOCIO;User ID=sa;Password=1234");
            return cn;
        }
    }
}