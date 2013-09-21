#region usings

using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using Autofac;
using Autofac.Integration.Mvc;
using SequelShack.Domain.Orm;
using SequelShack.Web.App_Start;
using SequelShack.Web.Infrastructure.Filters;
using SequelShack.Web.IoC;

#endregion

namespace SequelShack.Web
{
  public class MvcApplication : HttpApplication
  {
    protected void Application_Start()
    {
      GlobalFilters.Filters.Add(new ElmahExceptionFilter());

      var container = AutofacContainerFactory.BuildContainer();
      DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

      AreaRegistration.RegisterAllAreas();
      RouteRegistrar.Register(RouteTable.Routes);
      BundleRegistrar.Register(BundleTable.Bundles);

      using (var lifetimeScope = container.BeginLifetimeScope())
      {
        AuthConfig.Configure(lifetimeScope.Resolve<IConnectionStringProvider>());
        AutoMapperConfig.Configure(lifetimeScope.Resolve<IEnumerable<Profile>>());
      }
    }
  }
}