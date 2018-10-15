using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Beans;

namespace GestionNegocio_WebApp.Models
{
    public class UsuarioModel
    {
        //conetion
        ConexionModel cnx = new ConexionModel();


        //listarUsuarios
        public List<Usuario> litarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            var cn = cnx.getConexion();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_USUARIOS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Usuario us = new Usuario();
                Role rl = new Role();
                Estado es = new Estado();
                us.idUsuario = dr.GetInt32(0);
                us.nombres = dr.GetString(1);
                us.mail = dr.GetString(2);
                rl.idRole = dr.GetInt32(4);
                rl.descripcion = dr.GetString(3);
                us.role = rl;
                us.token = dr.GetString(5);
                es.descripcion = dr.GetString(6);
                us.estado = es;
                lista.Add(us);
            }
            cn.Close();
            return lista;
        }

        //buscarUsuario
        public Usuario buscarUsuario(string id)
        {
            Usuario user = new Usuario();
            var cn = cnx.getConexion();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_USUARIO", cn);
            cmd.Parameters.AddWithValue("@idUsuario", id);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Role rl = new Role();
                Estado es = new Estado();
                user.idUsuario = dr.GetInt32(0);
                user.nombres = dr.GetString(1);
                rl.idRole = dr.GetInt32(5);
                rl.descripcion = dr.GetString(2);
                user.role = rl;
                user.token = dr.GetString(3);
                user.mail = dr.GetString(4);
                es.idEstado = dr.GetByte(6);
                user.estado = es;
            }
            cn.Close();
            return user;
        }

        //actualizarDatoUsuario
        public void actualizarDatoUsuario(Usuario dtoUser)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZA_USUARIO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idUsuario", dtoUser.idUsuario);
            cmd.Parameters.AddWithValue("@nombres", dtoUser.nombres);
            cmd.Parameters.AddWithValue("@mail", dtoUser.mail);
            cmd.Parameters.AddWithValue("@idRol", dtoUser.role);
            cmd.Parameters.AddWithValue("@idEstado", dtoUser.estado.idEstado);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }



    }
}