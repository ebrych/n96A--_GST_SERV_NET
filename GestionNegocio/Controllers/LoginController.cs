using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beans;
using GestionNegocio_WebApp.Models;

namespace GestionNegocio_WebApp.Controllers
{
    public class LoginController : Controller
    {
        //-----------------------------------------------------Modelo
        LoginModel model = new LoginModel();


        public ActionResult Index()
        {
            return View();
        }


        //-----------------------------------------------------IniciaSesion
        [HttpPost]
        public ActionResult IniciarSesion(string token)
        {
            string ruta = "/InicioSesion";
            Usuario usuario = new Usuario();
            usuario = model.InicioSesion(token);
            if (usuario.token == null)
            {
                return RedirectToAction("/Index");
            }
            else
            {
                Configuracion conf = new Configuracion();
                conf = model.cargaConfiguracion();
                Session["empresa"] = conf.nombre.ToString();
                Session["negocio"] = conf.nombreNegocio.ToString();
                Session["color"] = conf.color.ToString();
                Session["colorText"] = conf.colorText.ToString();
                Session["id"] = usuario.idUsuario.ToString();
                Session["nombre"] = usuario.nombres.ToString();
                Session["token"] = usuario.token.ToString();
                Session["role"] = usuario.role.idRole.ToString();
                return RedirectToAction("../Panel");
            }
        }


        //-----------------------------------------------------Registra
        [HttpPost]
        public ActionResult RegistroUsuario(string regNombre, string regToken, string regMail)
        {
            string ruta = "/registrarUsuario";
            try
            {
                Usuario usuario = new Usuario();
                usuario = model.InicioSesion(regToken);
                if (usuario.token == null)
                {
                    Usuario newUser = new Usuario();
                    newUser.nombres = regNombre;
                    newUser.token = regToken;
                    newUser.mail = regMail;
                    model.registrarUsuario(newUser);
                }
                return RedirectToAction("/");
            }
            catch (Exception e)
            {
                return RedirectToAction("../Home/Error");
            }

        }

        //-----------------------------------------------------CerrarSesion
        public ActionResult CerrarSesion()
        {
            Session.Remove("id");
            Session.Remove("nombre");
            Session.Remove("token");
            Session.Remove("role");
            return RedirectToAction("./");
        }





    }
}