using System.Web.Mvc;

namespace PracticalJavascript.Web.UI.Areas.api
{
    public class apiAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "api";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "api_default",
                "api/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "PracticalJavascript.Web.UI.Areas.api.Controllers" }
            );
        }
    }
}
