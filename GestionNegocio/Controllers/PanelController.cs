using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beans;
using GestionNegocio_WebApp.Models;


namespace GestionNegocio_WebApp.Controllers
{
    public class PanelController : Controller
    {
        //-----------------------------------------------------Modelo
        PanelModel model = new PanelModel();

        //-----------------------------------------------------CargarPanel
        public ActionResult Index()
        {
            string ruta = "/Panel";
            try
            {
                if (Session["token"] == null)
                {
                    return RedirectToAction("/");
                }
                else
                {
                    string token = Session["token"].ToString();
                    ViewBag.modulos = model.modulosUsuario(token);
                    ViewBag.nomUser = Session["nombre"];
                    ViewBag.empresa = Session["empresa"];
                    ViewBag.negocio = Session["negocio"];
                    ViewBag.color = Session["color"];
                    ViewBag.colorText = Session["colorText"];
                    return View();
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("/Home/Error");
            }
        }



    }
}