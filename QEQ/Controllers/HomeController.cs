using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QEQ.Models;

namespace QEQ.Controllers
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
        [HttpPost]
        public ActionResult VerificarPin(string pin, Usuarios x, string Accion)
        {
            if (pin == "1234")
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
        [HttpPost]
        public ActionResult ValidarDatos(Usuarios x, string Accion)
        {
            ViewBag.CrearoEditar = Accion;
            if (ModelState.IsValid)
            {
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
            else
            {
                return View("EditarRegistrar");
            }
        }


        public ActionResult LoginUs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUs2(string nombre, string pass)
        {

            if (BD.LoginUs(nombre, pass) == true)
            {
                ViewBag.Usuario = BD.TraerUs(nombre);
                if (ViewBag.Usuario.Administrador == true)
                {
                    //va session
                    Session["EsAdmin"] = true;
                    Session["NombreUsuario"] = nombre;
                    return RedirectToAction("HomeBackOffice");
                }
                else
                {
                    Session["EsAdmin"] = null;
                    Session["NombreUsuario"] = nombre;
                    return View("Index");
                }
            }
            else
            {
                ViewBag.UsIncorrecto = "Usuario incorrecto.";
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
            if (Session["EsAdmin"] != null)
            {
                List<Personajes> ListaPersonajes = BD.ListarPersonajes();
                ViewBag.LP = ListaPersonajes;
                return View();
            }
            else
            {
                return View("LoginUs");
            }
        }

        public ActionResult Logout()
        {
            Session["EsAdmin"] = null;
            Session["NombreUsuario"] = null;
            return View("Index");
        }

        public ActionResult VerCategorias()
        {
            ViewBag.ListCat = BD.ListarCategorias();
            return View("VerCategorias");
        }
        public ActionResult EdicionCategoria(string Accion, int ID = 0)
        {
            if (Session["EsAdmin"] != null)
            {
                if (ModelState.IsValid)
                {
                    if (Accion != "Modificar" && Accion != "Ver" && Accion != "Eliminar" && Accion != "Insertar")
                    {
                        ViewBag.Mensaje = "Acción no válida";
                        ViewBag.ViewAnterior = "VerCategorias";
                        ViewBag.ControllerAnterior = "Home";
                        return View("Error");
                    }
                    else
                    {
                        if (Accion != "Insertar")
                        {

                            Categorias x = BD.TraerCategoria(ID);
                            ViewBag.Accion = Accion;
                            return View("EdicionCategoria", x);
                        }
                        else
                        {
                            ViewBag.Accion = Accion;
                            return View("EdicionCategoria");
                        }
                    }

               }
                else
                {
                  ViewBag.Accion = Accion;
                  return View("EdicionCategoria");
                }
            }
            else
            { 
              return View("LoginUs");
            }
        }
        public ActionResult HechoCategorias(string Accion, Categorias x)
        {
            if (Session["EsAdmin"] != null)
            {

                if (ModelState.IsValid)
                {
                    switch (Accion)
                    {
                        case "Modificar":
                            BD.ModificarCategoria(x);
                            return View("HomeBackOffice");
                       
                        case "Insertar":
                            BD.InsertarCategoria(x);
                            return View("HomeBackOffice");
                  
                    }
                }

                else
                {
                    if (Accion == "Eliminar")
                    {

                        BD.EliminarCategoria(x.IDCategoria);
                        return View("HomeBackOffice");
                    }
                    else if (Accion == "Ver")
                    {
                        return View("HomeBackOffice");
                    }
                    else
                    {
                        ViewBag.Accion = Accion;
                        return View("EdicionCategoria");
                    }

                }

            }
            else
            {
                return View("LoginUs");
            }
            return View("Error");
        }


        public ActionResult VerUsuarios()
        {
            if (Session["EsAdmin"] != null)
            {
                ViewBag.LU = BD.ListarUsuarios();
                return View();
            }
            else{
                return View("LoginUs");
            }
        }

        
        public ActionResult EdicionUsuario(string Accion, string NombUsu)
        {
           if (Session["EsAdmin"] != null)
            {
                if (Accion != "Modificar" && Accion != "Ver")
                {
                    ViewBag.Mensaje = "Acción no válida";
                    ViewBag.ViewAnterior = "VerUsuarios";
                    ViewBag.ControllerAnterior = "Home";
                    return View("Error");
                }
                else
                {
                    Usuarios x = BD.TraerUs(NombUsu);
                    ViewBag.Accion = Accion;

                    return View("EdicionUsuario", x);
                }
            }
            else
            {
                return View("LoginUs");
            }
        }
        [HttpPost]
        public ActionResult HechoUS(string Accion, Usuarios x)
        {
            if (Accion == "Modificar")
            {
                if (ModelState.IsValid)
                {
                    BD.ModificarUsuario(x);
                    return View ("HomeBackOffice");
                }
                else
                {
                    ViewBag.Accion = Accion;
                    return View("EdicionUsuario");
                }
                   
            }
            else
            {
                return View("Error");
            }
        }

        public ActionResult VerPreguntas()
        {
            if (Session["EsAdmin"] != null)
            {
                ViewBag.ListPreguntas = BD.ListarPreguntas();
                return View();
            }
            else
            {
                return View("LoginUs");
            }
        }

        public ActionResult EdicionPregunta(string Accion, int IDPreg = 0)
       {
            if (Session["EsAdmin"] != null)
            {
                if (Accion != "Modificar" && Accion != "Ver" && Accion != "Eliminar" && Accion != "Insertar")
                {
                    ViewBag.Mensaje = "Acción no válida";
                    ViewBag.ViewAnterior = "VerPreguntas";
                    ViewBag.ControllerAnterior = "Home";
                    return View("Error");
                }
                else
                {
                    if (Accion != "Insertar")
                    {

                        Preguntas x = BD.TraerPregunta(IDPreg);
                        ViewBag.Accion = Accion;
                        return View("EdicionPregunta", x);
                    }
                    else
                    {
                        ViewBag.Accion = Accion;

                        return View("EdicionPregunta");
                    }
                   
                   
                }
            }
            else
            {
                return View("LoginUs");
            }
        }
      
        public ActionResult HechoPreguntas(string Accion, Preguntas x)
        {
            if (Session["EsAdmin"] != null)
            {
                
                if (ModelState.IsValid)
                {
                    switch (Accion)
                    {
                        case "Modificar":
                            BD.ModificarPregunta(x);
                            return View("HomeBackOffice");

                        case "Insertar":
                            BD.InsertarPregunta(x);
                            return View("HomeBackOffice");
                    }
                }

                else
                {
                    if(Accion== "Eliminar")
                    {
                         
                        BD.EliminarPregunta(x.IDPregunta);
                        return View("HomeBackOffice");
                    }
                    else if (Accion == "Ver")
                    {
                        return View("HomeBackOffice");
                    }
                    else
                    {
                        ViewBag.Accion = Accion;
                        return View("EdicionPregunta");
                    }
                   
                }

            }
            else
            {
                return View("LoginUs");
            }
            return View("Error");
        }
        
        public ActionResult VerRanking()
        {
            return View();
        }
        public ActionResult EdicionPersonaje(string Accion, int Id)
        {
           
            if (Session["EsAdmin"] != null)
            {
                ViewBag.Cat = BD.ListarCategorias();
                if (Accion != "Modificar" && Accion != "Ver" && Accion != "Eliminar" && Accion != "Insertar")
                {
                    ViewBag.Mensage = "Acción no válida";
                    ViewBag.ViewAnterior = "VerPersonajes";
                    ViewBag.ControllerAnterior = "Home";
                    return View("Error");
                }
                else
                {
                    if (Accion == "Insertar")
                    {
                        ViewBag.Accion = Accion;
                        return View("EdicionPersonaje");
                    }
                    else
                    {
                        Personajes x = BD.TraerPer(Id);
                        ViewBag.Accion = Accion;
                        return View("EdicionPersonaje", x);
                    }
                }
            }
            else
            {
                return View("LoginUs");
            }
        }

        [HttpPost]
        public ActionResult HechoPersonajes(string accion, Personajes x, string Dire, int Id)
        {
            
            x.IDPersonaje = Id;
            if (Session["EsAdmin"] != null)
            {
                if (!ModelState.IsValid)
                {
                    if (accion == "Ver")
                    {
                        ViewBag.Accion = accion;
                        return View("HomeBackOffice", x);
                    }
                    else
                    {
                        if(accion == "Eliminar")
                        {
                            ViewBag.Accion = accion;
                            int pers = BD.EliminarPersonaje(x);
                            return View("HomeBackOffice", x);
                        }
                        else
                        {
                             ViewBag.Cat = BD.ListarCategorias();
                             x = BD.TraerPer(Id);
                          ViewBag.Accion = accion;
                         return View("EdicionPersonaje",x);
                        }
                     
                    }
                   
                }
                else
                {
                    switch (accion)
                    {
                        
                        case "Insertar":
                            ViewBag.Accion = accion;
                            if (x.DImagen != null)
                            {
                                string NuevaUbicacion = Server.MapPath("~/Content/") + x.DImagen.FileName;
                                x.DImagen.SaveAs(NuevaUbicacion);
                                x.Imagen = x.DImagen.FileName;
                            }
                            else
                            {
                                x.Imagen = Dire;
                            }
                            int pe = BD.InsertarPersonaje(x);
                            return View("HomeBackOffice", x);
                        case "Modificar":
                            ViewBag.Accion = accion;
                            if (x.DImagen != null)
                            {
                                string NuevaUbicacion = Server.MapPath("~/Content/") + x.DImagen.FileName;
                                x.DImagen.SaveAs(NuevaUbicacion);
                                x.Imagen = x.DImagen.FileName;
                            }
                            else
                            {
                                x.Imagen= Dire;
                            }
                          
                            int per = BD.ModificarPersonaje(x);
                            return View("HomeBackOffice", x);
                        default:
                            break;
                    }
                }
                ViewBag.Mensage = "Acción no válida";
                ViewBag.ViewAnterior = "VerPersonajes";
                ViewBag.ControllerAnterior = "Home";
                return View("Error");
            }
            else
            {
                return View("LoginUs");
            }
        }
    }
}
/*
 *  public ActionResult VerPersonajes()
        {
            UserViewModel Usuario = (UserViewModel)Session["Usuario"];
            if (Usuario != null && Usuario.IdCategoria == 1)
            {
                ViewBag.Personajes = BD.TraerPersonajes();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "FrontEnd");
            }
        }
        public ActionResult AccionPersonaje(string Accion, int Id)
        {
            UserViewModel Usuario = (UserViewModel)Session["Usuario"];
            if (Usuario != null && Usuario.IdCategoria == 1)
            {
                ViewBag.Accion = Accion;
                ViewBag.disabled = new { };
                ViewBag.Categorias = BD.TraerCategorías();
                if (Accion == "Eliminar" || Accion == "Ver" || Accion == "Modificar")
                {
                    Personaje x = BD.TraerPersonaje(Id);
                    if (Accion == "Eliminar" || Accion == "Ver")
                    {
                        ViewBag.disabled = new { disabled = "disabled" };
                    }
                    return View("AccionPersonaje", x);
                }
                else if (Accion == "Insertar")
                {
                    return View();
                }
                return View();
            }

            else
            {
                return RedirectToAction("Index", "FrontEnd");
            }
        }
        public ActionResult GrabarPersonaje(Personaje x, string Accion, string Dire, int Id)
        {
            UserViewModel Usuario = (UserViewModel)Session["Usuario"];
            if (Usuario != null && Usuario.IdCategoria == 1)
            {
                ViewBag.Accion = Accion;
                switch (Accion)
                {
                    case "Insertar":
                        if (!ModelState.IsValid)
                        {
                            ViewBag.Categorias = BD.TraerCategorías();
                            return View("AccionPersonaje", x);
                        }
                        else
                        {
                            if (x.DImagen != null)
                            {
                                string NuevaUbicacion = Server.MapPath("~/Content/") + x.DImagen.FileName;
                                x.DImagen.SaveAs(NuevaUbicacion);
                                x.NombreD = x.DImagen.FileName;
                                BD.InsertarPersonaje(x);
                            }
                        }
                        break;
                    case "Modificar":
                        if (!ModelState.IsValid)
                        {
                            return View("AccionPersonaje", x);
                        }
                        else
                        {
                            x.IdPersonaje = Id;
                            if (x.DImagen != null)
                            {
                                string NuevaUbicacion = Server.MapPath("~/Content/") + x.DImagen.FileName;
                                x.DImagen.SaveAs(NuevaUbicacion);
                                x.NombreD = x.DImagen.FileName;
                            }
                            else
                            {
                                x.NombreD = Dire;
                            }
                            BD.ModificarPersonaje(x);
                        }
                        break;
                    case "Eliminar":
                        x.IdPersonaje = Id;
                        BD.EliminarPersonaje(x);
                        break;
                    default:
                        break;
                }
                return RedirectToAction("VerPersonajes");
            }

            else
            {
                return RedirectToAction("Index", "FrontEnd");
            }
*/