using Emprendimiento_Codigo_Limpio_Entrega2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emprendimiento_Codigo_Limpio_Entrega2.Controllers
{
    public class VerIdeaController : Controller
    {

        public DesarrolloRegionalModel desarrolloRegionalModel = new DesarrolloRegionalModel();

        public IdeaModel ideaModel = new IdeaModel();


        [HttpGet]
        public ActionResult VerIdea()
        {
            { return View("~/Views/GestionIdea/Ver_idea.cshtml"); }
        }

        [HttpPost]
        public ActionResult VerIdea(int id)
        {


            DesarrolloRegionalModel colombia = Session["colombia"] as DesarrolloRegionalModel;



            var ideaModel = desarrolloRegionalModel.ObtenerIdeaPorCodigo(id, colombia);

            if (ideaModel == null)
            {

                System.Diagnostics.Debug.WriteLine("no llego ninguna idea aqui ...");
                return HttpNotFound();
            }




            return View("~/Views/GestionIdea/Ver_idea.cshtml", ideaModel);

        }


        [HttpPost]
        public ActionResult ImprimirTodasLasIdeas()
        {
            DesarrolloRegionalModel colombia = Session["colombia"] as DesarrolloRegionalModel;


            if (colombia.IdeasDesarrolloRegional == null)
            {
                System.Diagnostics.Debug.WriteLine("no llego ninguna idea aqui ...");
                return HttpNotFound();
            }

            return View("~/Views/GestionIdea/Ver_ideas.cshtml", colombia.IdeasDesarrolloRegional);

        }




        public ActionResult EditarIdea()
        {
            return View("~/Views/GestionIdea/Editar_idea.cshtml");
        }


    }
}
