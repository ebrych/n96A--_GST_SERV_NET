using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Beans;
using System.Data;
using System.Data.SqlClient;

namespace GestionNegocio_WebApp.Models
{
    public class NotaModel
    {
        //conetion
        ConexionModel cnx = new ConexionModel();



        //listaNotas
        public List<Nota> listarNotas()
        {
            var cn = cnx.getConexion();
            List<Nota> lista = new List<Nota>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_NOTA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Nota nt = new Nota();
                Tipo tipo = new Tipo();
                Almacen alm = new Almacen();
                Usuario ussol = new Usuario();
                Usuario usres = new Usuario();
                Estado estado = new Estado();
                Referencia rf = new Referencia();

                nt.idNota = dr.GetInt64(0);
                alm.nombre = dr.GetString(1);
                nt.almacen = alm;
                nt.descripcion = dr.GetString(2);
                ussol.nombres = dr.GetString(3);
                nt.userSolicita = ussol;
                usres.nombres = dr.GetString(4);
                nt.userResponde = usres;
                nt.FechaSolicitud = dr.GetString(5);
                nt.FechaRespuesta = dr.GetString(6);
                rf.idReferencia = dr.GetInt64(7);
                nt.referencia = rf;
                tipo.descripcion = dr.GetString(8);
                nt.tipo = tipo;
                estado.descripcion = dr.GetString(9);
                nt.estado = estado;
                lista.Add(nt);
            }
            cn.Close();
            return lista;
        }

        //listarNotaSalida
        public List<Nota> listarNotaSalida()
        {
            var cn = cnx.getConexion();
            List<Nota> lista = new List<Nota>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_NOTA_SALIDA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Nota nt = new Nota();
                Almacen al = new Almacen();
                Usuario us = new Usuario();
                nt.idNota = dr.GetInt64(0);
                nt.descripcion = dr.GetString(1);
                us.nombres = dr.GetString(2);
                nt.userSolicita = us;
                al.nombre = dr.GetString(3);
                nt.almacen = al;
                lista.Add(nt);
            }
            cn.Close();
            return lista;
        }


        //agregarNota
        public void agregarNota(Nota nta,string idUser)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_AGREGAR_NOTA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idTipoNota", nta.tipo.idTipo);
            cmd.Parameters.AddWithValue("@idAlmacen", nta.almacen.idAlmacen);
            cmd.Parameters.AddWithValue("@descripcion", nta.descripcion);
            cmd.Parameters.AddWithValue("@idUserSol", idUser);
            cmd.Parameters.AddWithValue("@numRef", nta.referencia.idReferencia);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        //buscarNota
        public Nota buscarNotas(string idt)
        {
            var cn = cnx.getConexion();
            Nota nt = new Nota();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_NOTA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idNota", idt);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Tipo tipo = new Tipo();
                Almacen alm = new Almacen();
                Usuario ussol = new Usuario();
                Usuario usres = new Usuario();
                Estado estado = new Estado();
                Referencia rf = new Referencia();
                nt.idNota = dr.GetInt64(0);
                alm.idAlmacen = dr.GetInt32(1);
                alm.nombre = dr.GetString(2);
                nt.almacen = alm;
                nt.descripcion = dr.GetString(3);
                ussol.nombres = dr.GetString(4);
                nt.userSolicita = ussol;
                usres.nombres = dr.GetString(5);
                nt.userResponde = usres;
                nt.FechaSolicitud = dr.GetString(6);
                nt.FechaRespuesta = dr.GetString(7);
                rf.idReferencia= dr.GetInt64(8);
                nt.referencia = rf;
                tipo.idTipo = dr.GetInt32(9);
                tipo.descripcion = dr.GetString(10);
                nt.tipo = tipo;
                estado.idEstado = dr.GetInt32(11);
                estado.descripcion = dr.GetString(12);
                nt.estado = estado;
            }
            cn.Close();
            return nt;
        }


        //actualizaNota
        public void actualizaNota(Nota nta)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZAR_NOTA  ", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idNota", nta.idNota);  
            cmd.Parameters.AddWithValue("@idAlmacen", nta.almacen.idAlmacen);
            cmd.Parameters.AddWithValue("@descripcion", nta.descripcion);
            cmd.Parameters.AddWithValue("@idUserSol", nta.userSolicita.idUsuario);
            cmd.Parameters.AddWithValue("@idTipoNota", nta.tipo.idTipo);
            cmd.Parameters.AddWithValue("@idReferencia", nta.referencia.idReferencia);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        //listarDetalleNota
        public List<DetalleNota> listarDetalleNota(string idNota)
        {
            List<DetalleNota> lista = new List<DetalleNota>();
            var cn = cnx.getConexion();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_DETALLE_NOTA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idNota", idNota);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DetalleNota dtll = new DetalleNota();
                Nota nt = new Nota();
                Material mt = new Material();
                dtll.idDetalleNota = dr.GetInt64(0);
                nt.idNota = dr.GetInt64(1);
                dtll.nota = nt;
                mt.idMaterial = dr.GetInt32(2);
                mt.descripcion = dr.GetString(3);
                dtll.material = mt;
                dtll.Cantidad = dr.GetInt32(4);
                dtll.fechaRegistro = dr.GetString(5);
                lista.Add(dtll);
            }
            cn.Close();
            return lista;
        }

        //agregarDetalleNota
        public void agregarDetalleNota(DetalleNota dtll)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_AGREGAR_DETALLE_NOTA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idNota", dtll.nota.idNota);
            cmd.Parameters.AddWithValue("@idMaterial", dtll.material.idMaterial);
            cmd.Parameters.AddWithValue("@cantidad", dtll.Cantidad);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        //eliminarDetalleNota
        public void eliminarDetalleNota(string idt)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_ELIMINA_DETALLE_NOTA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idDetalleNota", idt);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        //estadoComprobante
        public List<Estado> listarEstados()
        {
            var cn = cnx.getConexion();
            List<Estado> lista = new List<Estado>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTA_ESTADO_NOTA", cn);
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

        //respondeNota
        public void respondeNota(string nota, string estado, string user)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_RESPONDE_NOTA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idNota", nota);
            cmd.Parameters.AddWithValue("@idEstado", estado);
            cmd.Parameters.AddWithValue("@idUser", user);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }




        //listarNotaSalida
        public List<Nota> listaNotaSalidaSelect()
        {
            var cn = cnx.getConexion();
            List<Nota> lista = new List<Nota>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTA_NEGOCIOS_SELECT", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Nota nta = new Nota();
                nta.idNota = dr.GetInt64(0);
                nta.descripcion = dr.GetString(1);
                lista.Add(nta);
            }
            cn.Close();
            return lista;
        }


        public int buscaTipoNota(string id)
        {
            var cn = cnx.getConexion();
            int tipo = 0;
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_BUSCA_TIPO_NOTA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idNota", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                tipo = dr.GetInt32(0);
            }
            cn.Close();
            return tipo;
        }



    }
}