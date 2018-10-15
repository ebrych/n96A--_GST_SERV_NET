using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionNegocio_WebApp.Models;
using Beans;


namespace GestionNegocio_WebApp.Controllers
{
    public class ComprasController : Controller
    {
        //-----------------------------------------------------Modelo
        CompraModel model = new CompraModel();
        MaterialModel materialModel = new MaterialModel();
        ValidacionModel validacion = new ValidacionModel();
        ProveedorModel proveedorModel = new ProveedorModel();
        NegocioModel negocioModel = new NegocioModel();
        KardexModel kardexModel = new KardexModel();





        //-----------------------------------------------------Lista
        public ActionResult Index()
        {
            string ruta = "/Compras";
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



        //-----------------------------------------------------nuevo
        public ActionResult nuevaCompra()
        {
            string ruta = "/Compras";
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
                    List<Proveedor> proveedores = new List<Proveedor>();
                    proveedores = proveedorModel.listarProveedores();
                    ViewBag.proveedores = proveedores;
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
        public ActionResult agregarCompra(string prov,string desc)
        {
            string ruta = "/Compras/nuevo";
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
                    model.agregarCompra(prov, idUser, desc);
                    return RedirectToAction("/");

                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }

            }
        }


        //-----------------------------------------------------actualizar
        public ActionResult actualizaCompra(string idt)
        {
            string ruta = "/Compras/actualizar";
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
                    Compra micompra = new Compra();
                    micompra = model.buscarCompra(idt);
                    List<Proveedor> proveedores = new List<Proveedor>();
                    proveedores = proveedorModel.listarProveedores();
                    ViewBag.proveedores = proveedores;
                    ViewBag.miCompra = micompra;
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
        public ActionResult actualizaDato(string id,string prov,string desc)
        {
            string ruta = "/Compras/actualizar";
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
                    model.actualizaDatoCompra(id,prov,idUser,desc);
                    return RedirectToAction("/");

                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }

            }
        }


        public ActionResult DetalleCompra (string idt)
        {
            string ruta = "/Compras/detalle";
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
                    List<DetalleCompra> compras = new List<Beans.DetalleCompra>();
                    compras = model.listarDetalleCompra(idt);
                    List<Material> listaMateriales = new List<Material>();
                    listaMateriales = materialModel.listaMaterial();
                    List<Kardex> kardex = new List<Kardex>();
                    kardex = kardexModel.listaKardex();
                    ViewBag.kardex = kardex;
                    ViewBag.compras = compras;
                    ViewBag.materiales = listaMateriales;
                    ViewBag.idCompra = idt;
                    return View();

                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }

            }
        }

        [HttpPost]
        public ActionResult agregarDetalleCompra(string idCompra,string mate,string cant,string precio)
        {
            string ruta = "/Compras/detalle";
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
                    model.agregarDetalleCompra(idCompra, mate, cant, precio);
                    return RedirectToAction("/");

                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }

            }
        }


        public ActionResult eliminaDetalleCompra(string idDetalleCompra)
        {
            string ruta = "/Compras/detalle";
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
                    model.eliminaDetalleCompra(idDetalleCompra);
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