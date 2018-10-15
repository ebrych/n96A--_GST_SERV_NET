using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Beans;
using System.Data;
using System.Data.SqlClient;


namespace GestionNegocio_WebApp.Models
{
    public class CompraModel
    {
        //conetion
        ConexionModel cnx = new ConexionModel();


        public List<Compra> listarCompras()
        {
            var cn = cnx.getConexion();
            List<Compra> lista = new List<Compra>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_COMPRAS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Compra comp = new Compra();
                Proveedor prv = new Proveedor();
                Negocio ng = new Negocio();
                Usuario us = new Usuario();
                Estado est = new Estado();
                comp.idCompra = dr.GetInt64(0);
                prv.nombres = dr.GetString(1);
                prv.primerApellido = dr.GetString(2);
                prv.segundoApellido = dr.GetString(3);
                comp.proveedor = prv;
                comp.fecha = dr.GetString(4);
                us.nombres = dr.GetString(5);
                comp.usuario = us;
                comp.montoTotal = dr.GetDecimal(6);
                est.descripcion = dr.GetString(7);
                comp.estado = est;
                comp.descripcion = dr.GetString(8);
                lista.Add(comp);
            }
            cn.Close();
            return lista;
        }

        public List<Estado> listaEstadoCompra()
        {
            var cn = cnx.getConexion();
            List<Estado> lista = new List<Estado>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_ESTADO_COMPRA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Estado est = new Estado();
                est.idEstado = dr.GetInt32(0);
                est.descripcion = dr.GetString(1);
                lista.Add(est);
            }
            cn.Close();
            return lista;
        }


        public void agregarCompra(string idProveedor,string idUsuario,string desc)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_AGREGAR_COMPRA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idProveedor", idProveedor);
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
            cmd.Parameters.AddWithValue("@descripcion", desc);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public Compra buscarCompra(string idCompra)
        {
            var cn = cnx.getConexion();
            Compra comp = new Compra();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_BUSCA_COMPRA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idCompra", idCompra);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Proveedor prv = new Proveedor();
                Negocio ng = new Negocio();
                Usuario us = new Usuario();
                Estado est = new Estado();
                comp.idCompra = dr.GetInt64(0);
                prv.idProveedor = dr.GetInt64(1);
                prv.nombres = dr.GetString(2);
                prv.primerApellido = dr.GetString(3);
                prv.segundoApellido = dr.GetString(4);
                comp.proveedor = prv;
                comp.fecha = dr.GetString(5);
                us.idUsuario = dr.GetInt32(6);
                us.nombres = dr.GetString(7);
                comp.usuario = us;
                comp.montoTotal = dr.GetDecimal(8);
                est.idEstado = dr.GetInt32(9);
                est.descripcion = dr.GetString(10);
                comp.estado = est;
                comp.descripcion = dr.GetString(11);
                
            }
            cn.Close();
            return comp;
        }

        public void actualizaDatoCompra(string idCompra,string idProveedor, string idUsuario,string desc)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZA_COMPRA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idCompra", idCompra);
            cmd.Parameters.AddWithValue("@idProveedor", idProveedor);
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
            cmd.Parameters.AddWithValue("@descripcion", desc);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public List<DetalleCompra> listarDetalleCompra(string idCompra)
        {
            var cn = cnx.getConexion();
            List<DetalleCompra> lista = new List<DetalleCompra>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_DETALLE_COMPRA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idCompra", idCompra);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DetalleCompra dtll = new DetalleCompra();
                Material mt = new Material();
                dtll.idCompraDetalle = dr.GetInt64(0);
                mt.descripcion = dr.GetString(1);
                dtll.material = mt;
                dtll.cantidad = dr.GetInt32(2);
                dtll.precio = dr.GetDecimal(3);
                lista.Add(dtll);
            }
            cn.Close();
            return lista;
        }

        public void agregarDetalleCompra(string idCompra,string idMaterial,string cantidad,string precio)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_AGREGA_DETALLE_COMPRA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idCompra", idCompra);
            cmd.Parameters.AddWithValue("@idMaterial", idMaterial);
            cmd.Parameters.AddWithValue("@cantidad", cantidad);
            cmd.Parameters.AddWithValue("@precio", precio);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void eliminaDetalleCompra(string idDetalleCompra)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_ELIMINA_DETALLE_COMPRA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idDetalleCompra", idDetalleCompra);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }


        public void respondeCompra(string idCompra,string idEstado)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_RESPONDE_COMPRA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idCompra", idCompra);
            cmd.Parameters.AddWithValue("@idEstado", idEstado);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }


        public List<Compra> listarComprasSelect()
        {
            var cn = cnx.getConexion();
            List<Compra> lista = new List<Compra>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTA_COMPRAS_SELECT", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Compra comp = new Compra();
                comp.idCompra = dr.GetInt64(0);
                comp.descripcion = dr.GetString(1);
                lista.Add(comp);
            }
            cn.Close();
            return lista;
        }


    }
}