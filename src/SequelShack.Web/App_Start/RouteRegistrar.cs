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
        name: "Sign In",
        url: "signin",
        defaults: new {controller = "Authentication", action = "SignIn"});

      routes.MapRoute(
        name: "Sign Out",
        url: "signout",
        defaults: new {controller = "Authentication", action = "SignOut"});

      routes.MapRoute(
        name: "Join",
        url: "join",
        defaults: new {controller = "Registration", action = "Join"});

      routes.MapRoute(
        name: "Profile",
        url: "profile",
        defaults: new {controller = "Account", action = "Profile"});

      routes.MapRoute(
        name: "View Movie",
        url: "movies/{id}",
        defaults: new {controller = "Movies", action = "Show"},
        constraints: new {id = @"\d+"});

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