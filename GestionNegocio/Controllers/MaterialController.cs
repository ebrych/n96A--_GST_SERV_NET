using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionNegocio_WebApp.Models;
using Beans;

namespace GestionNegocio_WebApp.Controllers
{
    public class MaterialController : Controller
    {

        //-----------------------------------------------------Modelo
        MaterialModel model = new MaterialModel();
        ValidacionModel validate = new ValidacionModel();
        TipoModel tipoModel = new TipoModel();




        //-----------------------------------------------------Lista
        public ActionResult Index()
        {
            string ruta = "/Material";
            //sesion
            if (Session["token"] == null)
            {
                return RedirectToAction("./"); //salir a login
            }
            else
            {
                //permisos
                string tk = Session["token"].ToString();
                int permiso = validate.validarPermisos(tk, ruta);
                if (permiso != 0)
                {
                    //code
                    List<Material> material = new List<Material>();
                    material = model.listaMaterial();
                    ViewBag.material = material;
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
        public ActionResult nuevoMaterial()
        {
            string ruta = "/Material/nuevo";
            //sesion
            if (Session["token"] == null)
            {
                return RedirectToAction("./"); //salir a login
            }
            else
            {
                //permisos
                string tk = Session["token"].ToString();
                int permiso = validate.validarPermisos(tk, ruta);
                if (permiso != 0)
                {
                    //code
                    List<Tipo> tipoMaterial = new List<Tipo>();
                    tipoMaterial = tipoModel.listarTipoMaterial();
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


        //-----------------------------------------------------Insertra nuevo
        [HttpPost]
        public ActionResult agregaMaterial(string desc, string tpo, string unidad,string estado)
        {
            string ruta = "/Material/nuevo";
            //sesion
            if (Session["token"] == null)
            {
                return RedirectToAction("./"); //salir a login
            }
            else
            {
                //permisos
                string tk = Session["token"].ToString();
                int permiso = validate.validarPermisos(tk, ruta);
                if (permiso != 0)
                {
                    //code
                    Material mt = new Material();
                    Tipo tipo = new Tipo();
                    Estado est = new Estado();
                    mt.descripcion = desc;
                    tipo.idTipo = Int32.Parse(tpo);
                    mt.tipo = tipo;
                    mt.unidad = unidad;
                    est.idEstado = Int32.Parse(estado);
                    mt.estado = est;
                    model.agregaMaterial(mt);
                    return RedirectToAction("/");
                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }
            }
        }


        //-----------------------------------------------------actualiza
        public ActionResult actualizaMaterial(string ident)
        {
            string ruta = "/Material/actualizar";
            //sesion
            if (Session["token"] == null)
            {
                return RedirectToAction("./"); //salir a login
            }
            else
            {
                //permisos
                string tk = Session["token"].ToString();
                int permiso = validate.validarPermisos(tk, ruta);
                if (permiso != 0)
                {
                    //code
                    Material material = new Material();
                    List<Tipo> tipoMaterial = new List<Tipo>();
                    material = model.buscaMaterial(ident);
                    tipoMaterial = tipoModel.listarTipoMaterial();
                    ViewBag.material = material;
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


        //-----------------------------------------------------inserta dato actualiza
        [HttpPost]
        public ActionResult actualizarDatoMaterial(string id, string desc, string tpo, string unidad,string estado)
        {
            string ruta = "/Material/actualizar";
            //sesion
            if (Session["token"] == null)
            {
                return RedirectToAction("./"); //salir a login
            }
            else
            {
                //permisos
                string tk = Session["token"].ToString();
                int permiso = validate.validarPermisos(tk, ruta);
                if (permiso != 0)
                {
                    //code
                    Material mt = new Material();
                    Tipo tipo = new Tipo();
                    Estado est = new Estado();
                    mt.idMaterial = Int32.Parse(id);
                    mt.descripcion = desc;
                    tipo.idTipo = Int32.Parse(tpo);
                    mt.tipo = tipo;
                    mt.unidad = unidad;
                    est.idEstado = Int32.Parse(estado);
                    mt.estado = est;
                    model.actualizaDatoMaterial(mt);
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