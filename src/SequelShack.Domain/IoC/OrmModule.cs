#region usings

using Autofac;
using NHibernate;
using SequelShack.Domain.Orm;

#endregion

namespace SequelShack.Domain.IoC
{
  public class OrmModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<SessionFactoryBuilder>();
      builder.Register(cc => cc.Resolve<SessionFactoryBuilder>().BuildISessionFactory()).SingleInstance();
      builder.Register(cc => cc.Resolve<ISessionFactory>().OpenSession()).InstancePerLifetimeScope();
    }
  }
}