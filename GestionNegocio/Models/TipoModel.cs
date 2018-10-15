using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Beans;

namespace GestionNegocio_WebApp.Models
{
    public class TipoModel
    {
        //conetion
        ConexionModel cnx = new ConexionModel();


        //listar tipoPersonal
        public List<Tipo> listarTipoPersonal()
        {
            var cn = cnx.getConexion();
            List<Tipo> lista = new List<Tipo>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("PS_LISTAR_TIPO_PERSONAL", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Tipo tpo = new Tipo();
                tpo.idTipo = dr.GetInt32(0);
                tpo.descripcion = dr.GetString(1);
                lista.Add(tpo);
            }
            cn.Close();
            return lista;
        }

        //lista tipoPersonalTotal
        public List<Tipo> listarTipoPersonalTotal()
        {
            var cn = cnx.getConexion();
            List<Tipo> lista = new List<Tipo>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_TIPO_PERSONAL_TOTAL", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Tipo tpo = new Tipo();
                Estado es = new Estado();
                tpo.idTipo = dr.GetInt32(0);
                tpo.descripcion = dr.GetString(1);
                es.idEstado = dr.GetByte(2);
                es.descripcion = dr.GetString(3);
                tpo.estado = es;
                lista.Add(tpo);
            }
            cn.Close();
            return lista;
        }

        //inserta tipoPersonal
        public void agregaTipoPersonal(string desc,string estado)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_AGREGAR_TIPO_PERSONAL", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@descripcion", desc);
            cmd.Parameters.AddWithValue("@estado", estado);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        //buscar tipoPersonal
        public Tipo buscarTipoPersonal(string id)
        {
            var cn = cnx.getConexion();
            Tipo tpo = new Tipo();
            Estado est = new Estado();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_TIPO_PERSONAL", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idTipoPersonal", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                tpo.idTipo = dr.GetInt32(0);
                tpo.descripcion = dr.GetString(1);
                est.idEstado = dr.GetByte(2);
                est.descripcion = dr.GetString(3);
                tpo.estado = est;
            }
            cn.Close();
            return tpo;
        }

        //inserta tipoPersonal
        public void actualizarTipoPersonal(string id,string desc, string estado)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZA_TIPO_PERSONAL", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idTipoPersonal", id);
            cmd.Parameters.AddWithValue("@descripcion", desc);
            cmd.Parameters.AddWithValue("@estado", estado);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }


        //listar tipoDocumento
        public List<Tipo> listarTipoDocumento()
        {
            var cn = cnx.getConexion();
            List<Tipo> lista = new List<Tipo>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTA_TIPO_DOCUMENTO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Tipo tpo = new Tipo();
                tpo.idTipo = dr.GetInt32(0);
                tpo.descripcion = dr.GetString(1);
                lista.Add(tpo);
            }
            cn.Close();
            return lista;
        }


        //listar tipoCliente
        public List<Tipo> listarTipoCliente()
        {
            var cn = cnx.getConexion();
            List<Tipo> lista = new List<Tipo>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_TIPO_CLIENTE", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Tipo tpo = new Tipo();
                tpo.idTipo = dr.GetInt32(0);
                tpo.descripcion = dr.GetString(1);
                lista.Add(tpo);
            }
            cn.Close();
            return lista;
        }

        //listarTipoMaterial
        public List<Tipo> listarTipoMaterial()
        {
            List<Tipo> lista = new List<Tipo>();
            var cn = cnx.getConexion();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTA_TIPO_MATERIAL", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Tipo tpo = new Tipo();
                tpo.idTipo = dr.GetInt32(0);
                tpo.descripcion = dr.GetString(1);
                lista.Add(tpo);
            }
            cn.Close();
            return lista;
        }

        //listarTipoMaterial
        public List<Tipo> listarTipoMaterialTotal()
        {
            List<Tipo> lista = new List<Tipo>();
            var cn = cnx.getConexion();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTA_TIPO_MATERIAL_TOTAL", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Tipo tpo = new Tipo();
                Estado es = new Estado();
                tpo.idTipo = dr.GetInt32(0);
                tpo.descripcion = dr.GetString(1);
                es.idEstado = dr.GetByte(2);
                es.descripcion = dr.GetString(3);
                tpo.estado = es;
                lista.Add(tpo);
            }
            cn.Close();
            return lista;
        }

        public void agregarTipoMaterial(string descripcion,string estado)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_AGREGAR_TIPO_MATERIAL", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@estado", estado);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public Tipo buscarTipoMaterial(string id)
        {
            var cn = cnx.getConexion();
            Tipo tpo = new Tipo();
            Estado est = new Estado();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_TIPO_MATERIAL", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idTipoMaterial", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                tpo.idTipo = dr.GetInt32(0);
                tpo.descripcion = dr.GetString(1);
                est.idEstado = dr.GetByte(2);
                est.descripcion = dr.GetString(3);
                tpo.estado = est;
            }
            cn.Close();
            return tpo;
        }

        public void actualizarTipoMaterial(string id, string desc, string estado)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZA_TIPO_MATERIAL", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idTipoMaterial", id);
            cmd.Parameters.AddWithValue("@descripcion", desc);
            cmd.Parameters.AddWithValue("@estado", estado);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }


        //listarTipoNota
        public List<Tipo> listarTipoNota()
        {
            List<Tipo> lista = new List<Tipo>();
            var cn = cnx.getConexion();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_TIPO_NOTA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Tipo tpo = new Tipo();
                tpo.idTipo = dr.GetInt32(0);
                tpo.descripcion = dr.GetString(1);
                lista.Add(tpo);
            }
            cn.Close();
            return lista;
        }





        //listaTipoNegocio
        public List<Tipo> listarTipoNegocio()
        {
            List<Tipo> lista = new List<Tipo>();
            var cn = cnx.getConexion();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTA_TIPO_NEGOCIO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Tipo tpo = new Tipo();
                tpo.idTipo = dr.GetInt32(0);
                tpo.descripcion = dr.GetString(1);
                lista.Add(tpo);
            }
            cn.Close();
            return lista;
        }


        //listarTipoNegocioTotal
        public List<Tipo> listarTipoNegocioTotal()
        {
            List<Tipo> lista = new List<Tipo>();
            var cn = cnx.getConexion();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTA_TIPO_NEGOCIO_TOTAL", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Tipo tpo = new Tipo();
                Estado es = new Estado();
                tpo.idTipo = dr.GetInt32(0);
                tpo.descripcion = dr.GetString(1);
                es.idEstado = dr.GetByte(2);
                es.descripcion = dr.GetString(3);
                tpo.estado = es;
                lista.Add(tpo);
            }
            cn.Close();
            return lista;
        }

        public void agregarTipoNegocio(string descripcion, string estado)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_AGREGA_TIPO_NEGOCIO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@estado", estado);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public Tipo buscarTipoNegocio(string id)
        {
            var cn = cnx.getConexion();
            Tipo tpo = new Tipo();
            Estado est = new Estado();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_BUSCA_TIPO_NEGOCIO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idTipoNEgocio", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                tpo.idTipo = dr.GetInt32(0);
                tpo.descripcion = dr.GetString(1);
                est.idEstado = dr.GetByte(2);
                est.descripcion = dr.GetString(3);
                tpo.estado = est;
            }
            cn.Close();
            return tpo;
        }

        public void actualizarTipoNegocio(string id, string desc, string estado)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZA_TIPO_NEGOCIO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idTipoNegocio", id);
            cmd.Parameters.AddWithValue("@descripcion", desc);
            cmd.Parameters.AddWithValue("@estado", estado);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }


        //listarTipoComprobante
        public List<Tipo> listarTipoComprobante()
        {
            List<Tipo> lista = new List<Tipo>();
            var cn = cnx.getConexion();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTA_TIPO_COMPROBANTE", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Tipo tpo = new Tipo();
                tpo.idTipo = dr.GetInt32(0);
                tpo.descripcion = dr.GetString(1);
                lista.Add(tpo);
            }
            cn.Close();
            return lista;
        }



    }
}