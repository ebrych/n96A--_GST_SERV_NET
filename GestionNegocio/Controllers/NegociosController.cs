using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionNegocio_WebApp.Models;
using Beans;


namespace GestionNegocio_WebApp.Controllers
{

    public class NegociosController : Controller
    {
        //-----------------------------------------------------Modelo
        NegocioModel model = new NegocioModel();
        TipoModel tipoModel = new TipoModel();
        ValidacionModel validacion = new ValidacionModel();
        ClienteModel clienteModel = new ClienteModel();
        PersonalModel personalModel = new PersonalModel();
        MaterialModel materialModel = new MaterialModel();

        //-----------------------------------------------------Lista
        public ActionResult Index()
        {
            string ruta = "/Negocio";
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
                    //codigo
                    List<Negocio> negocios = new List<Negocio>();
                    negocios = model.listaNegocio();
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


        //-----------------------------------------------------nuevo
        public ActionResult Nuevo()
        {
            string ruta = "/Negocio/nuevo";
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
                    //codigo
                    List<Cliente> clientes = new List<Cliente>();
                    List<Tipo> tipoNegocio = new List<Tipo>();
                    List<Personal> personal = new List<Personal>();
                    tipoNegocio = tipoModel.listarTipoNegocio();
                    clientes = clienteModel.listarCliente();
                    personal = personalModel.listarPersonal();
                    ViewBag.clientes = clientes;
                    ViewBag.personal = personal;
                    ViewBag.tipos = tipoNegocio;
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


        //-----------------------------------------------------agregaDatos
        [HttpPost]
        public ActionResult insertaNuevo(string nom, string resp, string desc, string feIn, string feFn, string tpo, string cli)
        {
            string ruta = "/Negocio/nuevo";
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
                    //codigo
                    Negocio ng = new Negocio();
                    Personal prs = new Personal();
                    Tipo tipo = new Tipo();
                    Cliente cl = new Cliente();
                    ng.nombre = nom;
                    prs.idPersonal = Int32.Parse(resp);
                    ng.responsable = prs;
                    ng.descripcion = desc;
                    tipo.idTipo = Int32.Parse(tpo);
                    ng.tipo = tipo;
                    cl.idCliente = Int32.Parse(cli);
                    ng.cliente = cl;
                    ng.fechaInicio = feIn;
                    ng.fechaFin = feFn;

                    model.agregarNegocio(ng);
                    return RedirectToAction("/");
                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }

            }
        }


        public ActionResult actualizaNegocio(String idNeg)
        {
            string ruta = "/Negocio/actualiza";
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
                    //codigo
                    List<Personal> personal = new List<Personal>();
                    List<Tipo> tipoNegocio = new List<Tipo>();
                    Negocio negocio = new Negocio();
                    List<Cliente> cl = new List<Cliente>();
                    List<Estado> estados = new List<Estado>();
                    estados = model.listaEstadoNegocio();
                    cl = clienteModel.listarCliente();
                    negocio = model.buscaNegocio(idNeg);
                    tipoNegocio = tipoModel.listarTipoNegocio();
                    personal = personalModel.listarPersonal();
                    ViewBag.estados = estados;
                    ViewBag.personal = personal;
                    ViewBag.negocios = negocio;
                    ViewBag.tipos = tipoNegocio;
                    ViewBag.clientes = cl;
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

        //-----------------------------------------------------actualizarDatos
        [HttpPost]
        public ActionResult actualizaDato(string id, string nom, string resp, string desc, string feIn, string feFn, string tpo, string cli,string est)
        {
            string ruta = "/Negocio/actualiza";
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
                    Negocio ng = new Negocio();
                    Personal prs = new Personal();
                    Tipo tipo = new Tipo();
                    Cliente cl = new Cliente();
                    Estado es = new Estado();
                    ng.idNegocio = Int64.Parse(id);
                    ng.nombre = nom;
                    prs.idPersonal = Int32.Parse(resp);
                    ng.responsable = prs;
                    ng.descripcion = desc;
                    tipo.idTipo = Int32.Parse(tpo);
                    ng.tipo = tipo;
                    cl.idCliente = Int32.Parse(cli);
                    ng.cliente = cl;
                    ng.fechaInicio = feIn;
                    ng.fechaFin = feFn;
                    es.idEstado = Int32.Parse(est);
                    ng.estado = es;
                    model.actualizaDatoNegocio(ng);
                    return RedirectToAction("/");
                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }

            }
        }


        //-----------------------------------------------------personal
        public ActionResult personal(string idNeg)
        {
            string ruta = "/Negocio/personal";
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
                    List<Personal> personal = new List<Personal>();
                    List<Personal> listaPersonal = new List<Personal>();
                    personal = personalModel.listarPersonal();
                    listaPersonal = personalModel.listaPersonalNegocio(idNeg);
                    ViewBag.personal = personal;
                    ViewBag.listaPersonal = listaPersonal;
                    ViewBag.negocioId = idNeg;
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
        //-----------------------------------------------------agregaPersonal
        public ActionResult agregaPersonal(string personal, string idNeg)
        {
            string ruta = "/Negocio/personal";
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
                    personalModel.agregarPersonalNegocio(personal, idNeg);
                    return RedirectToAction("/");
                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }

            }
        }

        public ActionResult eliminaPersonal(string ident, string identNeg)
        {
            string ruta = "/Negocio/personal";
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
                    personalModel.eliminaPersonalNegocio(ident, identNeg);
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