using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionNegocio_WebApp.Models;
using Beans;

namespace GestionNegocio_WebApp.Controllers
{
    public class RespuestaNotaController : Controller
    {
        //-----------------------------------------------------Modelo
        ValidacionModel validacion = new ValidacionModel();
        NotaModel notaModel = new NotaModel();



        //-----------------------------------------------------Lista
        public ActionResult Index()
        {
            string ruta = "/RespuestaNotas";
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
                    List<Nota> listaNotas = new List<Nota>();
                    listaNotas = notaModel.listarNotas();
                    ViewBag.listaNotas = listaNotas;
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

        public ActionResult RespuestaNota(string idt)
        {
            string ruta = "/RespuestaNotas/respuesta";
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
                    Nota nota = new Nota();
                    List<Estado> estado = new List<Estado>();
                    List<DetalleNota> detalle = new List<DetalleNota>();
                    estado = notaModel.listarEstados();
                    nota = notaModel.buscarNotas(idt);
                    detalle = notaModel.listarDetalleNota(idt);
                    ViewBag.nota = nota;
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
        public ActionResult respondeNota(string idNt, string resp)
        {
            string ruta = "/RespuestaNotas/respuesta";
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
                    string idUser = Session["id"].ToString();
                    notaModel.respondeNota(idNt, resp, idUser);
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