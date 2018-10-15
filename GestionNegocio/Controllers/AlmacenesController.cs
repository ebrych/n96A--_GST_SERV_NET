using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionNegocio_WebApp.Models;
using Beans;

namespace GestionNegocio_WebApp.Controllers
{
    public class AlmacenesController : Controller
    {
        //-----------------------------------------------------Modelo
        AlmacenModel model = new AlmacenModel();
        ValidacionModel validation = new ValidacionModel();

        //-----------------------------------------------------Lista
        public ActionResult Index()
        {
            string ruta = "/Almacen";
            //sesion
            if (Session["token"] == null)
            {
                return RedirectToAction("./"); //salir a login
            }
            else
            {
                //permisos
                string tk = Session["token"].ToString();
                int permiso = validation.validarPermisos(tk, ruta);
                if (permiso != 0)
                {
                    //code
                    List<Almacen> almacenes = new List<Almacen>();
                    almacenes = model.listarAlamacenes();
                    ViewBag.almacenes = almacenes;
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
        public ActionResult nuevoAlmacen()
        {
            string ruta = "/Almacen/nuevo";
            //sesion
            if (Session["token"] == null)
            {
                return RedirectToAction("./"); //salir a login
            }
            else
            {
                //permisos
                string tk = Session["token"].ToString();
                int permiso = validation.validarPermisos(tk, ruta);
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
        public ActionResult agregaAlmacen(string nom, string dir, string telf,string estado)
        {
            string ruta = "/Almacen/nuevo";
            //sesion
            if (Session["token"] == null)
            {
                return RedirectToAction("./"); //salir a login
            }
            else
            {
                //permisos
                string tk = Session["token"].ToString();
                int permiso = validation.validarPermisos(tk, ruta);
                if (permiso != 0)
                {
                    //code
                    Almacen alm = new Almacen();
                    Estado est = new Estado();
                    alm.nombre = nom;
                    alm.direccion = dir;
                    alm.telefono = telf;
                    est.idEstado = Int32.Parse(estado);
                    alm.estado = est;
                    
                    model.agregarAlmacen(alm);
                    return RedirectToAction("/");
                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }
            }
        }

        //-----------------------------------------------------actualiza
        public ActionResult actualizaAlmacen(string ident)
        {
            string ruta = "/Almacen/actualizar";
            //sesion
            if (Session["token"] == null)
            {
                return RedirectToAction("./"); //salir a login
            }
            else
            {
                //permisos
                string tk = Session["token"].ToString();
                int permiso = validation.validarPermisos(tk, ruta);
                if (permiso != 0)
                {
                    //code
                    Almacen alm = new Almacen();
                    alm = model.buscaAlmacen(ident);
                    ViewBag.almacen = alm;
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

        //-----------------------------------------------------inserta dato actualiza
        [HttpPost]
        public ActionResult actualizarDatoMaterial(string id, string nom, string dir, string telf,string estado)
        {
            string ruta = "/Almacen/actualizar";
            //sesion
            if (Session["token"] == null)
            {
                return RedirectToAction("./"); //salir a login
            }
            else
            {
                //permisos
                string tk = Session["token"].ToString();
                int permiso = validation.validarPermisos(tk, ruta);
                if (permiso != 0)
                {
                    //code
                    Almacen alm = new Almacen();
                    Estado est = new Estado();
                    alm.idAlmacen = Int32.Parse(id);
                    alm.nombre = nom;
                    alm.direccion = dir;
                    alm.telefono = telf;
                    est.idEstado = Int32.Parse(estado);
                    alm.estado = est;

                    model.actualizaAlmacen(alm);
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