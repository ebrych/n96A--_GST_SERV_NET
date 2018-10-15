using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Beans;


namespace GestionNegocio_WebApp.Models
{
    public class PersonalModel
    {
        //conetion
        ConexionModel cnx = new ConexionModel();



        //listarPersonal
        public List<Personal> listarPersonal()
        {
            var cn = cnx.getConexion();
            List<Personal> lista = new List<Personal>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("PS_LISTAR_PERSONAL", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Personal prs = new Personal();
                Tipo tpoDoc = new Tipo();
                Tipo tpo = new Tipo();
                Estado est = new Estado();
                prs.idPersonal = dr.GetInt32(0);
                prs.nombres = dr.GetString(1);
                prs.primerApellido = dr.GetString(2);
                prs.segundoApellido = dr.GetString(3);
                tpoDoc.descripcion = dr.GetString(4);
                prs.tipoDocumento = tpoDoc;
                prs.documento = dr.GetString(5);
                prs.telefono = dr.GetString(6);
                prs.direccion = dr.GetString(7);
                prs.mail = dr.GetString(8);
                prs.fechaRegistro = dr.GetDateTime(9).ToString();
                tpo.idTipo = dr.GetInt32(11);
                tpo.descripcion = dr.GetString(10);
                prs.tipo = tpo;
                est.descripcion = dr.GetString(12);
                prs.estado = est;
                lista.Add(prs);
            }
            cn.Close();
            return lista;
        }

        //agregarPersonal
        public void agregarPersonal(Personal pers)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_REGISTRAR_PERSONAL", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nom", pers.nombres);
            cmd.Parameters.AddWithValue("@priAp", pers.primerApellido);
            cmd.Parameters.AddWithValue("@segAp", pers.segundoApellido);
            cmd.Parameters.AddWithValue("@tipoDoc", pers.tipoDocumento.idTipo );
            cmd.Parameters.AddWithValue("@doc", pers.documento);
            cmd.Parameters.AddWithValue("@telef", pers.telefono);
            cmd.Parameters.AddWithValue("@direccion", pers.direccion);
            cmd.Parameters.AddWithValue("@mail", pers.mail);
            cmd.Parameters.AddWithValue("@tipo", pers.tipo.idTipo);
            cmd.Parameters.AddWithValue("@estado", pers.estado.idEstado);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        //buscarPersona
        public Personal buscaPersonal(string id)
        {
            var cn = cnx.getConexion();
            Personal prs = new Personal();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_PERSONAL", cn);
            cmd.Parameters.AddWithValue("@idPersonal", id);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Tipo tpo = new Tipo();
                Tipo tpoDoc = new Tipo();
                Estado est = new Estado();
                prs.idPersonal = dr.GetInt32(0);
                prs.nombres = dr.GetString(1);
                prs.primerApellido = dr.GetString(2);
                prs.segundoApellido = dr.GetString(3);
                prs.documento = dr.GetString(4);
                prs.telefono = dr.GetString(5);
                prs.direccion = dr.GetString(6);
                prs.mail = dr.GetString(7);
                tpo.idTipo = dr.GetInt32(8);
                prs.tipo = tpo;
                est.idEstado = dr.GetByte(9);
                prs.estado = est;
                tpoDoc.idTipo = dr.GetInt32(10);
                prs.tipoDocumento = tpoDoc;
            }
            cn.Close();
            return prs;
        }


        //actualizaPersonal
        public void actualizaDatoPersonal(Personal prsl)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZAR_PERSONAL", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idPersonal", prsl.idPersonal);
            cmd.Parameters.AddWithValue("@nom", prsl.nombres);
            cmd.Parameters.AddWithValue("@priAp", prsl.primerApellido);
            cmd.Parameters.AddWithValue("@segAp", prsl.segundoApellido);
            cmd.Parameters.AddWithValue("@tipoDoc", prsl.tipo.idTipo);
            cmd.Parameters.AddWithValue("@doc", prsl.documento);
            cmd.Parameters.AddWithValue("@telef", prsl.telefono);
            cmd.Parameters.AddWithValue("@direccion", prsl.direccion);
            cmd.Parameters.AddWithValue("@mail", prsl.mail);
            cmd.Parameters.AddWithValue("@tipo", prsl.tipo.idTipo);
            cmd.Parameters.AddWithValue("@estado", prsl.estado.idEstado);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }


        //listaPersonalNegocio
        public List<Personal> listaPersonalNegocio(string id)
        {
            List<Personal> lista = new List<Personal>();
            var cn = cnx.getConexion();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_BUSCA_PERSONAL_NEGOCIO", cn);
            cmd.Parameters.AddWithValue("@idNegocio", id);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Personal prs = new Personal();
                Tipo tipo = new Tipo();
                prs.idPersonal = dr.GetInt32(0);
                prs.nombres = dr.GetString(1);
                prs.primerApellido = dr.GetString(2);
                prs.segundoApellido = dr.GetString(3);
                tipo.descripcion = dr.GetString(4);
                prs.tipo = tipo;
                lista.Add(prs);
            }
            cn.Close();
            return lista;
        }


        //agregarPersonalNegocio
        public void agregarPersonalNegocio(string idPersonal, string idNegocio)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_AGREGA_PERSONAL_NEGOCIO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idPersonal", idPersonal);
            cmd.Parameters.AddWithValue("@idNegocio", idNegocio);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        //eliminaPersonalNegocio
        public void eliminaPersonalNegocio(string idPersonal, string idNegocio)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_ELIMINA_PERSONAL_NEGOCIO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idPersonal", idPersonal);
            cmd.Parameters.AddWithValue("@idNegocio", idNegocio);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }



    }
}