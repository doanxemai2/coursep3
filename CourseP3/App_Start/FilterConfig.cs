using System.Web;
using System.Web.Mvc;

namespace CourseP3
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomAuthorizeAttribute());
            filters.Add(new HandleErrorAttribute());
        }
        public class CustomAuthorizeAttribute : AuthorizeAttribute
        {
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                var routeData = httpContext.Request.RequestContext.RouteData;
                var area = routeData.DataTokens["area"];
                var user = httpContext.User;
                //if (area != null && area.ToString() == "User")
                //{
                //    if (!user.Identity.IsAuthenticated)
                //        return false;
                //}
                //else if (area != null && area.ToString() == "Admin")
                //{
                //    if (!user.Identity.IsAuthenticated)
                //        return false;
                //    if (!user.IsInRole("Admin"))
                //        return false;
                //}
                if (area != null && area.ToString() == "Admin")
                {
                    if (!user.Identity.IsAuthenticated)
                        return false;
                    if (!user.IsInRole("Admin"))
                        return false;
                }
                return true;
            }
        }
    }
}
