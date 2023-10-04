using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Emprendimiento_Codigo_Limpio_Entrega2.Models;

namespace Emprendimiento_Codigo_Limpio_Entrega2.Controllers
{
    public class CrearIdeaController : Controller
    {


        // GET: Idea
        public ActionResult Index()
        {
            return View();
        }

        // TODO: Add session
        [HttpGet]
        public ActionResult Crear_idea()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Crear_idea(IdeaModel ideaModel)
        {

            if (!ModelState.IsValid)
            {
                return View("Crear_idea", ideaModel);
            }

            try
            {
                var codigo_ultima_idea = (Session["colombia"] as DesarrolloRegionalModel)?.IdeasDesarrolloRegional.LastOrDefault().CodigoIdea ?? 0;  
                ideaModel.CodigoIdea = codigo_ultima_idea + 1;
                string nombre = ideaModel.NombreIdea;
                float inversion_idea = ideaModel.InversionRequeridaIdea;
                float total_idea = ideaModel.ObjetivosDeIngresosIdea;

                Session["IdeaActual"] = ideaModel;
                

                // Redirigir a otra acción
                return RedirectToAction("Crear_miembro");
            }
            catch (Exception ex)
            {

                return View("Error"); // Vista de error
            }


        }



        [HttpGet]
        public ActionResult Crear_miembro()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Crear_miembro(MiembroModel miembroModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Crear_miembro", miembroModel);
            }
            var idea = Session["IdeaActual"] as IdeaModel;

            if (miembroModel != null && !string.IsNullOrEmpty(miembroModel.Nombre) && !string.IsNullOrEmpty(miembroModel.Apellidos) && !string.IsNullOrEmpty(miembroModel.Rol) && !string.IsNullOrEmpty(miembroModel.Email))
            {
                var miembro = new MiembroModel
                {
                    Id = miembroModel.Id,
                    Nombre = miembroModel.Nombre,
                    Apellidos = miembroModel.Apellidos,
                    Rol = miembroModel.Rol,
                    Email = miembroModel.Email


                };


                // Agregar el miembro
                idea.Miembros.Add(miembro);
            }


            // Guardar datos de sesion para la proxima vista (los parametros sobre cargados tambien se pasan)
            Session["IdeaActual"] = idea;

            // Redirigir a otra acción
            return RedirectToAction("Crear_miembro");
        }


        [HttpGet]
        public ActionResult Crear_color()
        {
            ColorModel colorModel = new ColorModel();
            return View(colorModel);
        }

        [HttpPost]
        public ActionResult Crear_color(ColorModel colorModel)
        {
            // Recibir datos de sesion de la vista "agregar miembro", (los parametros sobre cargados fueron se pasados)
            var idea = Session["IdeaActual"] as IdeaModel;

            string colorSeleccionado = colorModel.ColorSeleccionado;


            if (!string.IsNullOrEmpty(colorSeleccionado))
            {
                idea.ImpactosEconomicosIdea.Add(colorSeleccionado);
            }




            // Guardar datos de sesion para la proxima vista (los parametros sobre cargados tambien se pasan)
            Session["IdeaActual"] = idea;

            return RedirectToAction("Crear_color");
        }



        [HttpGet]
        public ActionResult Crear_herramienta()
        {
            HerramientasModel herramientasModel = new HerramientasModel();
            return View(herramientasModel);
        }

        [HttpPost]
        public ActionResult Crear_herramienta(HerramientasModel herramientasModel)

        {
            if (!ModelState.IsValid)
            {
                return View("Crear_herramienta", herramientasModel);
            }

            // Recibir datos de sesion de la vista "crear color", (los parametros sobre cargados fueron se pasados)
            var idea = Session["IdeaActual"] as IdeaModel;

            int HerramientaSeleccionada = herramientasModel.HerramientaSeleccionada;


            if (HerramientaSeleccionada != 0)
            {
                idea.Herramientas4RevolucionIndustrialIdea.Add(HerramientaSeleccionada);
            }


            // Guardar datos de sesion para la proxima vista (los parametros sobre cargados tambien se pasan)
            Session["IdeaActual"] = idea;

            return RedirectToAction("Crear_herramienta");
        }


        public ActionResult Finalizar()
        {
            DesarrolloRegionalModel colombia = (Session["colombia"] as DesarrolloRegionalModel) ?? new DesarrolloRegionalModel();
            // Recuperar la idea de la sesión
            var idea = Session["IdeaActual"] as IdeaModel;

            System.Diagnostics.Debug.WriteLine(idea.NombreIdea);
            System.Diagnostics.Debug.WriteLine(idea.CodigoIdea);


            idea.RecorrerColores();
            idea.RecorrerHerramientas();
            idea.RecorrerMiembros();



            // Agregar la idea a la lista
            colombia.AgregarIdeaAdesarrollo(idea);




            // Limpiar la sesión
            Session["IdeaActual"] = null;

            Session["colombia"] = colombia;

            return RedirectToAction("Index", "Home");

        }
    }
}
