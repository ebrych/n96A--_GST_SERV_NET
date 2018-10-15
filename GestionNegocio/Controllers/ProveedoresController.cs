using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionNegocio_WebApp.Models;
using Beans;

namespace GestionNegocio_WebApp.Controllers
{
    public class ProveedoresController : Controller
    {

        //-----------------------------------------------------Modelo
        ProveedorModel model = new ProveedorModel();
        TipoModel tipoModel = new TipoModel();
        ValidacionModel validacion = new ValidacionModel();

        //-----------------------------------------------------Lista
        public ActionResult Index()
        {
            string ruta = "/Proveedores";
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
                    List<Proveedor> listaPro = new List<Proveedor>();
                    listaPro = model.listarProveedores();
                    ViewBag.listaPro = listaPro;
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
        public ActionResult nuevoProveedor()
        {
            string ruta = "/Proveedores/nuevo";
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
                    List<Tipo> tipoDocumento = new List<Tipo>();
                    tipoDocumento = tipoModel.listarTipoDocumento();
                    ViewBag.tipoDocumento = tipoDocumento;
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
        public ActionResult agregaProveedor(string nom, string prAp, string sgAp, string tpoDoc ,string numDoc, string dir, string telf, string cel, string mail,string estado)
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
                int permiso = validacion.validarPermisos(tk, ruta);
                if (permiso != 0)
                {
                    //code
                    Proveedor prv = new Proveedor();
                    Estado est = new Estado();
                    Tipo tipoDoc = new Tipo();
                    prv.nombres = nom;
                    prv.primerApellido = prAp;
                    prv.segundoApellido = sgAp;
                    tipoDoc.idTipo = Int32.Parse(tpoDoc);
                    prv.tipoDocumento = tipoDoc;
                    prv.numeroDocumento = numDoc;
                    prv.direccion = dir;
                    prv.telefono = telf;
                    prv.celular = cel;
                    prv.mail = mail;
                    est.idEstado = Int32.Parse(estado);
                    prv.estado = est;

                    model.agregarProveedor(prv);
                    return RedirectToAction("/");
                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }
            }
        }

        //-----------------------------------------------------actualiza
        public ActionResult actualizaProveedor(string ident)
        {
            string ruta = "/Proveedores/actualizar";
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
                    Proveedor proveedor = new Proveedor();
                    List<Tipo> tipoDocumento = new List<Tipo>();
                    tipoDocumento = tipoModel.listarTipoDocumento();
                    ViewBag.tipoDocumento = tipoDocumento;
                    proveedor = model.buscarProveedor(ident);
                    ViewBag.proveedor = proveedor;
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
        public ActionResult actualizarDatoProveedor(string id, string nom, string prAp, string sgAp, string tpoDoc, string numDoc, string dir, string telf, string cel, string mail,string estado)
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
                int permiso = validacion.validarPermisos(tk, ruta);
                if (permiso != 0)
                {
                    //code
                    Proveedor prv = new Proveedor();
                    Estado est = new Estado();
                    Tipo tipoDoc = new Tipo();
                    prv.idProveedor = Int64.Parse(id);
                    prv.nombres = nom;
                    prv.primerApellido = prAp;
                    prv.segundoApellido = sgAp;
                    tipoDoc.idTipo = Int32.Parse(tpoDoc);
                    prv.tipoDocumento = tipoDoc;
                    prv.numeroDocumento = numDoc;
                    prv.direccion = dir;
                    prv.telefono = telf;
                    prv.celular = cel;
                    prv.mail = mail;
                    est.idEstado = Int32.Parse(estado);
                    prv.estado = est;
                    model.actualizaProveedor(prv);
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