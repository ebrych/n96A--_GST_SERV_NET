using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Beans;
using System.Data;
using System.Data.SqlClient;

namespace GestionNegocio_WebApp.Models
{
    public class ClienteModel
    {
        //conetion
        ConexionModel cnx = new ConexionModel();


        //listarCliente
        public List<Cliente> listarCliente()
        {
            var cn = cnx.getConexion();
            List<Cliente> lista = new List<Cliente>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_CLIENTE", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cliente cl = new Cliente();
                Tipo tpoDoc = new Tipo();
                Tipo tpo = new Tipo();
                Estado est = new Estado();
                cl.idCliente = dr.GetInt64(0);
                cl.nombres = dr.GetString(1);
                cl.primerApellido = dr.GetString(2);
                cl.segundoApellido = dr.GetString(3);
                tpoDoc.descripcion = dr.GetString(4);
                cl.tipoDocumento = tpoDoc;
                cl.numeroDocumento = dr.GetString(5);
                cl.telefono = dr.GetString(6);
                cl.direccion = dr.GetString(7);
                cl.celular = dr.GetString(8);
                cl.mail = dr.GetString(9);
                tpo.descripcion= dr.GetString(10);
                cl.tipo = tpo;
                cl.fechaCreacion = dr.GetString(11);
                cl.fechaModificacion = dr.GetString(12);
                est.descripcion = dr.GetString(13);
                cl.estado = est;
                lista.Add(cl);
            }
            cn.Close();
            return lista;
        }


        //agregarCliente
        public void agregarCliente(Cliente cl)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_REGISTRA_CLIENTE", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nom", cl.nombres);
            cmd.Parameters.AddWithValue("@priAp", cl.primerApellido);
            cmd.Parameters.AddWithValue("@segAp", cl.segundoApellido);
            cmd.Parameters.AddWithValue("@tpodoc", cl.tipoDocumento.idTipo);
            cmd.Parameters.AddWithValue("@nrodoc", cl.numeroDocumento);
            cmd.Parameters.AddWithValue("@telef", cl.telefono);
            cmd.Parameters.AddWithValue("@direccion", cl.direccion);
            cmd.Parameters.AddWithValue("@celular", cl.celular);
            cmd.Parameters.AddWithValue("@mail", cl.mail);
            cmd.Parameters.AddWithValue("@tipo", cl.tipo.idTipo);
            cmd.Parameters.AddWithValue("@estado", cl.estado.idEstado);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        //buscarCliente
        public Cliente buscaCliente(string id)
        {
            var cn = cnx.getConexion();
            Cliente cl = new Cliente();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_BUSCA_CLIENTE", cn);
            cmd.Parameters.AddWithValue("@idCliente", id);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Tipo tpoDoc = new Tipo();
                Tipo tpo = new Tipo();
                Estado est = new Estado();
                cl.idCliente = dr.GetInt64(0);
                cl.nombres = dr.GetString(1);
                cl.primerApellido = dr.GetString(2);
                cl.segundoApellido = dr.GetString(3);
                tpoDoc.idTipo = dr.GetInt32(4);
                cl.tipoDocumento = tpoDoc;
                cl.numeroDocumento = dr.GetString(5);
                cl.telefono = dr.GetString(6);
                cl.direccion = dr.GetString(7);
                cl.celular = dr.GetString(8);
                cl.mail = dr.GetString(9);
                tpo.idTipo = dr.GetInt32(10);
                cl.tipo = tpo;
                cl.fechaCreacion = dr.GetString(11);
                cl.fechaModificacion = dr.GetString(12);
                est.idEstado = dr.GetByte(13);
                cl.estado = est;
            }
            cn.Close();
            return cl;
        }

        //actualizaCliente
        public void actualizarDatoCliente(Cliente cli)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZAR_CLIENTE", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idCliente", cli.idCliente);
            cmd.Parameters.AddWithValue("@nom", cli.nombres);
            cmd.Parameters.AddWithValue("@priAp", cli.primerApellido);
            cmd.Parameters.AddWithValue("@segAp", cli.segundoApellido);
            cmd.Parameters.AddWithValue("@tpoDoc", cli.tipoDocumento.idTipo);
            cmd.Parameters.AddWithValue("@nroDoc", cli.numeroDocumento);
            cmd.Parameters.AddWithValue("@telef", cli.telefono);
            cmd.Parameters.AddWithValue("@direccion", cli.direccion);
            cmd.Parameters.AddWithValue("@celular", cli.celular);
            cmd.Parameters.AddWithValue("@mail", cli.mail);
            cmd.Parameters.AddWithValue("@tipo", cli.tipo.idTipo);
            cmd.Parameters.AddWithValue("@estado", cli.estado.idEstado);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }





    }
}