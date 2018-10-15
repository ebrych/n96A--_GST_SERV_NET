using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionNegocio_WebApp.Models;
using Beans;


namespace GestionNegocio_WebApp.Controllers
{
    public class RespuestaOrdenPedidoController : Controller
    {
        //-----------------------------------------------------Modelo
        OrdenPedidoModel model = new OrdenPedidoModel();
        ValidacionModel validacion = new ValidacionModel();

        //-----------------------------------------------------Lista
        public ActionResult Index()
        {
            string ruta = "/RespuestaOrdenPedido";
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


        public ActionResult RespuestaOrdenPedido(string idt)
        {
            string ruta = "/RespuestaOrdenPedido/respuesta";
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
                    OrdenPedido pedido = new OrdenPedido();
                    List<DetalleOrdenPedido> detalle = new List<DetalleOrdenPedido>();
                    List<Estado> estado = new List<Estado>();
                    estado = model.listarEstados();
                    detalle = model.listarDetalleOrdenPedido(idt);
                    pedido = model.buscarOrdenDePedido(idt);
                    ViewBag.pedido = pedido;
                    ViewBag.detalle = detalle;
                    ViewBag.estados = estado;
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
        public ActionResult respondeOrdenPedido(string idOrd, string resp, string detalle)
        {
            string ruta = "/RespuestaOrdenPedido/respuesta";
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
                    string idUser = Session["id"].ToString();
                    model.responderOrdenPedido(idOrd, resp, idUser,detalle);
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