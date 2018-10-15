using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Beans;
using System.Data;
using System.Data.SqlClient;

namespace GestionNegocio_WebApp.Models
{
    public class MaterialModel
    {
        //conetion
        ConexionModel cnx = new ConexionModel();

        //listaMaterial
        public List<Material> listaMaterial()
        {
            var cn = cnx.getConexion();
            List<Material> lista = new List<Material>();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTA_MATERIAL", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Material mat = new Material();
                Tipo tpo = new Tipo();
                Estado est = new Estado();
                mat.idMaterial = dr.GetInt32(0);
                mat.descripcion = dr.GetString(1);
                tpo.descripcion= dr.GetString(2);
                mat.tipo = tpo;
                mat.unidad = dr.GetString(3);
                mat.fechaRegistro = dr.GetString(4);
                mat.fechaModificacion = dr.GetString(5);
                est.descripcion = dr.GetString(6);
                mat.estado = est;
                lista.Add(mat);
            }
            cn.Close();
            return lista;
        }

        //registraMateria;
        public void agregaMaterial(Material mt)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_REGISTRAR_MATERIAL", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@descripcion", mt.descripcion);
            cmd.Parameters.AddWithValue("@tipo", mt.tipo.idTipo);
            cmd.Parameters.AddWithValue("@unidad", mt.unidad);
            cmd.Parameters.AddWithValue("@estado", mt.estado.idEstado);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        //buscaMateria
        public Material buscaMaterial(string id)
        {
            var cn = cnx.getConexion();
            Material mat = new Material();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_BUSCA_MATERIAL", cn);
            cmd.Parameters.AddWithValue("@idMaterial", id);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Tipo tpo = new Tipo();
                Estado est = new Estado();
                mat.idMaterial = dr.GetInt32(0);
                mat.descripcion = dr.GetString(1);
                tpo.idTipo = dr.GetInt32(2);
                mat.tipo = tpo;
                mat.unidad = dr.GetString(3);
                mat.fechaRegistro = dr.GetString(4);
                mat.fechaModificacion = dr.GetString(5);
                est.idEstado = dr.GetByte(6);
                mat.estado = est;
            }
            cn.Close();
            return mat;
        }

        //actualizaMaterial
        public void actualizaDatoMaterial(Material mt)
        {
            var cn = cnx.getConexion();
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZAR_MATERIAL", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idMaterial", mt.idMaterial);
            cmd.Parameters.AddWithValue("@descripcion", mt.descripcion);
            cmd.Parameters.AddWithValue("@tipo", mt.tipo.idTipo);
            cmd.Parameters.AddWithValue("@unidad", mt.unidad);
            cmd.Parameters.AddWithValue("@estado", mt.estado.idEstado);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }


    }
}