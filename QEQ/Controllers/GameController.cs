using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QEQ.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index(string Accion)
        {
            ViewBag.Accion = Accion;
            return View();
        }
        public ActionResult Inicio()
        {
            return View();
        }
    }
}