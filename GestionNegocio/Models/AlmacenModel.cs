using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Beans;
using System.Data;
using System.Data.SqlClient;

namespace GestionNegocio_WebApp.Models
{
    public class AlmacenModel
    {
        //conetion
        ConexionModel cnx = new ConexionModel();



        //listarAlmacenes
        public List<Almacen> listarAlamacenes()
        {
            var cn = cnx.getConexion();
            List<Almacen> lista = new List<Almacen>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_ALMACEN", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Almacen alm = new Almacen();
                Estado est = new Estado();
                alm.idAlmacen = dr.GetInt32(0);
                alm.nombre = dr.GetString(1);
                alm.direccion = dr.GetString(2);
                alm.telefono = dr.GetString(3);
                alm.fechaRegistro = dr.GetString(4); 
                alm.fechaModificacion = dr.GetString(5);
                est.descripcion = dr.GetString(6);
                alm.estado = est;
                lista.Add(alm);
            }
            cn.Close();
            return lista;
        }

        //agregarAlmacen
        public void agregarAlmacen(Almacen alm)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_ALMACEN", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", alm.nombre);
            cmd.Parameters.AddWithValue("@Direccion", alm.direccion);
            cmd.Parameters.AddWithValue("@Telefono", alm.telefono);
            cmd.Parameters.AddWithValue("@estado", alm.estado.idEstado);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        //buscaAlmacen
        public Almacen buscaAlmacen(string id)
        {
            var cn = cnx.getConexion();
            Almacen alm = new Almacen();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_ALMACEN", cn);
            cmd.Parameters.AddWithValue("@idAlmacen", id);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Estado est = new Estado();
                alm.idAlmacen = dr.GetInt32(0);
                alm.nombre = dr.GetString(1);
                alm.direccion = dr.GetString(2);
                alm.telefono = dr.GetString(3);
                alm.fechaRegistro = dr.GetString(4);
                alm.fechaModificacion = dr.GetString(5);
                est.idEstado = dr.GetByte(6);
                alm.estado = est;
               
            }
            cn.Close();
            return alm;
        }

        //actualizaAlmacen
        public void actualizaAlmacen(Almacen alm)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZAR_ALMACEN", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idAlmacen", alm.idAlmacen);
            cmd.Parameters.AddWithValue("@Nombre", alm.nombre);
            cmd.Parameters.AddWithValue("@Direccion", alm.direccion);
            cmd.Parameters.AddWithValue("@Telefono", alm.telefono);
            cmd.Parameters.AddWithValue("@estado", alm.estado.idEstado);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

    }
}