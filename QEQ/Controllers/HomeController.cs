using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QEQ.Models;

namespace  QEQ.Controllers
{
    public class HomeController : Controller
    {
       public ActionResult Index()
        {
            return View();
        }

        public ActionResult About(string Accion)
        {
           return View();
        }
        public ActionResult EditarRegistrar(string Accion, string NombreUsuario)
        {
            ViewBag.Error = "";
            ViewBag.CrearoEditar = Accion;
            Usuarios x;
            if (NombreUsuario != null)
            {
                x = BD.TraerUs(NombreUsuario);
            }
            else
            {
                x = new Usuarios();
            }

            return View("EditarRegistrar", x);
        }

        public ActionResult VerificarPin(int pin, Usuarios x, string Accion)
        {
            if (pin == 1234)
            {
                if (Accion == "Editar")
                {
                    BD.ModificarUsuario(x);
                    return View("Index");
                }
                else
                {
                    string nombre;
                    nombre = BD.BuscarUsuario(x.NombUsuario);
                    if (nombre != x.NombUsuario)
                    {
                        BD.InsertarUsuario(x);
                        return View("Index");
                    }
                    else
                    {
                        ViewBag.Error = "USUARIO EXISTENTE";
                        return View("EditarRegistrar");
                    }

                }
            }
            else
            {
                return View("EditarRegistrar");
            }
        }

        public ActionResult ValidarDatos(Usuarios x, string Accion)
        {
            ViewBag.CrearoEditar = Accion;
         
                if (x.Administrador == true)
                {
                    return View("ValidarAdmin", x);
                }
                else
                {
                    if (Accion == "Editar")
                    { 
                        BD.ModificarUsuario(x);
                        return View("Index");
                    }
                    else
                    {
                        string nombre;
                        nombre = BD.BuscarUsuario(x.NombUsuario);
                        if (nombre != x.NombUsuario)
                        {
                            BD.InsertarUsuario(x);
                            return View("Index");
                        }
                        else
                        {
                            ViewBag.Error = "USUARIO EXISTENTE";
                            return View("EditarRegistrar");
                        }
                }
            }
        }    
        
        
        public ActionResult LoginUs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUs2(Usuarios x)
        {
           if (ModelState.IsValid)
            {
                if (BD.LoginUs(x.NombUsuario, x.Contraseña) == true)
                {
                    ViewBag.Usuario = BD.TraerUs(x.NombUsuario);
                    if (ViewBag.Usuario.Administrador == true)
                    {
                        //va session
                        Session["EsAdmin"] = true;
                        Session["NombreUsuario"] = x.NombUsuario;
                        return RedirectToAction("HomeBackOffice");
                    }
                    else
                    {
                        Session["EsAdmin"] = null;
                        Session["NombreUsuario"] = x.NombUsuario;
                        return View("Index");
                    }
                }
                else
                {
                    ViewBag.UsIncorrecto = "Usuario incorrecto.";
                    return View("LoginUs");
                }
            }
           else
            {
                return View("LoginUs");
            }
        }

        public ActionResult Instrucciones(string Accion)
        {
            return View();
        }

        public ActionResult HomeBackOffice()
        {
            if (Session["EsAdmin"] != null)
            {
                return View();
            }
            else
            {
                return View("LoginUs");
            }

        }

        public ActionResult VerPersonajes()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session["EsAdmin"] = null;
            Session["NombreUsuario"] = null;
            return View("Index");
        }

        public ActionResult VerCategorias()
        {
            return View();
        }

        public ActionResult VerUsuarios()
        {
            return View();
        }

        public ActionResult VerPreguntas()
        {
            return View();
        }

        public ActionResult VerRanking()
        {
            return View();
        }
    }
}
