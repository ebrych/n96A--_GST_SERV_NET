using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionNegocio_WebApp.Models;
using Beans;

namespace GestionNegocio_WebApp.Controllers
{
    public class UsuariosController : Controller
    {

        //-----------------------------------------------------Modelo
        UsuarioModel model = new UsuarioModel();
        ValidacionModel validation = new ValidacionModel();
        RoleModel dataRole = new RoleModel();


        //-----------------------------------------------------Lista
        public ActionResult Index()
        {
            string ruta = "/Usuario";
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
                        List<Usuario> listaUsers = new List<Usuario>();
                        listaUsers = model.litarUsuarios();
                        ViewBag.listaUsuarios = listaUsers;
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


        //-----------------------------------------------------buscar
        public ActionResult actualizar(string ident)
        {
            string ruta = "/Usuario/actualizar";
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
                        Usuario user = new Usuario();
                        roles = dataRole.listarRoles();
                        user = model.buscarUsuario(ident);
                        ViewBag.misRoles = roles;
                        ViewBag.user = user;
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

        //-----------------------------------------------------actualizar
        [HttpPost]
        public ActionResult actualizarUser(string idt, string nombre, string mail, string role,string estado)
        {
            string ruta = "/Usuario/actualizar";
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
                        Usuario user = new Usuario();
                        Role rl = new Role();
                        Estado es = new Estado();
                        user.idUsuario = Int32.Parse(idt);
                        user.nombres = nombre;
                        user.mail = mail;
                        rl.idRole = Int32.Parse(role);
                        es.idEstado = Int32.Parse(estado);
                        user.role = rl;
                        model.actualizarDatoUsuario(user);
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