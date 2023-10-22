using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emprendimiento_Codigo_Limpio_Entrega2.Models
{
    public class DesarrolloRegionalModel
    {
        public List<IdeaModel> IdeasDesarrolloRegional { get; set; } = new List<IdeaModel>();

        public Dictionary<string, List<string>> ColoresDepartamentos = new Dictionary<string, List<string>>();



        public DesarrolloRegionalModel()
        {
            ColoresDepartamentos = new Dictionary<string, List<string>>();

            ColoresDepartamentos["Verde"] = new List<string> { "Amazonas", "Arauca", "Bolívar", "Boyacá", "Caldas", "Caquetá", "Casanare", "Cauca", "Cesar", "Chocó",

                "Córdoba", "Cundinamarca", "Guainía", "Guaviare", "Huila", "La Guajira", "Magdalena" };

            ColoresDepartamentos["Morado"] = new List<string> { "Antioquia", "Bogotá D.C." };

            ColoresDepartamentos["Naranja"] = new List<string> { "Antioquia", "Arauca", "Casanare" };

            ColoresDepartamentos["Azul"] = new List<string> { "Atlántico", "Bolívar", "Boyacá", "Caldas", "Cauca", "Cesar", "Córdoba", "Cundinamarca" };

            ColoresDepartamentos["Rojo"] = new List<string> { "Atlántico", "Bogotá D.C.", "Bolívar", "Caldas" };

            ColoresDepartamentos["Dorado"] = new List<string> { "Bogotá D.C." };

        }


        public IdeaModel ObtenerIdeaPorCodigo(int codigo, DesarrolloRegionalModel desarrolloRegionalModel)
        {
            try
            {
                if (codigo <= 0)
                {
                    throw new ArgumentException("El código debe ser mayor a cero.");
                }
                else
                {
                    return desarrolloRegionalModel.IdeasDesarrolloRegional.FirstOrDefault(ideaModel => ideaModel.CodigoIdea == codigo);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }



        public void AgregarIdeaAdesarrollo(IdeaModel idea)
        {
            IdeasDesarrolloRegional.Add(idea);

        }



        public IdeaModel EncontrarIdeaQueImpactaMasDepartamentos(DesarrolloRegionalModel desarrolloRegionalModel)
        {

            IdeaModel ideaMasImpactante = null;
            int maximoConteoDepartamentos = 0;

            foreach (IdeaModel idea in desarrolloRegionalModel.IdeasDesarrolloRegional)
            {
                int conteoDepartamentos = 0;
                foreach (string color in idea.ImpactosEconomicosIdea)
                {
                    if (desarrolloRegionalModel.ColoresDepartamentos.ContainsKey(color))
                    {
                        conteoDepartamentos += desarrolloRegionalModel.ColoresDepartamentos[color].Count;
                    }
                }

                if (conteoDepartamentos > maximoConteoDepartamentos)
                {
                    ideaMasImpactante = idea;
                    maximoConteoDepartamentos = conteoDepartamentos;
                }
            }

            return ideaMasImpactante;
        }

        public List<string> DevolverDepartamentosAfectados(DesarrolloRegionalModel desarrolloRegionalModel)
        {
            List<string> departamentosAfectados = new List<string>();

            foreach (IdeaModel idea in desarrolloRegionalModel.IdeasDesarrolloRegional)
            {
                foreach (string color in idea.ImpactosEconomicosIdea)
                {
                    if (desarrolloRegionalModel.ColoresDepartamentos.ContainsKey(color))
                    {
                        departamentosAfectados.AddRange(desarrolloRegionalModel.ColoresDepartamentos[color]);
                    }
                }
            }

            return departamentosAfectados.Distinct().ToList();
        }

        public IdeaModel EncontrarIdeaConMasIngresos(DesarrolloRegionalModel desarrolloRegionalModel)
        {
            IdeaModel ideaConMasIngresos = null;

            foreach (IdeaModel idea in desarrolloRegionalModel.IdeasDesarrolloRegional)
            {
                if (ideaConMasIngresos == null || idea.ObjetivosDeIngresosIdea > ideaConMasIngresos.ObjetivosDeIngresosIdea)
                {
                    ideaConMasIngresos = idea;
                }
            }

            return ideaConMasIngresos;
        }

        public List<IdeaModel> EncontrarIdeasMasRentables(DesarrolloRegionalModel desarrolloRegionalModel)
        {
            var ideasOrdenadas = desarrolloRegionalModel.IdeasDesarrolloRegional.OrderByDescending(idea => idea.ObjetivosDeIngresosIdea / idea.InversionRequeridaIdea);
            var ideasMasRentables = ideasOrdenadas.Take(3).ToList();
            return ideasMasRentables;
        }

        public List<IdeaModel> PromedioIdeasMasRentables(DesarrolloRegionalModel desarrolloRegionalModel)
        {
            List<IdeaModel> IdeasRentables = new List<IdeaModel>();
            float PromedioAcumulado = 0;

            foreach (IdeaModel idea in desarrolloRegionalModel.IdeasDesarrolloRegional)
            {
                try
                {
                    // Verificar división por cero o números negativos
                    if (idea.InversionRequeridaIdea <= 0)
                    {
                        throw new ArgumentException($"La inversión requerida de la idea {idea.CodigoIdea} debe ser mayor a cero.");
                    }

                    float acumulado = idea.ObjetivosDeIngresosIdea / idea.InversionRequeridaIdea;
                    PromedioAcumulado = PromedioAcumulado + acumulado;
                }
                catch (ArgumentException ex)
                {              
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            try
            {
                if (desarrolloRegionalModel.IdeasDesarrolloRegional.Count() <= 0)
                {
                    throw new ArgumentException("La lista de ideas no puede estar vacía.");
                }

                PromedioAcumulado /= desarrolloRegionalModel.IdeasDesarrolloRegional.Count();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return IdeasRentables;
            }

            foreach (IdeaModel idea in desarrolloRegionalModel.IdeasDesarrolloRegional)
            {
                float actual = idea.ObjetivosDeIngresosIdea / idea.InversionRequeridaIdea;

                if (actual > PromedioAcumulado)
                    IdeasRentables.Add(idea);
            }

            return IdeasRentables;
        }




        public List<IdeaModel> EncontrarIdeasImpactandoMasDeTresDepartamentos(DesarrolloRegionalModel desarrolloRegionalModel)
        {
            List<IdeaModel> ideasImpactandoMasDeTresDepartamentos = new List<IdeaModel>();

            // Buscar en la lista de ideas para encontrar las ideas que impacten a más de 3 departamentos
            for (int i = 0; i < desarrolloRegionalModel.IdeasDesarrolloRegional.Count; i++)
            {
                IdeaModel idea = desarrolloRegionalModel.IdeasDesarrolloRegional[i];
                int conteoDepartamentos = 0;
                for (int j = 0; j < idea.ImpactosEconomicosIdea.Count; j++)
                {
                    string color = idea.ImpactosEconomicosIdea[j];
                    if (desarrolloRegionalModel.ColoresDepartamentos.ContainsKey(color))
                    {
                        conteoDepartamentos += desarrolloRegionalModel.ColoresDepartamentos[color].Count;
                    }
                }
                if (conteoDepartamentos > 3)
                {
                    ideasImpactandoMasDeTresDepartamentos.Add(idea);
                }
            }

            return ideasImpactandoMasDeTresDepartamentos;
        }




        public float CalcularIngresosTotales(DesarrolloRegionalModel desarrolloRegionalModel)
        {
            float ingresosTotales = 0;

            foreach (IdeaModel idea in desarrolloRegionalModel.IdeasDesarrolloRegional)
            {
                try
                {
                    // Verificar números negativos antes de sumar
                    if (idea.ObjetivosDeIngresosIdea < 0)
                    {
                        throw new ArgumentException($"Los objetivos de ingresos de la idea {idea.CodigoIdea} no pueden ser negativos.");
                    }

                    ingresosTotales += idea.ObjetivosDeIngresosIdea;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return ingresosTotales >= 0 ? ingresosTotales : 0; 
        }


        public float CalcularInversionTotal(DesarrolloRegionalModel desarrolloRegionalModel)
        {
            float inversionTotal = 0;

            foreach (IdeaModel idea in desarrolloRegionalModel.IdeasDesarrolloRegional)
            {
                try
                {
                    if (idea.InversionRequeridaIdea < 0)
                    {
                        throw new ArgumentException($"La inversión requerida de la idea {idea.CodigoIdea} no puede ser negativa.");
                    }

                    inversionTotal += idea.InversionRequeridaIdea;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return inversionTotal >= 0 ? inversionTotal : 0; 
        }


        public IdeaModel EncontrarIdeaConMasHerramientas4RI(DesarrolloRegionalModel desarrolloRegional)
        {
            IdeaModel ideaConMasHerramientas4RI = null;

            foreach (IdeaModel idea in desarrolloRegional.IdeasDesarrolloRegional)
            {
                if (ideaConMasHerramientas4RI == null || idea.Herramientas4RevolucionIndustrialIdea.Count > ideaConMasHerramientas4RI.Herramientas4RevolucionIndustrialIdea.Count)
                {
                    ideaConMasHerramientas4RI = idea;
                }
            }

            return ideaConMasHerramientas4RI;
        }

        public int ContarIdeasConInteligenciaArtificial(DesarrolloRegionalModel desarrolloRegionalModel)
        {
            int conteo = 0;

            foreach (IdeaModel idea in desarrolloRegionalModel.IdeasDesarrolloRegional)
            {
                if (idea.Herramientas4RevolucionIndustrialIdea.Contains(1))
                {
                    conteo++;
                }
            }

            return conteo;
        }



        public List<IdeaModel> ObtenerTodasLasIdeas(DesarrolloRegionalModel desarrolloRegionalModel)
        {
            // Retorna todas las ideas almacenadas en forma de lista
            return desarrolloRegionalModel.IdeasDesarrolloRegional;
        }


        public List<IdeaModel> ContarIdeasConDesarrolloSostenible(DesarrolloRegionalModel desarrolloRegionalModel)
        {
            List<IdeaModel> IdeasConDesarrolloSostenible = new List<IdeaModel>();

            foreach (IdeaModel idea in desarrolloRegionalModel.IdeasDesarrolloRegional)
            {
                if (idea.Herramientas4RevolucionIndustrialIdea.Contains(12))
                {
                    IdeasConDesarrolloSostenible.Add(idea);
                }
            }

            return IdeasConDesarrolloSostenible;
        }

        public IdeaModel EncontrarMayorInversionInfraestructura(DesarrolloRegionalModel desarrolloRegionalModel)
        {
            IdeaModel ideaConMayorInfraestructura = null;

            foreach (IdeaModel idea in desarrolloRegionalModel.IdeasDesarrolloRegional)
            {
                if (ideaConMayorInfraestructura == null || idea.InversionInfraestructura > ideaConMayorInfraestructura.InversionInfraestructura)
                {
                    ideaConMayorInfraestructura = idea;
                }
            }

            return ideaConMayorInfraestructura;
        }

        public List<IdeaModel> EncontrarIdeasQueSuImpactoContenga(DesarrolloRegionalModel desarrolloRegionalModel)
        {
            List<IdeaModel> ideasImpactandoQueSuImpactoContenga = new List<IdeaModel>();

          foreach (IdeaModel ideaModel in desarrolloRegionalModel.IdeasDesarrolloRegional)
            {
                if (ideaModel.ImpactosEconomicosIdea.Contains("Naranja") || (ideaModel.ImpactosEconomicosIdea.Contains("Morado")))
                {
                    ideasImpactandoQueSuImpactoContenga.Add(ideaModel);
                }
            }

            return ideasImpactandoQueSuImpactoContenga;
        }
    }
}