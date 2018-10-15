using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Beans;
using System.Data;
using System.Data.SqlClient;

namespace GestionNegocio_WebApp.Models
{
    public class PanelModel
    {
        //conetion
        ConexionModel cnx = new ConexionModel();



        //buscarModulos
        public List<Modulo> modulosUsuario(string token)
        {
            var cn = cnx.getConexion();
            List<Modulo> lista = new List<Modulo>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_BUSCA_MODULOS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@token", token);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Modulo md = new Modulo();
                md.titulo = dr.GetString(0);
                md.controlador = dr.GetString(1);
                md.icono = dr.GetString(2);
                lista.Add(md);
            }
            cn.Close();
            return lista;
        }


    }
}