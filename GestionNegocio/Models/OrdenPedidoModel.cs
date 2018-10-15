using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Beans;
namespace GestionNegocio_WebApp.Models
{
    public class OrdenPedidoModel
    {
        //conetion
        ConexionModel cnx = new ConexionModel();


        //listarOrdenPedido
        public List<OrdenPedido> listarOrdenDePedido()
        {
            var cn = cnx.getConexion();
            List<OrdenPedido> lista = new List<OrdenPedido>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTA_ORDEN_PEDIDO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                OrdenPedido ordn = new OrdenPedido();
                Negocio ng = new Negocio();
                Usuario usSol = new Usuario();
                Usuario usRes = new Usuario();
                Estado est = new Estado();
                ordn.idOrdenPedido = dr.GetInt64(0);
                ng.nombre = dr.GetString(1);
                ordn.negocio = ng;
                usSol.nombres = dr.GetString(2);
                ordn.usuarioSolicita = usSol;
                usRes.nombres = dr.GetString(3);
                ordn.usuarioRespuesta = usRes;
                ordn.totalSoles = dr.GetDecimal(4).ToString();
                est.descripcion = dr.GetString(5);
                ordn.estado = est;
                ordn.fechaRegistro = dr.GetString(6);
                ordn.fechaCambioEstado = dr.GetString(7);
                ordn.detalleRespuesta = dr.GetString(8);
                ordn.descripcion = dr.GetString(9);
                lista.Add(ordn);
            }
            cn.Close();
            return lista;
        }

        //agregarOrdenPedido
        public void agregarOrdenDePedido(string negocio,string usuario,string desc)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_AGREGA_ORDEN_PEDIDO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idNegocio", negocio);
            cmd.Parameters.AddWithValue("@idUsuario", usuario);
            cmd.Parameters.AddWithValue("@descripcion", desc);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        //buscarOrdenPedido
        public OrdenPedido buscarOrdenDePedido(string id)
        {
            var cn = cnx.getConexion();
            OrdenPedido ordn = new OrdenPedido();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_BUSCA_ORDEN_PEDIDO", cn);
            cmd.Parameters.AddWithValue("@idOrdenPedido", id);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                
                Negocio ng = new Negocio();
                Usuario usSol = new Usuario();
                Usuario usRes = new Usuario();
                Estado est = new Estado();
                ordn.idOrdenPedido = dr.GetInt64(0);
                ng.idNegocio = dr.GetInt64(1);
                ng.nombre = dr.GetString(2);
                ordn.negocio = ng;
                usSol.nombres = dr.GetString(3);
                ordn.usuarioSolicita = usSol;
                usRes.nombres = dr.GetString(4);
                ordn.usuarioRespuesta = usRes;
                ordn.totalSoles = dr.GetDecimal(5).ToString();
                est.idEstado = dr.GetInt32(6);
                est.descripcion = dr.GetString(7);
                ordn.estado = est;
                ordn.fechaRegistro = dr.GetString(8);
                ordn.fechaCambioEstado = dr.GetString(9);
                ordn.detalleRespuesta = dr.GetString(10);
                ordn.descripcion = dr.GetString(11);
            }
            cn.Close();
            return ordn;
        }


        //actualizarOrdenPedido
        public void actualizarOrdenPedido(string idPedido,string negocio, string usuario, string desc)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZA_DATO_ORDEN_PEDIDO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idOrdenPedido", idPedido);
            cmd.Parameters.AddWithValue("@idNegocio", negocio);
            cmd.Parameters.AddWithValue("@idUsuario", usuario);
            cmd.Parameters.AddWithValue("@descripcion", desc);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        //listarDetalleOrdenDePedido
        public List<DetalleOrdenPedido> listarDetalleOrdenPedido(string id)
        {
            var cn = cnx.getConexion();
            List<DetalleOrdenPedido> lista = new List<DetalleOrdenPedido>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTA_DETALLE_ORDEN_PEDIDO", cn);
            cmd.Parameters.AddWithValue("@idOrdenPedido", id);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DetalleOrdenPedido dtll = new DetalleOrdenPedido();
                Material mat = new Material();
                dtll.idDetalleOrdenPedido = dr.GetInt64(0);
                mat.descripcion = dr.GetString(1);
                dtll.material = mat;
                dtll.cantidad = dr.GetInt32(2);
                lista.Add(dtll);
            }
            cn.Close();
            return lista;
        }

        //agregarDetalleOrdenPedido
        public void agregarDetalleOrdenPedido(string idOrPed,string idMat, string cant)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_AGREGA_DETALLE_ORDEN_PEDIDO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idOrdenPedido", idOrPed);
            cmd.Parameters.AddWithValue("@idMaterial", idMat);
            cmd.Parameters.AddWithValue("@cantidad", cant);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        //eliminaDetlleOrdenPedido
        public void eliminaDetalleOrdenPedido(string idDetalleOrdenPedido)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_ELIMINA_DETALLE_ORDEN_PEDIDO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idDetalleOrdenPedido", idDetalleOrdenPedido);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }


        //listarEstados
        public List<Estado> listarEstados()
        {
            var cn = cnx.getConexion();
            List<Estado> lista = new List<Estado>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTA_ESTADO_ORDEN_PEDIDO", cn);
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

        //responderOrdenPedido
        public void responderOrdenPedido(string idOrden, string estado, string idUser,string detalle)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_RESPUESTA_ORDEN_PEDIDO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idOrdenPedido", idOrden);
            cmd.Parameters.AddWithValue("@estado", estado);
            cmd.Parameters.AddWithValue("@user", idUser);
            cmd.Parameters.AddWithValue("@detalle", detalle);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }  



    }
}