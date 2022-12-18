using System.Web;
using System.Web.Mvc;

namespace KazanPaper1_7_31_2020_API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
