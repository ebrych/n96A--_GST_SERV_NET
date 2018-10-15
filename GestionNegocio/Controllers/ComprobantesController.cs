using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionNegocio_WebApp.Models;
using Beans;

namespace GestionNegocio_WebApp.Controllers
{
    public class ComprobantesController : Controller
    {

        //-----------------------------------------------------Modelo
        ComprobanteModel model = new ComprobanteModel();
        ValidacionModel validacion = new ValidacionModel();
        TipoModel tipoModel = new TipoModel();
        ClienteModel clienteModel = new ClienteModel();
        NegocioModel negocioModel = new NegocioModel();



        //-----------------------------------------------------Lista
        public ActionResult Index()
        {
            string ruta = "/Comprobante";
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
                    List<Comprobante> lstComprobantes = new List<Comprobante>();
                    lstComprobantes = model.listaComprobantes();
                    ViewBag.listaComprobante = lstComprobantes;
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


        public ActionResult nuevoComprobante()
        {
            string ruta = "/Comprobante/nuevo";
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
                    List<Negocio> ng = new List<Negocio>();
                    List<Cliente> cl = new List<Cliente>();
                    List<Tipo> tpo = new List<Tipo>();
                    List<Estado> std = new List<Estado>();
                    ng = negocioModel.listaNegocio();
                    cl = clienteModel.listarCliente();
                    tpo = tipoModel.listarTipoComprobante();
                    std = model.listarEstados();
                    ViewBag.negocios = ng;
                    ViewBag.clientes = cl;
                    ViewBag.tipoComprobante = tpo;
                    ViewBag.estados = std;
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
        public ActionResult agregarComprobante(string serie, string num, string neg, string cli, string tpo, string feImp, string fePgo, string desc, string est)
        {
            string ruta = "/Comprobante/nuevo";
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
                    Comprobante comp = new Comprobante();
                    Cliente cl = new Cliente();
                    Tipo tip = new Tipo();
                    Estado stdo = new Estado();
                    Negocio ng = new Negocio();
                    Tipo tipo = new Tipo();
                     
                    comp.serie = serie;
                    comp.numeroComprobante = num;
                    ng.idNegocio = Int64.Parse(neg);
                    comp.negocio = ng;
                    cl.idCliente = Int64.Parse(cli);
                    comp.cliente = cl;
                    tipo.idTipo = Int32.Parse(tpo);
                    comp.tipo = tipo;
                    comp.fechaImprecion = feImp;
                    comp.fechaPago = fePgo;
                    comp.descripcion = desc;
                    stdo.idEstado = Int32.Parse(est);
                    comp.estado = stdo;

                    model.agregarComprobante(comp);
                    return RedirectToAction("/");
                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }

            }
        }



        //-----------------------------------------------------ActualizarComprobante
        public ActionResult actualizaComprobante(string idt)
        {
            string ruta = "/Comprobante/actualizar";
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
                    List<Negocio> ng = new List<Negocio>();
                    List<Cliente> cl = new List<Cliente>();
                    List<Tipo> tpo = new List<Tipo>();
                    List<Estado> std = new List<Estado>();
                    Comprobante comp = new Comprobante();
                    comp = model.buscarComprobante(idt);
                    ng = negocioModel.listaNegocio();
                    cl = clienteModel.listarCliente();
                    tpo = tipoModel.listarTipoComprobante();
                    std = model.listarEstados();
                    ViewBag.negocios = ng;
                    ViewBag.clientes = cl;
                    ViewBag.tipoComprobante = tpo;
                    ViewBag.estados = std;
                    ViewBag.comprobante = comp;
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
        public ActionResult actualizaDatoCompobante(string id, string serie, string num, string neg, string cli, string tpo, string feImp, string fePgo, string desc, string est)
        {
            string ruta = "/Comprobante/actualizar";
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
                    model.actualizaComprobante(id, serie, num, neg, cli, tpo, fePgo, desc, est);
                    return RedirectToAction("/");
                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }

            }
        }



        public ActionResult DetalleComprobante(string idt)
        {
            string ruta = "/Comprobante/detalle";
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
                    List<Concepto> listaConceptos = new List<Concepto>();
                    List<DetalleComprobante> listaDetalles = new List<Beans.DetalleComprobante>();
                    listaConceptos = model.listarConceptos();
                    listaDetalles = model.listarDetalleComprobante(idt);
                    ViewBag.conceptos = listaConceptos;
                    ViewBag.listaDetalles = listaDetalles;
                    ViewBag.idComp = idt;
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
        public ActionResult agregaDetalle(string idCom, string concep, string cant, string mont)
        {
            string ruta = "/Comprobante/detalle";
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
                    model.agregarDetalleComprobante(idCom, cant, mont, concep);
                    return RedirectToAction("/");  
                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }

            }
        }

        public ActionResult elimnaDetalle(string idDetalleComprobante)
        {
            string ruta = "/Comprobante/detalle";
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
                    model.eliminaDetalleComrpobante(idDetalleComprobante);
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