using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Beans;
using System.Data;
using System.Data.SqlClient;


namespace GestionNegocio_WebApp.Models
{
    public class KardexModel
    {
        //conetion
        ConexionModel cnx = new ConexionModel();


        //listarKardex
        public List<Kardex> listaKardex()
        {
            List<Kardex> lista = new List<Kardex>();
            var cn = cnx.getConexion();
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_KARDEX", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Kardex kx = new Kardex();
                Material mt = new Material();
                mt.descripcion = dr.GetString(0);
                kx.material = mt;
                kx.fecha = dr.GetString(1);
                kx.pedidos = dr.GetInt32(2);
                kx.compras = dr.GetInt32(3);
                kx.total = dr.GetInt32(4);
                lista.Add(kx);
            }
            cn.Close();
            return lista;
        }

    }
}