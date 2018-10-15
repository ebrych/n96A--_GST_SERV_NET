using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionNegocio_WebApp.Models;
using Beans;


namespace GestionNegocio_WebApp.Controllers
{
    public class RespuestaCompraController : Controller
    {
        //-----------------------------------------------------Modelo
        CompraModel model = new CompraModel();
        ValidacionModel validacion = new ValidacionModel();


        //-----------------------------------------------------Lista
        public ActionResult Index()
        {
            string ruta = "/RespuestaCompra";
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
                    List<Compra> miscompras = new List<Compra>();
                    miscompras = model.listarCompras();
                    ViewBag.compras = miscompras;
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


        //-----------------------------------------------------Lista
        public ActionResult respondeCompra(string idt)
        {
            string ruta = "/RespuestaCompra/respuesta";
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
                    List<Estado> listaEstados = new List<Estado>();
                    Compra compra = new Compra();
                    compra = model.buscarCompra(idt);
                    listaEstados = model.listaEstadoCompra();
                    ViewBag.estados = listaEstados;
                    ViewBag.compra = compra;
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
        public ActionResult agregaRespuestaCompra(string idCompra,string resp)
        {
            string ruta = "/RespuestaCompra/respuesta";
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
                    model.respondeCompra(idCompra, resp);
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