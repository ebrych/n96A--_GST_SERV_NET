using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionNegocio_WebApp.Models;
using Beans;

namespace GestionNegocio_WebApp.Controllers
{
    public class ClientesController : Controller
    {
        //-----------------------------------------------------Modelo
        ClienteModel model = new ClienteModel();
        ValidacionModel validation = new ValidacionModel();
        TipoModel tipoModel = new TipoModel();

        //-----------------------------------------------------Lista
        public ActionResult Index()
        {
            string ruta = "/Clientes";
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
                    List<Cliente> Cliente = new List<Cliente>();
                    Cliente = model.listarCliente();
                    ViewBag.Cliente = Cliente;
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
        public ActionResult nuevoCliente()
        {
            string ruta = "/Clientes/nuevo";
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
                    List<Tipo> tipoCliente = new List<Tipo>();
                    List<Tipo> tipoDocumento = new List<Tipo>();
                    tipoCliente = tipoModel.listarTipoCliente();
                    tipoDocumento = tipoModel.listarTipoDocumento();
                    ViewBag.tipoCliente = tipoCliente;
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
        [HttpPost]
        public ActionResult agregarCliente(string nom, string priAp, string segAp, string tpoDoc, string nroDoc, string telf, string dir, string cel, string mail, string tpo,string estado)
        {
            string ruta = "/Clientes/nuevo";
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
                    Cliente cl = new Cliente();
                    Tipo tipo = new Tipo();
                    Tipo tipoDoc = new Tipo();
                    Estado est = new Estado();
                    cl.nombres = nom;
                    cl.primerApellido = priAp;
                    cl.segundoApellido = segAp;
                    tipoDoc.idTipo = Int32.Parse(tpoDoc);
                    cl.tipoDocumento = tipoDoc;
                    cl.numeroDocumento = nroDoc;
                    cl.telefono = telf;
                    cl.direccion = dir;
                    cl.celular = cel;
                    cl.mail = mail;
                    tipo.idTipo = Int32.Parse(tpo);
                    cl.tipo = tipo;
                    est.idEstado = Int32.Parse(estado);
                    cl.estado = est;
                    model.agregarCliente(cl);
                    return RedirectToAction("/");
                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }

            }
        }
        public ActionResult actualizaCliente(string idcli)
        {
            string ruta = "/Clientes/actualizar";
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
                    Cliente cli = new Cliente();
                    List<Tipo> tipoCliente = new List<Tipo>();
                    List<Tipo> tipoDocumento = new List<Tipo>();
                    tipoCliente = tipoModel.listarTipoCliente();
                    tipoDocumento = tipoModel.listarTipoDocumento();
                    cli = model.buscaCliente(idcli);
                    ViewBag.cliente = cli;
                    ViewBag.tipoCliente = tipoCliente;
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
        [HttpPost]
        public ActionResult actualizaDatoCliente(string id, string nom, string priAp, string segAp, string tpoDoc, string nroDoc, string telf, string dir, string cel, string mail, string tpo,string estado)
        {
            string ruta = "/Clientes/actualizar";
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
                    Cliente cl = new Cliente();
                    Tipo tipo = new Tipo();
                    Tipo tipoDoc = new Tipo();
                    Estado est = new Estado();
                    cl.idCliente = Int64.Parse(id);
                    cl.nombres = nom;
                    cl.primerApellido = priAp;
                    cl.segundoApellido = segAp;
                    tipoDoc.idTipo = Int32.Parse(tpoDoc);
                    cl.tipoDocumento = tipoDoc;
                    cl.numeroDocumento = nroDoc;
                    cl.telefono = telf;
                    cl.direccion = dir;
                    cl.celular = cel;
                    cl.mail = mail;
                    tipo.idTipo = Int32.Parse(tpo);
                    cl.tipo = tipo;
                    est.idEstado = Int32.Parse(estado);
                    cl.estado = est;
                    model.actualizarDatoCliente(cl);
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