using System.Web;
using System.Web.Mvc;

namespace Nhom15_WebVanPhongPham
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
