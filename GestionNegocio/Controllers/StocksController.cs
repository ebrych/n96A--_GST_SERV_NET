using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionNegocio_WebApp.Models;
using Beans;

namespace GestionNegocio_WebApp.Controllers
{
    public class StocksController : Controller
    {
        //-----------------------------------------------------Modelo
        KardexModel model = new KardexModel();
        ValidacionModel validacion = new ValidacionModel();



        //-----------------------------------------------------Lista
        public ActionResult Index()
        {
            string ruta = "/Stocks";
            //sesion
            if (Session["token"] == null)
            {
                return RedirectToAction("./"); //salir a login
            }
            else
            {
                //permisos
                string tk = Session["token"].ToString();
                int permiso = validacion.validarPermisos(tk, ruta);
                if (permiso != 0)
                {
                    List<Kardex> listaMateriales = new List<Kardex>();
                    listaMateriales = model.listaKardex();
                    ViewBag.listaMateriales = listaMateriales;
                    ViewBag.nomUser = Session["nombre"];
                    ViewBag.empresa = Session["empresa"];
                    ViewBag.negocio = Session["negocio"];
                    ViewBag.color = Session["color"];
                    ViewBag.colorText = Session["colorText"];
                    return View();
                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }

            }
        }




    }
}