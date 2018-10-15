using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionNegocio_WebApp.Models;
using Beans;

namespace GestionNegocio_WebApp.Controllers
{
    public class NotasController : Controller
    {

        //-----------------------------------------------------Modelo
        NotaModel model = new NotaModel();
        ValidacionModel validation = new ValidacionModel();
        TipoModel tipoModel = new TipoModel();
        AlmacenModel almaceModel = new AlmacenModel();
        MaterialModel materialModel = new MaterialModel();
        NegocioModel negocioModel = new NegocioModel();
        CompraModel compraModel = new CompraModel();
        OrdenPedidoModel ordenPedidoModel = new OrdenPedidoModel();

        //-----------------------------------------------------Lista
        public ActionResult Index()
        {
            string ruta = "/Notas";
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
                    List<Nota> listaNotas = new List<Nota>();
                    listaNotas = model.listarNotas();
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

        public ActionResult nuevaNota()
        {
            string ruta = "/Notas/nuevo";
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
                    List<Tipo> tipoNota = new List<Tipo>();
                    List<Almacen> almacen = new List<Almacen>();

                    List<Nota> salidas = new List<Nota>();
                    List<Negocio> negocios = new List<Negocio>();
                    List<Compra> compras = new List<Compra>();

                    salidas = model.listaNotaSalidaSelect();
                    negocios = negocioModel.listaNegocioSelect();
                    compras = compraModel.listarComprasSelect();
                
                    almacen = almaceModel.listarAlamacenes();
                    tipoNota = tipoModel.listarTipoNota();

                    ViewBag.almacen = almacen;
                    ViewBag.tipoNota = tipoNota;
                    ViewBag.salidas = salidas;
                    ViewBag.negocios = negocios;
                    ViewBag.compras = compras;

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
        public ActionResult agregarNota(string tipo, string almc, string desc, string comp,string neg,string sal)
        {
            string ruta = "/Notas/nuevo";
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
                    string numRef = "0";
                    if(comp.Equals("0") && neg.Equals("0") && sal.Equals("0"))
                    {
                        return RedirectToAction("./");
                    }else
                    {
                        if (neg.Equals("0") && sal.Equals("0")) {
                            numRef = comp;
                        }else if (comp.Equals("0") && sal.Equals("0"))
                        {
                            numRef = neg;
                        }else if(comp.Equals("0") && neg.Equals("0"))
                        {
                            numRef = sal;
                        }
                        Nota nta = new Nota();
                        Almacen alm = new Almacen();
                        Tipo tpo = new Tipo();
                        Referencia rf = new Referencia();
                        tpo.idTipo = Int32.Parse(tipo);
                        nta.tipo = tpo;
                        alm.idAlmacen = Int32.Parse(almc);
                        nta.almacen = alm;
                        nta.descripcion = desc;
                        rf.idReferencia = Int32.Parse(numRef);
                        nta.referencia = rf;
                        string userSol = Session["id"].ToString();
                        model.agregarNota(nta, userSol);
                        return RedirectToAction("/");
                    }
                    

                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }

            }
        }

        public ActionResult ActualizarNota(string idt)
        {
            string ruta = "/Notas/actualizar";
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
                    List<Nota> salidas = new List<Nota>();
                    List<Negocio> negocios = new List<Negocio>();
                    List<Compra> compras = new List<Compra>();

                    salidas = model.listaNotaSalidaSelect();
                    negocios = negocioModel.listaNegocioSelect();
                    compras = compraModel.listarComprasSelect();

                    List<Nota> notas = new List<Nota>();
                    List<Tipo> tipoNota = new List<Tipo>();
                    List<Almacen> almacen = new List<Almacen>();
                    Nota nota = new Nota();
                    nota = model.buscarNotas(idt);
                    almacen = almaceModel.listarAlamacenes();
                    tipoNota = tipoModel.listarTipoNota();
                    notas = model.listarNotaSalida();
                    ViewBag.notas = notas;
                    ViewBag.nota = nota;
                    ViewBag.almacen = almacen;
                    ViewBag.tipoNota = tipoNota;
                    ViewBag.salidas = salidas;
                    ViewBag.negocios = negocios;
                    ViewBag.compras = compras;
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
        public ActionResult actualizaDatoNota(string idNota, string tipo, string alm, string desc, string num)
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
                int permiso = validation.validarPermisos(tk, ruta);
                if (permiso != 0)
                {
                    string userSol = Session["id"].ToString();
                    Nota nta = new Nota();
                    Tipo tpo = new Tipo();
                    Almacen almc = new Almacen();
                    Usuario us = new Usuario();
                    Referencia rf = new Referencia();

                    nta.idNota = Int64.Parse(idNota);
                    tpo.idTipo = Int32.Parse(tipo);
                    nta.tipo = tpo;
                    almc.idAlmacen = Int32.Parse(alm);
                    nta.almacen = almc;
                    nta.descripcion = desc;
                    rf.idReferencia = Int64.Parse(num);
                    nta.referencia = rf;
                    us.idUsuario = Int32.Parse(userSol);
                    nta.userSolicita = us;

                    model.actualizaNota(nta);
                    return RedirectToAction("/");
                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }

            }
        }



        public ActionResult DetalleNota(string idt,string refr)
        {
            string ruta = "/Notas/detalle";
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
                    List<DetalleNota> listaDetalle = new List<DetalleNota>();
                    List<Material> listaMaterial = new List<Material>();
                    listaMaterial = materialModel.listaMaterial();
                    listaDetalle = model.listarDetalleNota(idt);
                    //datos lista
                    List<DetalleCompra> detalleCompra = new List<DetalleCompra>();
                    List<DetalleOrdenPedido> detalleOrdenPedido = new List<DetalleOrdenPedido>();
                    detalleCompra = null;
                    detalleOrdenPedido = null;
                    int tipo = model.buscaTipoNota(idt);
                    if (tipo == 1)
                    {
                        detalleCompra = compraModel.listarDetalleCompra(refr);
                    }
                    else if (tipo == 2)
                    {
                        detalleOrdenPedido = ordenPedidoModel.listarDetalleOrdenPedido(refr);
                    }
                    //datos lista
                    ViewBag.detalleCompra = detalleCompra;
                    ViewBag.detalleOrdenPedido = detalleOrdenPedido;
                    ViewBag.idTipo = tipo;
                    ViewBag.listaMaterial = listaMaterial;
                    ViewBag.listaDetalle = listaDetalle;
                    ViewBag.nota = idt;
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
        public ActionResult agregaDetalle(string idNota, string mat, string cant)
        {
            string ruta = "/Notas/detalle";
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
                    DetalleNota dtll = new DetalleNota();
                    Material mt = new Material();
                    Nota nt = new Nota();

                    mt.idMaterial = Int32.Parse(mat);
                    dtll.material = mt;
                    nt.idNota = Int64.Parse(idNota);
                    dtll.nota = nt;
                    dtll.Cantidad = Int32.Parse(cant);
                    model.agregarDetalleNota(dtll);
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
            string ruta = "/Notas/detalle";
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
                    model.eliminarDetalleNota(idDetalle);
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