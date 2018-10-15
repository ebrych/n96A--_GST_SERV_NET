using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Beans;

namespace GestionNegocio_WebApp.Models
{
    public class ModuloModel
    {
        //conetion
        ConexionModel cnx = new ConexionModel();


        //listarModulos
        public List<Modulo> listarModulos()
        {
            var cn = cnx.getConexion();
            List<Modulo> lista = new List<Modulo>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_MODULOS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Modulo md = new Modulo();
                md.idModulo = dr.GetInt32(0);
                md.controlador = dr.GetString(1);
                md.titulo = dr.GetString(2);
                md.descripcion = dr.GetString(3);
                lista.Add(md);
            }
            cn.Close();
            return lista;
        }

        //listarModulosRole
        public List<Modulo> listarModulosRole(string id)
        {
            var cn = cnx.getConexion();
            List<Modulo> lista = new List<Modulo>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_MODULOS_ROLE", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idRole", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Modulo md = new Modulo();
                md.idModulo = dr.GetInt32(0);
                md.controlador = dr.GetString(1);
                md.titulo = dr.GetString(2);
                md.descripcion = dr.GetString(3);
                lista.Add(md);
            }
            cn.Close();
            return lista;
        }

        


    }
}