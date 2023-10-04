using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emprendimiento_Codigo_Limpio_Entrega2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult EstadisticasIdea()
        {
            return View("~/Views/Estadisticas/Departamental_estadisticas.cshtml");
        }


        public ActionResult Crear_idea()
        { return View("~/Views/CrearIdea/Crear_idea.cshtml"); }



        public ActionResult Detalles_idea()
        {
            return View("~/Views/GestionIdea/Ver_idea.cshtml");
        }


        public ActionResult GestionIdeas()
        {
            return View("~/Views/Home/Gestion_ideas.cshtml");
        }

        public ActionResult Editar_idea()
        {
            return View("~/Views/GestionIdea/Editar_idea.cshtml");
        }
    }
}