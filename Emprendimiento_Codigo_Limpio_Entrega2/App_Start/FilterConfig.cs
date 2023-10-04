using System.Web;
using System.Web.Mvc;

namespace Emprendimiento_Codigo_Limpio_Entrega2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
