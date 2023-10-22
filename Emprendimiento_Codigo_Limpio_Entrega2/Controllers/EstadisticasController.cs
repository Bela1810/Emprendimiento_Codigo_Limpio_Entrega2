
using Emprendimiento_Codigo_Limpio_Entrega2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emprendimiento_Codigo_Limpio_Entrega2.Controllers
{
    public class EstadisticasController : Controller
    {

        public DesarrolloRegionalModel desarrolloRegionalModel = new DesarrolloRegionalModel();

        public IdeaModel ideaModel = new IdeaModel();

        // GET: Estadisticas
        public ActionResult Index()
        {
            return View();
        }

        // GET: Estadisticas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Estadisticas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estadisticas/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Estadisticas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Estadisticas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Estadisticas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Estadisticas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Departamental_estadisticas()
        {
            return View();
        }



        public ActionResult Economico_estadisticas()
        {
            return View();
        }

        public ActionResult Tecnologico_estadisticas()
        {
            return View();
        }



        [HttpGet]
        public ActionResult ObtenerIdeaPorCodigo()
        {
            return View("~/Views/Estadisticas/Departamental_estadisticas.cshtml");
        }


        [HttpPost]
        public ActionResult ObtenerIdeaPorCodigo(int codigoInput)
        {
            DesarrolloRegionalModel colombia = Session["colombia"] as DesarrolloRegionalModel;

            var ideaModel = desarrolloRegionalModel.ObtenerIdeaPorCodigo(codigoInput, colombia);

            ViewBag.IdeaCodigo = ideaModel.NombreIdea;

            return View("~/Views/Estadisticas/Departamental_estadisticas.cshtml");
        }

        public ActionResult EncontrarIdeaQueImpactaMasDepartamentos()
        {

            DesarrolloRegionalModel colombia = Session["colombia"] as DesarrolloRegionalModel;

            ideaModel = desarrolloRegionalModel.EncontrarIdeaQueImpactaMasDepartamentos(colombia);

            ViewBag.Resultados = ideaModel.NombreIdea;

            return View("~/Views/Estadisticas/Departamental_estadisticas.cshtml");
        }

        public ActionResult DevolverDepartamentosAfectados()
        {
            DesarrolloRegionalModel colombia = Session["colombia"] as DesarrolloRegionalModel;

            List<string> departamentos = new List<string>();
            departamentos = desarrolloRegionalModel.DevolverDepartamentosAfectados(colombia);

            ViewBag.ResultadosDevolverDepartamentos = departamentos;

            return View("~/Views/Estadisticas/Departamental_estadisticas.cshtml");
        }

        public ActionResult EncontrarIdeaConMasIngresos()
        {
            DesarrolloRegionalModel colombia = Session["colombia"] as DesarrolloRegionalModel;

            ideaModel = desarrolloRegionalModel.EncontrarIdeaConMasIngresos(colombia);

            ViewBag.ResultadosEncontrarIdeaConMasIngresos = ideaModel;

            return View("~/Views/Estadisticas/Economico_estadisticas.cshtml");
        }

        public ActionResult EncontrarIdeasMasRentables()
        {

            DesarrolloRegionalModel colombia = Session["colombia"] as DesarrolloRegionalModel;

            List<IdeaModel> ideas = new List<IdeaModel>();

            ideas = desarrolloRegionalModel.EncontrarIdeasMasRentables(colombia);

            ViewBag.ResultadosEncontrarIdeasMasRentables = ideas;

            return View("~/Views/Estadisticas/Economico_estadisticas.cshtml");
        }

        [HttpPost]
        public ActionResult EncontrarIdeasImpactandoMasDeTresDepartamentos()
        {
            DesarrolloRegionalModel colombia = Session["colombia"] as DesarrolloRegionalModel;

            List<IdeaModel> ideas = new List<IdeaModel>();

            ideas = desarrolloRegionalModel.EncontrarIdeasImpactandoMasDeTresDepartamentos(colombia);

            ViewBag.ResultadosEncontrarIdeasImpactandoMasDeTresDepartamentos = ideas;

            return View("~/Views/Estadisticas/Departamental_estadisticas.cshtml");
        }


        public ActionResult CalcularIngresosTotales()
        {
            DesarrolloRegionalModel colombia = Session["colombia"] as DesarrolloRegionalModel;

            float ingresos_totales = desarrolloRegionalModel.CalcularIngresosTotales(colombia);

            ViewBag.ResultadosCalcularIngresosTotales = ingresos_totales;

            return View("~/Views/Estadisticas/Economico_estadisticas.cshtml");
        }

        public ActionResult CalcularInversionTotal()
        {
            DesarrolloRegionalModel colombia = Session["colombia"] as DesarrolloRegionalModel;

            float inversion_total = desarrolloRegionalModel.CalcularInversionTotal(colombia);

            ViewBag.ResultadosCalcularInversionTotal = inversion_total;

            return View("~/Views/Estadisticas/Economico_estadisticas.cshtml");
        }

        public ActionResult EncontrarIdeaConMasHerramientas4RI()
        {

            DesarrolloRegionalModel colombia = Session["colombia"] as DesarrolloRegionalModel;

            ideaModel = desarrolloRegionalModel.EncontrarIdeaConMasHerramientas4RI(colombia);

            ViewBag.ResultadosEncontrarIdeaConMasHerramientas4RI = ideaModel;

            return View("~/Views/Estadisticas/Tecnologico_estadisticas.cshtml");
        }

        public ActionResult ContarIdeasConInteligenciaArtificial()
        {
            DesarrolloRegionalModel colombia = Session["colombia"] as DesarrolloRegionalModel;

            int ideas_ia = desarrolloRegionalModel.ContarIdeasConInteligenciaArtificial(colombia);

            ViewBag.ResultadosContarIdeasConInteligenciaArtificial = ideas_ia;

            return View("~/Views/Estadisticas/Tecnologico_estadisticas.cshtml");
        }

        public ActionResult ObtenerTodasLasIdeas()
        {
            DesarrolloRegionalModel colombia = Session["colombia"] as DesarrolloRegionalModel;

            List<IdeaModel> ideas = new List<IdeaModel>();

            ideas = desarrolloRegionalModel.ObtenerTodasLasIdeas(colombia);

            ViewBag.ResultadoObtenerTodasLasIdeas = ideas;

            return View();
        }

        public ActionResult ContarIdeasConDesarrolloSostenible()
        {

            DesarrolloRegionalModel colombia = Session["colombia"] as DesarrolloRegionalModel;

            List<IdeaModel> ideas = new List<IdeaModel>();

            ideas = desarrolloRegionalModel.ContarIdeasConDesarrolloSostenible(colombia);

            ViewBag.ResultadoContarIdeasConDesarrolloSostenible = ideas;

            return View("~/Views/Estadisticas/Tecnologico_estadisticas.cshtml");
        }


        public ActionResult EncontrarQueSuImpactoContenga()
        {
            DesarrolloRegionalModel colombia = Session["colombia"] as DesarrolloRegionalModel;
            List<IdeaModel> ideas = new List<IdeaModel>();

            ideas = desarrolloRegionalModel.EncontrarIdeasQueSuImpactoContenga(colombia);

            ViewBag.ResultadosQueSuImpactoContenga = ideas;
            return View("~/Views/Estadisticas/Economico_estadisticas.cshtml");

        }

        public ActionResult EncontrarIdeaQueMayorInfraestructura()
        {
            DesarrolloRegionalModel colombia = Session["colombia"] as DesarrolloRegionalModel;
            

            ideaModel = desarrolloRegionalModel.EncontrarMayorInversionInfraestructura(colombia);

            ViewBag.ResultadosInfraestructura = ideaModel;
            return View("~/Views/Estadisticas/Economico_estadisticas.cshtml");

        }





    }
}
