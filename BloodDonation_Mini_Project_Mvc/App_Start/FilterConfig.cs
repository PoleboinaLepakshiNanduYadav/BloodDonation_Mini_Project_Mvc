using System.Web;
using System.Web.Mvc;

namespace BloodDonation_Mini_Project_Mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
