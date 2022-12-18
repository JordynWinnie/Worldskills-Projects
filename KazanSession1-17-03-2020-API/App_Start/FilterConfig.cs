using System.Web;
using System.Web.Mvc;

namespace KazanSession1_17_03_2020_API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
