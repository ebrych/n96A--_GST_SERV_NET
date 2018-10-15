using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Beans;

namespace GestionNegocio_WebApp.Models
{
    public class RoleModel
    {
        //conetion
        ConexionModel cnx = new ConexionModel();

        //listarRoles
        public List<Role> listarRoles()
        {
            var cn = cnx.getConexion();
            List<Role> roles = new List<Role>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTA_ROLES", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Role role = new Role();
                role.idRole = dr.GetInt32(0);
                role.descripcion = dr.GetString(1);
                roles.Add(role);
            }
            cn.Close();
            return roles;
        }


        //agregarRol
        public void agregarRole(string descripcion)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_AGREGAR_ROLES", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        //actualizaRol
        public void actualizaDatoRole(Role role)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZA_ROLE", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idRole", role.idRole);
            cmd.Parameters.AddWithValue("@descripcion", role.descripcion);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        //buscarRole
        public Role buscarRole(string id)
        {
            Role role = new Role();
            var cn = cnx.getConexion();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_ROLE", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idRole", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                role.idRole = dr.GetInt32(0);
                role.descripcion = dr.GetString(1);
            }
            cn.Close();
            return role;
        }

        //eliminaRole
        public void eliminaRole(string id)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_ELIMINA_ROLE", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idRole", id);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }


        //agregarModuloRole
        public void agregarModulorole(string modulo, string rol)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_AGREGAR_MODULO_ROLE", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idModulo", modulo);
            cmd.Parameters.AddWithValue("@idRole", rol);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        //eliminarModuloRol
        public void eliminarModuloRole(string modulo, string rol)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_ELIMINA_MODULO_ROLE", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idModulo", modulo);
            cmd.Parameters.AddWithValue("@idRole", rol);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }




    }
}