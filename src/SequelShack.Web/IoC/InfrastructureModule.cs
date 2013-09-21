#region usings

using Autofac;
using SequelShack.Domain.Orm;
using SequelShack.Web.Infrastructure.Authentication;
using SequelShack.Web.Infrastructure.Orm;

#endregion

namespace SequelShack.Web.IoC
{
  public class InfrastructureModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<WebSecurityWrapper>().As<IWebSecurity>();
      builder.RegisterType<ConnectionStringProvider>().As<IConnectionStringProvider>();
    }
  }
}