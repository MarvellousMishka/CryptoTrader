using LAP_PowerMining.Core.Controllers;
using System.Web;
using System.Web.Mvc;

namespace LAP_PowerMining
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new BaseActionFilter());
        }
    }
}
