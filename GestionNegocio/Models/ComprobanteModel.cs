using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Beans;
using System.Data;
using System.Data.SqlClient;

namespace GestionNegocio_WebApp.Models
{
    public class ComprobanteModel
    {
        //conetion
        ConexionModel cnx = new ConexionModel();


        //listarComprobantes
        public List<Comprobante> listaComprobantes()
        {
            var cn = cnx.getConexion();
            List<Comprobante> lista = new List<Comprobante>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_COMPROBANTE", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Comprobante comp = new Comprobante();
                Negocio neg = new Negocio();
                Cliente cli = new Cliente();
                Tipo tipo = new Tipo();
                Estado est = new Estado();

                comp.idComprobante = dr.GetInt64(0);
                comp.serie = dr.GetString(1);
                comp.numeroComprobante = dr.GetString(2);
                neg.nombre = dr.GetString(3);
                comp.negocio = neg;
                cli.nombres = dr.GetString(4);
                cli.primerApellido = dr.GetString(5);
                cli.segundoApellido = dr.GetString(6);
                comp.cliente = cli;
                tipo.descripcion = dr.GetString(7);
                comp.tipo = tipo;
                comp.fechaImprecion = dr.GetString(8);
                comp.fechaPago = dr.GetString(9);
                comp.descripcion = dr.GetString(10);
                est.descripcion = dr.GetString(11);
                comp.estado = est;
                comp.subtotal = dr.GetDecimal(12);
                comp.igv = dr.GetDecimal(13);
                comp.total = dr.GetDecimal(14);
                lista.Add(comp);

            }
            cn.Close();
            return lista;
        }

        public void agregarComprobante(Comprobante comp)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_AGEGAR_COMPROBANTE", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@serie", comp.serie);
            cmd.Parameters.AddWithValue("@numero", comp.numeroComprobante);
            cmd.Parameters.AddWithValue("@idNegocio", comp.negocio.idNegocio);
            cmd.Parameters.AddWithValue("@idCliente", comp.cliente.idCliente);
            cmd.Parameters.AddWithValue("@idTipo", comp.tipo.idTipo);
            cmd.Parameters.AddWithValue("@fechaImpresion", comp.fechaImprecion);
            cmd.Parameters.AddWithValue("@fechaPago", comp.fechaPago);
            cmd.Parameters.AddWithValue("@descripcion", comp.descripcion);
            cmd.Parameters.AddWithValue("@idEstado", comp.estado.idEstado);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        //buscarComprobante
        public Comprobante buscarComprobante(string id)
        {
            var cn = cnx.getConexion();
            Comprobante comp = new Comprobante();

            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_BUSCA_COMPROBANTE", cn);
            cmd.Parameters.AddWithValue("@idComprobante", id);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ;
                Negocio neg = new Negocio();
                Cliente cli = new Cliente();
                Tipo tipo = new Tipo();
                Estado est = new Estado();

                comp.idComprobante = dr.GetInt64(0);
                comp.serie = dr.GetString(1);
                comp.numeroComprobante = dr.GetString(2);
                neg.idNegocio = dr.GetInt64(3);
                neg.nombre = dr.GetString(4);
                comp.negocio = neg;
                cli.idCliente = dr.GetInt64(5);
                cli.nombres = dr.GetString(6);
                cli.primerApellido = dr.GetString(7);
                cli.segundoApellido = dr.GetString(8);
                comp.cliente = cli;
                tipo.idTipo = dr.GetInt32(9);
                tipo.descripcion = dr.GetString(10);
                comp.tipo = tipo;
                comp.fechaImprecion = dr.GetString(11);
                comp.fechaPago = dr.GetString(12);
                comp.descripcion = dr.GetString(13);
                est.idEstado = dr.GetInt32(14);
                est.descripcion = dr.GetString(15);
                comp.estado = est;
                comp.subtotal = dr.GetDecimal(16);
                comp.igv = dr.GetDecimal(17);
                comp.total = dr.GetDecimal(18);
            }
            cn.Close();
            return comp;
        }

        //actualizaComprobante
        public void actualizaComprobante(string id, string serie, string num, string negocio, string cli, string tipo, string fechPago, string desc, string est)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZA_COMPROBANTE", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idComprobante", id);
            cmd.Parameters.AddWithValue("@Serie", serie);
            cmd.Parameters.AddWithValue("@numero", num);
            cmd.Parameters.AddWithValue("@idNegocio", negocio);
            cmd.Parameters.AddWithValue("@idCliente", cli);
            cmd.Parameters.AddWithValue("@idTipo", tipo);
            cmd.Parameters.AddWithValue("@fechaImpresion", fechPago);
            cmd.Parameters.AddWithValue("@fechaPago", fechPago);
            cmd.Parameters.AddWithValue("@descripcion", desc);
            cmd.Parameters.AddWithValue("@idEstado", est);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }


        //estadoComprobante
        public List<Estado> listarEstados()
        {
            List<Estado> lista = new List<Estado>();
            var cn = cnx.getConexion();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTA_ESTADO_COMPROBANTE", cn);
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



        //listarConceptos
        public List<Concepto> listarConceptos()
        {
            List<Concepto> lista = new List<Concepto>();
            var cn = cnx.getConexion();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_CONCEPTOS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Concepto est = new Concepto();
                est.idConcepto = dr.GetInt32(0);
                est.concepto = dr.GetString(1);
                lista.Add(est);
            }
            cn.Close();
            return lista;
        }

        //listarConceptosTotal
        public List<Concepto> listarTotalConceptos()
        {
            List<Concepto> lista = new List<Concepto>();
            var cn = cnx.getConexion();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTA_TOTAL_CONCEPTOS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Concepto est = new Concepto();
                Estado es = new Estado();
                est.idConcepto = dr.GetInt32(0);
                est.concepto = dr.GetString(1);
                es.idEstado = dr.GetByte(2);
                es.descripcion = dr.GetString(3);
                est.estado = es;
                lista.Add(est);
            }
            cn.Close();
            return lista;
        }


        //listarDetalleComprobante
        public List<DetalleComprobante> listarDetalleComprobante(string id)
        {
            List<DetalleComprobante> lista = new List<DetalleComprobante>();
            var cn = cnx.getConexion();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTA_DETALLE_COMPROBANTE", cn);
            cmd.Parameters.AddWithValue("@idComprobante", id);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DetalleComprobante dtll = new DetalleComprobante();
                Concepto cncp = new Concepto();
                dtll.idDetalleComprobante = dr.GetInt64(0);
                cncp.concepto = dr.GetString(1);
                dtll.concepto = cncp;
                dtll.cantidad = dr.GetInt32(2);
                dtll.monto = dr.GetDecimal(3);
                dtll.fechaRegistro = dr.GetString(4);
                lista.Add(dtll);
            }
            cn.Close();
            return lista;
        }

        //agregarDetalleComprobante
        public void agregarDetalleComprobante(string comp, string cant, string monto, string concep)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_AGREGAR_DETALLE_COMPROBANTE", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idComprobante", comp);
            cmd.Parameters.AddWithValue("@idConcepto", concep);
            cmd.Parameters.AddWithValue("@cantidad", cant);
            cmd.Parameters.AddWithValue("@monto", monto);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        //eliminaDetalleComrpobante
        public void eliminaDetalleComrpobante(string idDetalleComprobante)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_ELIMINA_DETALLE_COMPROBANTE  ", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idDetalleComprobante", idDetalleComprobante);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }


        //agregaConcepto
        public void agregaConcepto(string descripcion, string estado)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_AGREGAR_CONCEPTO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@estado", estado);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        //buscarConcepto
        public Concepto buscarConcepto (string id)
        {
            Concepto concep = new Concepto();
            var cn = cnx.getConexion();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_CONCEPTO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idConcepto", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Estado es = new Estado();
                concep.idConcepto = dr.GetInt32(0);
                concep.concepto = dr.GetString(1);
                es.idEstado = dr.GetByte(2);
                es.descripcion = dr.GetString(3);
                concep.estado = es;
            }
            cn.Close();
            return concep;
        }

        //actualizarConcepto
        public void actualizarConcepto(string id,string descripcion, string estado)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZA_CONCEPTO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idConcepto", id);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@estado", estado);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }




    }
}