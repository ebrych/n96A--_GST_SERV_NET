using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionNegocio_WebApp.Models;
using Beans;

namespace GestionNegocio_WebApp.Controllers
{
    public class PersonalController : Controller
    {
        //-----------------------------------------------------Modelo
        PersonalModel model = new PersonalModel();
        TipoModel tipoModel = new TipoModel();
        ValidacionModel validation = new ValidacionModel();

        //-----------------------------------------------------Lista
        public ActionResult Index()
        {
            string ruta = "/Personal/";
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
                    List<Personal> personal = new List<Personal>();
                    personal = model.listarPersonal();
                    ViewBag.personal = personal;
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
        public ActionResult nuevoPersonal()
        {
            string ruta = "/Personal/nuevo";
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
                    List<Tipo> tipoPersonal = new List<Tipo>();
                    List<Tipo> tipoDocumento = new List<Tipo>();
                    tipoDocumento = tipoModel.listarTipoDocumento();
                    tipoPersonal = tipoModel.listarTipoPersonal();
                    ViewBag.tipoDocumento = tipoDocumento;
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

        //-----------------------------------------------------Insertra nuevo
        [HttpPost]
        public ActionResult agregarPersonal(string nom, string priAp, string segAp, string tpoDoc, string doc, string telf, string dir, string mail, string tpo,string estado)
        {
            string ruta = "/Personal/nuevo";
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
                    Personal pers = new Personal();
                    Tipo tipoDoc = new Tipo();
                    Tipo tipoPer = new Tipo();
                    Estado est = new Estado();
                    pers.nombres = nom;
                    pers.primerApellido = priAp;
                    pers.segundoApellido = segAp;
                    tipoDoc.idTipo = Int32.Parse(tpoDoc);
                    pers.tipoDocumento = tipoDoc;
                    pers.documento = doc;
                    pers.telefono = telf;
                    pers.direccion = dir;
                    pers.mail = mail;
                    tipoPer.idTipo = Int32.Parse(tpo);
                    pers.tipo = tipoPer;
                    est.idEstado= Int32.Parse(estado);
                    pers.estado = est;
                    model.agregarPersonal(pers);
                    return RedirectToAction("/");
                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }

            }
        }

        //-----------------------------------------------------actualiza
        public ActionResult actualizaPersonal(string ident)
        {
            string ruta = "/Personal/actualizar";
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
                    Personal personal = new Personal();
                    List<Tipo> tipoPersonal = new List<Tipo>();
                    List<Tipo> tipoDocumento = new List<Tipo>();
                    tipoDocumento = tipoModel.listarTipoDocumento();
                    personal = model.buscaPersonal(ident);
                    tipoPersonal = tipoModel.listarTipoPersonal();
                    ViewBag.tipoDocumento = tipoDocumento;
                    ViewBag.personal = personal;
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

        //-----------------------------------------------------inserta dato actualiza
        [HttpPost]
        public ActionResult actualizarDatoPersonal(string id, string nom, string priAp, string segAp, string tpoDoc ,string doc, string telf, string dir, string mail, string tpo,string estado)
        {
            string ruta = "/Personal/actualizar";
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
                    Personal pers = new Personal();
                    Tipo tipoDoc = new Tipo();
                    Tipo tipoPer = new Tipo();
                    Estado est = new Estado();
                    pers.idPersonal = Int32.Parse(id);
                    pers.nombres = nom;
                    pers.primerApellido = priAp;
                    pers.segundoApellido = segAp;
                    tipoDoc.idTipo = Int32.Parse(tpoDoc);
                    pers.tipoDocumento = tipoDoc;
                    pers.documento = doc;
                    pers.telefono = telf;
                    pers.direccion = dir;
                    pers.mail = mail;
                    tipoPer.idTipo = Int32.Parse(tpo);
                    pers.tipo = tipoPer;
                    est.idEstado = Int32.Parse(estado);
                    pers.estado = est;
                    model.actualizaDatoPersonal(pers);
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