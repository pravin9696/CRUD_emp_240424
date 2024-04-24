using System.Web;
using System.Web.Mvc;

namespace CRUD_emp_240424
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
