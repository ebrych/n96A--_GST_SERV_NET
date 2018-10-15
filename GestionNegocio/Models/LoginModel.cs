using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Beans;
namespace GestionNegocio_WebApp.Models
{
    public class LoginModel
    {
        //conetion
        ConexionModel cnx = new ConexionModel();
        

        //InicioSesion
        public Usuario InicioSesion(string token)
        {
            var cn = cnx.getConexion(); 
            Usuario us = new Usuario();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_VALIDAR_USUARIO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@token", token);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Role rl = new Role();
                us.idUsuario = dr.GetInt32(0);
                us.nombres = dr.GetString(1);
                us.mail = dr.GetString(2);
                us.token = dr.GetString(3);
                rl.idRole = dr.GetInt32(5);
                rl.descripcion = dr.GetString(4);
                us.role = rl;
            }
            cn.Close();
            return us;
        }

        //cargaConfiguracion
        public Configuracion cargaConfiguracion()
        {
            var cn = cnx.getConexion();
            Configuracion conf = new Configuracion();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_CONFIGURACION", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                conf.nombre = dr.GetString(0);
                conf.nombreNegocio = dr.GetString(1);
                conf.color = dr.GetString(2);
                conf.colorText = dr.GetString(3);
            }
            cn.Close();
            return conf;
        }


        //registraUsuario
        public void registrarUsuario(Usuario user)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_REGISTRA_USUARIO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", user.nombres);
            cmd.Parameters.AddWithValue("@mail", user.mail);
            cmd.Parameters.AddWithValue("@token", user.token);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
       


    }
}