using System.Web;
using System.Web.Mvc;

namespace Charity_Donation_Mid_Exam_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
