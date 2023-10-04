using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Emprendimiento_Codigo_Limpio_Entrega2.Models
{
    public class IdeaModel
    {
        public List<MiembroModel> Miembros { get; set; } = new List<MiembroModel>();
        public int CodigoIdea { get; set; }

        [Required(ErrorMessage = "El nombre de la idea es obligatorio.")]
        public string NombreIdea { get; set; }

        /* Aquí tendremos el color o colores que impacta la idea */
        public List<string> ImpactosEconomicosIdea { get; set; } = new List<string>();

        [Required(ErrorMessage = "La Inversion es obligatoria.")]
        public float InversionRequeridaIdea { get; set; }

        [Required(ErrorMessage = "Los Objetivos es obligatorio")]
        public float ObjetivosDeIngresosIdea { get; set; }

        /* Aquí tendremos la herramienta o herramientas que tiene la idea */
        public List<int> Herramientas4RevolucionIndustrialIdea { get; set; } = new List<int>();

        private static int ultimoCodigoGenerado = 1;

        public Dictionary<string, string> ColoresEconomia { get; set; }


        public IdeaModel() { }
        public IdeaModel(string nombreIdea, float inversionRequeridaIdea, float objetivosDeIngresosIdea)
        {

            CodigoIdea = GenerarCodigoUnico();
            NombreIdea = nombreIdea;
            InversionRequeridaIdea = inversionRequeridaIdea;
            ObjetivosDeIngresosIdea = objetivosDeIngresosIdea;


        }

        public void RecorrerColores()
        {
            foreach (string color in ImpactosEconomicosIdea)
            {
                System.Diagnostics.Debug.WriteLine(color);
            }

        }

        public void RecorrerHerramientas()
        {
            foreach (int i in Herramientas4RevolucionIndustrialIdea)
            {
                System.Diagnostics.Debug.WriteLine(i);
            }

        }


        public void RecorrerMiembros()
        {
            foreach (MiembroModel model in Miembros)
            {
                System.Diagnostics.Debug.WriteLine(model.Nombre);
            }
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
}