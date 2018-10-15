using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Beans;


namespace GestionNegocio_WebApp.Models
{
    public class NegocioModel
    {
        //conetion
        ConexionModel cnx = new ConexionModel();



        //listaNegocio
        public List<Negocio> listaNegocio()
        {
            List<Negocio> lista = new List<Negocio>();
            var cn = cnx.getConexion();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTA_NEGOCIO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Negocio ng = new Negocio();
                Personal pers = new Personal();
                Tipo tpo = new Tipo();
                Estado sto = new Estado();
                Cliente cli = new Cliente();

                ng.idNegocio = dr.GetInt64(0);
                ng.nombre = dr.GetString(1);
                pers.nombres = dr.GetString(2);
                pers.primerApellido = dr.GetString(3);
                pers.segundoApellido = dr.GetString(4);
                ng.responsable = pers;
                ng.descripcion = dr.GetString(5);
                tpo.descripcion = dr.GetString(6);
                ng.tipo = tpo;
                ng.fechaInicio = dr.GetString(7);
                ng.fechaFin = dr.GetString(8);
                ng.fechaRegistro = dr.GetString(9);
                sto.descripcion = dr.GetString(10);
                ng.estado = sto;
                ng.fechaModificacion = dr.GetString(11);
                cli.nombres = dr.GetString(12);
                cli.primerApellido = dr.GetString(13);
                cli.segundoApellido = dr.GetString(14);
                ng.cliente = cli;
                lista.Add(ng);
            }
            cn.Close();
            return lista;
        }


        //agregarNegocio
        public void agregarNegocio(Negocio ng)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_AGREGAR_NEGOCIO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nom", ng.nombre);
            cmd.Parameters.AddWithValue("@idResponsable", ng.responsable.idPersonal);
            cmd.Parameters.AddWithValue("@descripcion", ng.descripcion);
            cmd.Parameters.AddWithValue("@idtipo", ng.tipo.idTipo);
            cmd.Parameters.AddWithValue("@fechaInicio", ng.fechaInicio);
            cmd.Parameters.AddWithValue("@fechaFin", ng.fechaFin);
            cmd.Parameters.AddWithValue("@idCliente", ng.cliente.idCliente); 
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        //buscaNegocio
        public Negocio buscaNegocio(string idNeg)
        {
            var cn = cnx.getConexion();
            Negocio ng = new Negocio();
            Personal pers = new Personal();
            Tipo tpo = new Tipo();
            Estado sto = new Estado();
            Cliente cli = new Cliente();

            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_BUSCA_NEGOCIO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idNegocio", idNeg);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ng.idNegocio = dr.GetInt64(0);
                ng.nombre = dr.GetString(1);
                pers.idPersonal = dr.GetInt32(2);
                pers.nombres = dr.GetString(3);
                pers.primerApellido = dr.GetString(4);
                pers.segundoApellido = dr.GetString(5);
                ng.responsable = pers;
                ng.descripcion = dr.GetString(6);
                tpo.idTipo = dr.GetInt32(7);
                tpo.descripcion = dr.GetString(8);
                ng.tipo = tpo;
                ng.fechaInicio = dr.GetString(9);
                ng.fechaFin = dr.GetString(10);
                ng.fechaRegistro = dr.GetString(11);
                sto.idEstado = dr.GetInt32(12);
                sto.descripcion = dr.GetString(13);
                ng.estado = sto;
                ng.fechaModificacion = dr.GetString(14);
                cli.idCliente = dr.GetInt64(15);
                cli.nombres = dr.GetString(16);
                cli.primerApellido = dr.GetString(17);
                cli.segundoApellido = dr.GetString(18);
                ng.cliente = cli;
            }
            cn.Close();
            return ng;
        }

        //actualizaDatoNegocio
        public void actualizaDatoNegocio(Negocio ng)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZA_DATO_NEGOCIO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idNegocio", ng.idNegocio);
            cmd.Parameters.AddWithValue("@nom", ng.nombre);
            cmd.Parameters.AddWithValue("@idResponsable", ng.responsable.idPersonal);
            cmd.Parameters.AddWithValue("@descripcion", ng.descripcion);
            cmd.Parameters.AddWithValue("@tipo", ng.tipo.idTipo);
            cmd.Parameters.AddWithValue("@fechaInicio", ng.fechaInicio);
            cmd.Parameters.AddWithValue("@fechaFin", ng.fechaFin);
            cmd.Parameters.AddWithValue("@idCliente", ng.cliente.idCliente);
            cmd.Parameters.AddWithValue("@idEstado", ng.estado.idEstado);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }



        //listarNegocioSelect
        public List<Negocio> listaNegocioSelect()
        {
            List<Negocio> lista = new List<Negocio>();
            var cn = cnx.getConexion();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTA_NEGOCIOS_SELECT", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Negocio ng = new Negocio();
                ng.idNegocio = dr.GetInt64(0);
                ng.nombre = dr.GetString(1);
                lista.Add(ng);
            }
            cn.Close();
            return lista;
        }

        //listaEstadoNegocio
        public List<Estado> listaEstadoNegocio()
        {
            List<Estado> lista = new List<Estado>();
            var cn = cnx.getConexion();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_ESTADO_NEGOCIO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Estado es = new Estado();
                es.idEstado = dr.GetInt32(0);
                es.descripcion = dr.GetString(1);
                lista.Add(es);
            }
            cn.Close();
            return lista;
        }



    }
}