#region usings

using System.Web.Mvc;
using System.Web.Routing;

#endregion

namespace SequelShack.Web.App_Start
{
  public static class RouteRegistrar
  {
    public static void Register(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      // Add Routes here

      routes.MapRoute(
        name: "Home",
        url: "",
        defaults: new { controller = "Home", action = "Index" });

      routes.MapRoute(
        name: "Default",
        url: "{controller}/{action}/{id}",
        defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional});
    }
  }
}