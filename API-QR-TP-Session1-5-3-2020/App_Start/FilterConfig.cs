using System.Web;
using System.Web.Mvc;

namespace API_QR_TP_Session1_5_3_2020
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
