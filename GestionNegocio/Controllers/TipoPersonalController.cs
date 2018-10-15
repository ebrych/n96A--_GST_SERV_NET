using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionNegocio_WebApp.Models;
using Beans;

namespace GestionNegocio_WebApp.Controllers
{
    public class TipoPersonalController : Controller
    {
        //-----------------------------------------------------Modelo
        TipoModel model = new TipoModel();
        ValidacionModel validacion = new ValidacionModel();



        //-----------------------------------------------------Lista
        public ActionResult Index()
        {
            string ruta = "/TipoPersonal";
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
                    List<Tipo> listaTipoPers = new List<Tipo>();
                    listaTipoPers = model.listarTipoPersonalTotal();
                    ViewBag.tiposPersonal = listaTipoPers;
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
            string ruta = "/TipoPersonal/nuevo";
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
        public ActionResult agregaTipoPersonal(string desc, string estado)
        {
            string ruta = "/TipoPersonal/nuevo";
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
                    model.agregaTipoPersonal(desc, estado);
                    return RedirectToAction("/");
                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }
            }
        }

        //-----------------------------------------------------actualiza
        public ActionResult actualizaTiposPersonal(string ident)
        {
            string ruta = "/TipoPersonal/actualizar";
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
                    Tipo tipoPersonal = new Tipo();
                    tipoPersonal = model.buscarTipoPersonal(ident);
                    ViewBag.tipoPersonal = tipoPersonal;
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
        public ActionResult actualizarDatoTipoPersonal(string id, string desc, string estado)
        {
            string ruta = "/TipoPersonal/actualizar";
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
                    model.actualizarTipoPersonal(id,desc,estado);
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