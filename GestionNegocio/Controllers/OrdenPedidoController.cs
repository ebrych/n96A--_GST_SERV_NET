using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beans;
using GestionNegocio_WebApp.Models;

namespace GestionNegocio_WebApp.Controllers
{
    public class OrdenPedidoController : Controller
    {
        //-----------------------------------------------------Modelo
        OrdenPedidoModel model = new OrdenPedidoModel();
        ValidacionModel validacion = new ValidacionModel();
        NegocioModel negocioModel = new NegocioModel();
        MaterialModel materialModel = new MaterialModel();


        //-----------------------------------------------------Lista
        public ActionResult Index()
        {
            string ruta = "/OrdenPedido";
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
                    List<OrdenPedido> ordn = new List<OrdenPedido>();
                    ordn = model.listarOrdenDePedido();
                    ViewBag.ordenPedido = ordn;
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


        public ActionResult nuevoOrdenPedido()
        {
            string ruta = "/OrdenPedido/nuevo";
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
                    List<Negocio> negocios = new List<Negocio>();
                    negocios = negocioModel.listaNegocio();
                    ViewBag.negocios = negocios;
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
        public ActionResult agregarOrdenPedido(string negocio,string desc)
        {
            string ruta = "/OrdenPedido/nuevo";
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
                    string usuario = Session["id"].ToString();
                    model.agregarOrdenDePedido(negocio, usuario, desc);
                    return RedirectToAction("/");
                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }

            }
        }


        public ActionResult ActualizarOrdenPedido(string idt)
        {
            string ruta = "/OrdenPedido/actualizar";
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
                    List<Negocio> negocios = new List<Negocio>();
                    OrdenPedido ordn = new OrdenPedido();
                    ordn = model.buscarOrdenDePedido(idt);
                    negocios = negocioModel.listaNegocio();
                    ViewBag.negocios = negocios;
                    ViewBag.ordenPedido = ordn;
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
        public ActionResult actualizaDatoOrdenPedido(string id,string negocio, string desc)
        {
            string ruta = "/OrdenPedido/actualizar";
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
                    string usuario = Session["id"].ToString();
                    model.actualizarOrdenPedido(id, negocio, usuario,desc);
                    return RedirectToAction("/");
                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }

            }
        }




        public ActionResult DetalleOrdenPedido(string idt)
        {
            string ruta = "/OrdenPedido/detalle";
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
                    List<DetalleOrdenPedido> detalles = new List<Beans.DetalleOrdenPedido>();
                    List<Material> materiales = new List<Material>();
                    detalles = model.listarDetalleOrdenPedido(idt);
                    materiales = materialModel.listaMaterial();
                    ViewBag.detallesOrdenPedido = detalles;
                    ViewBag.materiales = materiales;
                    ViewBag.ordenPedido = idt;
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

        //-----------------------------------------------------Insertra Detalle
        [HttpPost]
        public ActionResult agregaDetalle(string idOrPed, string idMat,string cant)
        {
            string ruta = "/OrdenPedido/detalle";
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
                    
                    model.agregarDetalleOrdenPedido(idOrPed,idMat, cant);
                    return RedirectToAction("/");
                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }

            }
        }


        public ActionResult elimnaDetalle(string idDetalle)
        {
            string ruta = "/OrdenPedido/detalle";
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
                    model.eliminaDetalleOrdenPedido(idDetalle);
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