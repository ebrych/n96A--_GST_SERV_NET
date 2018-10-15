using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionNegocio_WebApp.Models;
using Beans;


namespace GestionNegocio_WebApp.Controllers
{
    public class TipoMaterialController : Controller
    {
        //-----------------------------------------------------Modelo
        TipoModel model = new TipoModel();
        ValidacionModel validacion = new ValidacionModel();

        //-----------------------------------------------------Lista
        public ActionResult Index()
        {
            string ruta = "/TipoMaterial";
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
                    //code
                    List<Tipo> listaTipoMat = new List<Tipo>();
                    listaTipoMat = model.listarTipoMaterialTotal();
                    ViewBag.tiposMaterial = listaTipoMat;
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

        //-----------------------------------------------------Nuevo
        public ActionResult nuevo()
        {
            string ruta = "/TipoMaterial/nuevo";
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
                    //code
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


        //-----------------------------------------------------Insertra nuevo
        [HttpPost]
        public ActionResult agregaTipoMaterial(string desc, string estado)
        {
            string ruta = "/TipoMaterial/nuevo";
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
                    //code
                    model.agregarTipoMaterial(desc, estado);
                    return RedirectToAction("/");
                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }
            }
        }

        //-----------------------------------------------------actualiza
        public ActionResult actualizaTiposMaterial(string ident)
        {
            string ruta = "/TipoMaterial/actualizar";
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
                    //code busca concepto
                    Tipo tipoMaterial = new Tipo();
                    tipoMaterial = model.buscarTipoMaterial(ident);
                    ViewBag.tipoMaterial = tipoMaterial;
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

        //-----------------------------------------------------actualoiza dato actualiza
        [HttpPost]
        public ActionResult actualizarDatoTipoMaterial(string id, string desc, string estado)
        {
            string ruta = "/TipoMaterial/actualizar";
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
                    //code
                    model.actualizarTipoMaterial(id, desc, estado);
                    return RedirectToAction("/");
                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }

            }
        }


    }
}