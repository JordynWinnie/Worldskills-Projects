using System.Web;
using System.Web.Mvc;

namespace Kazan_Paper1_7_24_2020
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
