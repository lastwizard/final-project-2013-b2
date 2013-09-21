#region usings

using System.Reflection;
using Autofac;
using SequelShack.Domain.Queries;

#endregion

namespace SequelShack.Web.IoC
{
  public static class AutofacContainerFactory
  {
    public static IContainer BuildContainer()
    {
      var builder = new ContainerBuilder();
      builder.RegisterAssemblyModules(
        typeof (IQueryExecutor).Assembly,
        Assembly.GetExecutingAssembly());

      var container = builder.Build();
      return container;
    }
  }
}