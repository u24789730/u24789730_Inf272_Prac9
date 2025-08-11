using System.Web;
using System.Web.Mvc;

namespace u24789730_Inf272_Prac9
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
