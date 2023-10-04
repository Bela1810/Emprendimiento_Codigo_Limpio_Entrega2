global using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace PruebasUnitariasEmprendimiento.Models
{
    public class MiembroModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Rol { get; set; }
        public string Email { get; set; }

        // Constructor sin parámetros
        public MiembroModel()
        {
        }

        public MiembroModel(int id, string nombre, string apellidos, string rol, string email)
        {
            Id = id;
            Nombre = nombre;
            Apellidos = apellidos;
            Rol = rol;
            Email = email;
        }

    }

    public class IdeaModel
    {
        public List<MiembroModel> Miembros { get; set; } = new List<MiembroModel>();
        public int CodigoIdea { get; private set; }
        public string NombreIdea { get; set; }

        /* Aquí tendremos el color o colores que impacta la idea */
        public List<string> ImpactosEconomicosIdea { get; set; } = new List<string>();

        public float InversionRequeridaIdea { get; set; }
        public float ObjetivosDeIngresosIdea { get; set; }

        /* Aquí tendremos la herramienta o herramientas que tiene la idea */
        public List<int> Herramientas4RevolucionIndustrialIdea { get; set; } = new List<int>();

        private static int ultimoCodigoGenerado = 0;

        public Dictionary<string, string> ColoresEconomia { get; set; }


        public IdeaModel() { }
        public IdeaModel(string nombreIdea, float inversionRequeridaIdea, float objetivosDeIngresosIdea)
        {

            CodigoIdea = GenerarCodigoUnico();
            NombreIdea = nombreIdea;
            InversionRequeridaIdea = inversionRequeridaIdea;
            ObjetivosDeIngresosIdea = objetivosDeIngresosIdea;



        }


        public static int GenerarCodigoUnico()
        {
            return ++ultimoCodigoGenerado;
        }


        public void AgregarHerramientas(int herramientas4RI)
        {
            Herramientas4RevolucionIndustrialIdea.Add(herramientas4RI);

        }

        public List<string> AgregarImpactosEconomicosIdea(string color)
        {
            ImpactosEconomicosIdea.Add(color);
            return ImpactosEconomicosIdea;
        }

        public void AgregarColor(string color)
        {
            ImpactosEconomicosIdea.Add(color);

        }


        public MiembroModel ObtenerMiembroPorId(int idMiembro)
        {
            return Miembros.FirstOrDefault(miembro => miembro.Id == idMiembro);
        }


        public void AgregarMiembro(int id, string nombre, string apellidos, string rol, string email)
        {
            MiembroModel nuevoMiembro = new MiembroModel(id, nombre, apellidos, rol, email);
            Miembros.Add(nuevoMiembro);
        }

        public bool AgregarIntegrante(MiembroModel miembro)
        {
            if (Miembros.Contains(miembro) || miembro == null)
            {
                return false;
            }

            else
            {
                Miembros.Add(miembro);
                return true;
            }

        }

        public void EliminarIntegrante(MiembroModel miembro)
        {
            Miembros.Remove(miembro);
        }

        public void ModificarValorInversion(int nuevoValorInversion)
        {
            InversionRequeridaIdea = nuevoValorInversion;
        }

        public void ModificarValorTotal(int nuevoValorTotal)
        {
            ObjetivosDeIngresosIdea = nuevoValorTotal;

        }





    }

    public class HerramientasModel
    {
        public Dictionary<int, string> Herramientas4RevolucionIndustrial = new Dictionary<int, string>();

        public int HerramientaSeleccionada { get; set; }

        public HerramientasModel()
        {
            Herramientas4RevolucionIndustrial[1] = "Inteligencia Artificial y Aprendizaje Automático";
            Herramientas4RevolucionIndustrial[2] = "Internet de las Cosas (IoT)";
            Herramientas4RevolucionIndustrial[3] = "Blockchain y Criptomonedas";
            Herramientas4RevolucionIndustrial[4] = "Realidad Virtual (VR) y Realidad Aumentada (AR)";
            Herramientas4RevolucionIndustrial[5] = "Impresión 3D (Fabricación Aditiva)";
            Herramientas4RevolucionIndustrial[6] = "Robótica Avanzada";
            Herramientas4RevolucionIndustrial[7] = "Computación Cuántica";
            Herramientas4RevolucionIndustrial[8] = "Biología Sintética y Genómica";
            Herramientas4RevolucionIndustrial[9] = "Nanotecnología";
            Herramientas4RevolucionIndustrial[10] = "Big Data y Análisis Predictivo";
            Herramientas4RevolucionIndustrial[11] = "Automatización Industrial y Robótica Industrial";
            Herramientas4RevolucionIndustrial[12] = "Desarrollo sostenible usando una o mas herramientas de la cuarta revolucion industrial";


        }




    }

    public class ColorModel
    {
        public Dictionary<string, string> ColoresEconomia = new Dictionary<string, string>();

        public string ColorSeleccionado { get; set; }


        public ColorModel()

        {
            ColoresEconomia["Verde"] = "Relacionado con la agricultura, ganadería, pesca y minería.";
            ColoresEconomia["Azul"] = "Incluye industria y manufactura, contribuye al crecimiento económico mediante la producción de bienes.";
            ColoresEconomia["Rojo"] = "Compuesto por servicios como educación, salud y finanzas, es esencial para el bienestar económico y social.";
            ColoresEconomia["Morado"] = "Centrado en la investigación y desarrollo, impulsa la innovación y la tecnología avanzada.";
            ColoresEconomia["Dorado"] = "Involucra al gobierno y organizaciones sin fines de lucro, proporciona servicios públicos y sociales.";
            ColoresEconomia["Amarillo"] = "Representa el sector de la construcción y obras públicas, impulsando el desarrollo de infraestructura.";
            ColoresEconomia["Naranja"] = "Incluye el sector de la energía, contribuyendo a la producción y distribución de energía.";
        }

    }

    public class DesarrolloRegionalModel
    {
        public List<IdeaModel> IdeasDesarrolloRegional { get; set; } = new List<IdeaModel>();

        public Dictionary<string, List<string>> ColoresDepartamentos = new Dictionary<string, List<string>>();



        public DesarrolloRegionalModel()
        {

            ColoresDepartamentos["Verde"] = new List<string> { "Amazonas", "Arauca", "Bolívar", "Boyacá", "Caldas", "Caquetá", "Casanare", "Cauca", "Cesar", "Chocó",
                "Córdoba", "Cundinamarca", "Guainía", "Guaviare", "Huila", "La Guajira", "Magdalena" };
            ColoresDepartamentos["Morado"] = new List<string> { "Antioquia", "Bogotá D.C." };
            ColoresDepartamentos["Naranja"] = new List<string> { "Antioquia", "Arauca", "Casanare" };
            ColoresDepartamentos["Azul"] = new List<string> { "Atlántico", "Bolívar", "Boyacá", "Caldas", "Cauca", "Cesar", "Córdoba", "Cundinamarca" };
            ColoresDepartamentos["Rojo"] = new List<string> { "Atlántico", "Bogotá D.C.", "Bolívar", "Caldas" };
            ColoresDepartamentos["Dorado"] = new List<string> { "Bogotá D.C." };

        }


        public IdeaModel ObtenerIdeaPorCodigo(int codigo)
        {
            if (codigo < 0)
            {
                return null;
            }
            else
            {
                return IdeasDesarrolloRegional.FirstOrDefault(ideaModel => ideaModel.CodigoIdea == codigo);

            }

        }



        public void AgregarIdeaAdesarrollo(IdeaModel idea)
        {
            IdeasDesarrolloRegional.Add(idea);

        }



        public static IdeaModel EncontrarIdeaQueImpactaMasDepartamentos(DesarrolloRegionalModel desarrolloRegionalModel)
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

        public static List<string> DevolverDepartamentosAfectados(DesarrolloRegionalModel desarrolloRegionalModel)
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

        public static IdeaModel EncontrarIdeaConMasIngresos(DesarrolloRegionalModel desarrolloRegionalModel)
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

        public static List<IdeaModel> EncontrarIdeasMasRentables(DesarrolloRegionalModel desarrolloRegionalModel)
        {
            var ideasOrdenadas = desarrolloRegionalModel.IdeasDesarrolloRegional.OrderByDescending(idea => idea.ObjetivosDeIngresosIdea / idea.InversionRequeridaIdea);
            var ideasMasRentables = ideasOrdenadas.Take(3).ToList();
            return ideasMasRentables;
        }

        public static List<IdeaModel> PromedioIdeasMasRentables(DesarrolloRegionalModel desarrolloRegionalModel)
        {
            List<IdeaModel> IdeasRentables = new List<IdeaModel>();
            float PromedioAcumulado = 0;

            foreach (IdeaModel idea in desarrolloRegionalModel.IdeasDesarrolloRegional)
            {
                float acumulado = idea.ObjetivosDeIngresosIdea / idea.InversionRequeridaIdea;
                PromedioAcumulado = PromedioAcumulado + acumulado;

            }

            PromedioAcumulado /= desarrolloRegionalModel.IdeasDesarrolloRegional.Count();


            foreach (IdeaModel idea in desarrolloRegionalModel.IdeasDesarrolloRegional)
            {
                float actual = idea.ObjetivosDeIngresosIdea / idea.InversionRequeridaIdea;

                if (actual > PromedioAcumulado)
                    IdeasRentables.Add(idea);
            }


            return IdeasRentables;
        }



        public static List<IdeaModel> EncontrarIdeasImpactandoMasDeTresDepartamentos(DesarrolloRegionalModel desarrolloRegionalModel)
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
                ingresosTotales += idea.ObjetivosDeIngresosIdea;
            }

            return ingresosTotales;
        }

        public float CalcularInversionTotal(DesarrolloRegionalModel desarrolloRegionalModel)
        {
            float inversionTotal = 0;

            foreach (IdeaModel idea in desarrolloRegionalModel.IdeasDesarrolloRegional)
            {
                inversionTotal += idea.InversionRequeridaIdea;
            }

            return inversionTotal;
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


    }


}    