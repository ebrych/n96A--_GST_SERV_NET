using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Beans;
using System.Data;
using System.Data.SqlClient;

namespace GestionNegocio_WebApp.Models
{
    public class ProveedorModel
    {
        //conetion
        ConexionModel cnx = new ConexionModel();

        //listarProveedores
        public List<Proveedor> listarProveedores()
        {
            var cn = cnx.getConexion();
            List<Proveedor> lista = new List<Proveedor>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_PROVEEDORES", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Proveedor pr = new Proveedor();
                Tipo tpoDoc = new Tipo();
                Estado est = new Estado();
                pr.idProveedor = dr.GetInt64(0);
                pr.nombres = dr.GetString(1);
                pr.primerApellido = dr.GetString(2);
                pr.segundoApellido = dr.GetString(3);
                tpoDoc.descripcion= dr.GetString(4);
                pr.tipoDocumento = tpoDoc;
                pr.numeroDocumento = dr.GetString(5);
                pr.telefono = dr.GetString(6);
                pr.celular = dr.GetString(7);
                pr.direccion = dr.GetString(8);
                pr.mail = dr.GetString(9);
                pr.fechaRegistro = dr.GetString(10);
                pr.fechaModificacion = dr.GetString(11);
                est.descripcion = dr.GetString(12);
                pr.estado = est;
                lista.Add(pr);
            }
            cn.Close();
            return lista;
        }

        //agregarProveedor
        public void agregarProveedor(Proveedor prv)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_AGREGAR_PROVEEDORES", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombres", prv.nombres);
            cmd.Parameters.AddWithValue("@PrimerApellido", prv.primerApellido);
            cmd.Parameters.AddWithValue("@SegundoApellido", prv.segundoApellido);
            cmd.Parameters.AddWithValue("@idTipoDocumento", prv.tipoDocumento.idTipo);
            cmd.Parameters.AddWithValue("@numeroDocumento", prv.numeroDocumento);
            cmd.Parameters.AddWithValue("@Telefono", prv.telefono);
            cmd.Parameters.AddWithValue("@Celular", prv.celular);
            cmd.Parameters.AddWithValue("@Direccion", prv.direccion);  
            cmd.Parameters.AddWithValue("@Mail", prv.mail);
            cmd.Parameters.AddWithValue("@estado", prv.estado.idEstado);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            return;
        }

        //buscarProveedor
        public Proveedor buscarProveedor(string id)
        {
            var cn = cnx.getConexion();
            Proveedor pr = new Proveedor();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_PROVEEDOR", cn);
            cmd.Parameters.AddWithValue("@idProveedor", id);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Tipo tipoDoc = new Tipo();
                Estado est = new Estado();
                pr.idProveedor = dr.GetInt64(0);
                pr.nombres = dr.GetString(1);
                pr.primerApellido = dr.GetString(2);
                pr.segundoApellido = dr.GetString(3);
                tipoDoc.idTipo = dr.GetInt32(4);
                pr.tipoDocumento = tipoDoc;
                pr.numeroDocumento = dr.GetString(5);
                pr.telefono = dr.GetString(6);
                pr.celular = dr.GetString(7);
                pr.direccion = dr.GetString(8);
                pr.mail = dr.GetString(9);
                pr.fechaRegistro = dr.GetString(10);
                pr.fechaModificacion = dr.GetString(11);
                est.idEstado = dr.GetByte(12);
                pr.estado = est;
            }
            cn.Close();
            return pr;
        }

        //actualizarProveedor
        public void actualizaProveedor(Proveedor prv)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZA_PROVEEDOR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idProveedor", prv.idProveedor);
            cmd.Parameters.AddWithValue("@Nombres", prv.nombres);
            cmd.Parameters.AddWithValue("@PrimerApellido", prv.primerApellido);
            cmd.Parameters.AddWithValue("@SegundoApellido", prv.segundoApellido);
            cmd.Parameters.AddWithValue("@idTipoDocumento", prv.tipoDocumento.idTipo);
            cmd.Parameters.AddWithValue("@numeroDocumento", prv.numeroDocumento);
            cmd.Parameters.AddWithValue("@Telefono", prv.telefono);
            cmd.Parameters.AddWithValue("@Celular", prv.celular);
            cmd.Parameters.AddWithValue("@Direccion", prv.direccion);
            cmd.Parameters.AddWithValue("@Mail", prv.mail);
            cmd.Parameters.AddWithValue("@estado", prv.estado.idEstado);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            return;
        }


    }
}