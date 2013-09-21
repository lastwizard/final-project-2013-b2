#region usings

using Autofac;
using Autofac.Integration.Mvc;
using SequelShack.Web.Controllers;
using SequelShack.Web.Infrastructure.Filters;

#endregion

namespace SequelShack.Web.IoC
{
  public class MvcModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterModule<AutofacWebTypesModule>();
      RegisterControllers(builder);
      RegisterFilters(builder);
      RegisterGridDataBuilders(builder);
    }

    private void RegisterControllers(ContainerBuilder builder)
    {
      builder.RegisterControllers(ThisAssembly);
    }

    private static void RegisterFilters(ContainerBuilder builder)
    {
      builder.RegisterType<NHibernateTransactionFilter>()
             .AsActionFilterFor<BaseController>(order: 0)
             .InstancePerHttpRequest();

      builder.RegisterFilterProvider();
    }

    private void RegisterGridDataBuilders(ContainerBuilder builder)
    {
      builder.RegisterAssemblyTypes(ThisAssembly)
             .Where(t => t.Name.EndsWith("GridDataBuilder"));
    }
  }
}