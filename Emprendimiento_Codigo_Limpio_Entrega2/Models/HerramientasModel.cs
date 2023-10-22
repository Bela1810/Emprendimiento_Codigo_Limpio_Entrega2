using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Emprendimiento_Codigo_Limpio_Entrega2.Models
{
    public class HerramientasModel
    {
        public Dictionary<int, string> Herramientas4RevolucionIndustrial = new Dictionary<int, string>();

        [Required(ErrorMessage = "Es Obligatorio Seleccionar una Herramienta.")]
        [Range(1, 12, ErrorMessage = "Ingrese una herramienta valida")]
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
            Herramientas4RevolucionIndustrial[12] = "Desarrollo sostenible usando una o mas herramientas de la cuarta revolución industrial";
            

        }




    }
}