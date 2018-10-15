using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionNegocio_WebApp.Models;
using Beans;


namespace GestionNegocio_WebApp.Controllers
{
    public class PermisosController : Controller
    {
        //-----------------------------------------------------Modelo
        RoleModel rolModel = new RoleModel();
        ModuloModel moduloModel = new ModuloModel();
        ValidacionModel validation = new ValidacionModel();

        //-----------------------------------------------------roleslist
        public ActionResult Index()
        {
            string ruta = "/RolesPermisos";
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
                    try
                    {
                        List<Role> roles = new List<Role>();
                        roles = rolModel.listarRoles();
                        ViewBag.roles = roles;
                        ViewBag.nomUser = Session["nombre"];
                        ViewBag.empresa = Session["empresa"];
                        ViewBag.negocio = Session["negocio"];
                        ViewBag.color = Session["color"];
                        ViewBag.colorText = Session["colorText"];
                        return View();
                    }
                    catch (Exception e)
                    {
                        return RedirectToAction("../Home/Error");
                    }
                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }
            }
        }

        public ActionResult nuevoRol()
        {
            string ruta = "/RolesPermisos/agregar";
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
                    try
                    {
                        ViewBag.nomUser = Session["nombre"];
                        ViewBag.empresa = Session["empresa"];
                        ViewBag.negocio = Session["negocio"];
                        ViewBag.color = Session["color"];
                        ViewBag.colorText = Session["colorText"];
                        return View();
                    }
                    catch (Exception e)
                    {
                        return RedirectToAction("../Home/Error");
                    }
                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }
            }
        }

        [HttpPost]
        public ActionResult agregarNuevoRol(string desc)
        {
            string ruta = "/RolesPermisos/agregar";
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
                    try
                    {
                        rolModel.agregarRole(desc);
                        return RedirectToAction("/");
                    }
                    catch (Exception e)
                    {
                        return RedirectToAction("../Home/Error");
                    }
                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }
            }
        }

        public ActionResult Permisos(string ident)
        {
            string ruta = "/RolesPermisos";
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
                    try
                    {
                        List<Modulo> modulosRole = new List<Modulo>();
                        List<Modulo> modulos = new List<Modulo>();
                        modulosRole = moduloModel.listarModulosRole(ident);
                        modulos = moduloModel.listarModulos();
                        ViewBag.modulosRole = modulosRole;
                        ViewBag.modulos = modulos;
                        ViewBag.role = ident;
                        ViewBag.nomUser = Session["nombre"];
                        ViewBag.empresa = Session["empresa"];
                        ViewBag.negocio = Session["negocio"];
                        ViewBag.color = Session["color"];
                        ViewBag.colorText = Session["colorText"];
                        return View();
                    }
                    catch (Exception e)
                    {
                        return RedirectToAction("../Home/Error");
                    }
                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }
            }
        }


        public ActionResult actualizaRol(string ident)
        {
            string ruta = "/RolesPermisos";
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
                    try
                    {
                        Role role = new Role();
                        role = rolModel.buscarRole(ident);
                        ViewBag.role = role;
                        ViewBag.nomUser = Session["nombre"];
                        ViewBag.empresa = Session["empresa"];
                        ViewBag.negocio = Session["negocio"];
                        ViewBag.color = Session["color"];
                        ViewBag.colorText = Session["colorText"];
                        return View();
                    }
                    catch (Exception e)
                    {
                        return RedirectToAction("../Home/Error");
                    }
                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }
            }
        }

        [HttpPost]
        public ActionResult actualizarDatoRol(string idRol, string desc)
        {
            string ruta = "/RolesPermisos/agregar";
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
                    try
                    {
                        Role rl = new Role();
                        rl.idRole = Int32.Parse(idRol);
                        rl.descripcion = desc;
                        rolModel.actualizaDatoRole(rl);
                        return RedirectToAction("/");
                    }
                    catch (Exception e)
                    {
                        return RedirectToAction("../Home/Error");
                    }
                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }
            }
        }



        public ActionResult eliminaRol(string ident)
        {
            string ruta = "/RolesPermisos/eliminar";
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
                    try
                    {
                        rolModel.eliminaRole(ident);
                        return RedirectToAction("/");
                    }
                    catch (Exception e)
                    {
                        return RedirectToAction("../Home/Error");
                    }
                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }
            }
        }



        [HttpPost]
        public ActionResult agregaModulo(string idRol, string idMod)
        {
            string ruta = "/RolesPermisos/agregar";
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
                    try
                    {
                        rolModel.agregarModulorole(idMod, idRol);
                        return RedirectToAction("/");
                    }
                    catch (Exception e)
                    {
                        return RedirectToAction("../Home/Error");
                    }
                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }
            }
        }

        public ActionResult eliminarModulo(string idRol, string idModulo)
        {
            string ruta = "/RolesPermisos/agregar";
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
                    try
                    {
                        rolModel.eliminarModuloRole(idModulo, idRol);
                        return RedirectToAction("/");
                    }
                    catch (Exception e)
                    {
                        return RedirectToAction("../Home/Error");
                    }
                }
                else
                {
                    return RedirectToAction("./"); //salir a login
                }
            }
        }


       





    }
}