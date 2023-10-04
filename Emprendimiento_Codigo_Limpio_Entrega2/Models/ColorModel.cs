using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emprendimiento_Codigo_Limpio_Entrega2.Models
{
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
}