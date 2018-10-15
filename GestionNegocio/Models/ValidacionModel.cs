using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace GestionNegocio_WebApp.Models
{
    public class ValidacionModel
    {
        //conetion
        ConexionModel cnx = new ConexionModel();
        

        //validarPermisos
        public int validarPermisos(string token, string ruta)
        {
            int result = 0;
            var cn = cnx.getConexion();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_VALIDA_PERMISOS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@token", token);
            cmd.Parameters.AddWithValue("@ruta", ruta);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                result = dr.GetInt32(0);
            }
            cn.Close();
            return result;
        }

    }
}