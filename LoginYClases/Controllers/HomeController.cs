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
       /* public ActionResult Index()
        {
            return View();
        }

        public ActionResult About(string Accion)
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult EditarRegistrar(Usuarios x, string Accion)
        {
            ViewBag.CrearoEditar = Accion;
            return View();
        }

        public ActionResult VerificarPin(int pin, Usuarios x)
        {
            if (pin == 1234)
            {
                if (ViewBag.CrearoEditar = "Editar")
                {
                    BD.ModificarUsuario(x);
                    return View("Inicio");
                }
                else
                {
                    string nombre;
                    nombre = BD.BuscarUsuario(x.NombUsuario);
                    if (nombre != x.NombUsuario)
                    {
                        BD.InsertarUsuario(x);
                        return View("Inicio");
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

        public ActionResult ValidarDatos(Usuarios x)
        {
            if (!ModelState.IsValid)
            {
                return View("EditarRegistrar");
            }
            else
            {
                if (x.Administrador == true)
                {
                    return View("ValidarAdmin", x);
                }
                else
                {
                    if (ViewBag.CrearoEditar = "Editar")
                    {
                        BD.ModificarUsuario(x);
                        return View("Inicio");
                    }
                    else
                    {
                        string nombre;
                        nombre = BD.BuscarUsuario(x.NombUsuario);
                        if (nombre != x.NombUsuario)
                        {
                            BD.InsertarUsuario(x);
                            return View("Inicio");
                        }
                        else
                        {
                            ViewBag.Error = "USUARIO EXISTENTE";
                            return View("EditarRegistrar");
                        }

                    }
                }
            }
        }    
        */
        
        public ActionResult LoginUs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUs2(string NombUsuario , string Contraseña)
        {
            ViewBag.Usuario = BD.TraerUs(NombUsuario);//tira error
            ViewBag.RespuestaIn = BD.LoginUs(NombUsuario, Contraseña);
            if (ViewBag.RespuestaIn ==  true)
            {
                if (ViewBag.Usuraio.Administrador == true)
                {
                    return View("HomeBackOffice");
                }
                else
                {
                    return View("IniciarJuego");
                }
            }
            else
            {
                ViewBag.UsIncorrecto = "Usuario incorrecto.";
                return View("LoginUs");
            }
        }

        public ActionResult HomeBackOffice()
        {
            return View();
        }

        public ActionResult VerPersonajes()
        {
            return View();
        }
        public ActionResult Instrucciones(string Accion)
        {
            return View();
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
