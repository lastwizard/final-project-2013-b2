#region usings

using Autofac;
using SequelShack.Domain.Queries;

#endregion

namespace SequelShack.Domain.IoC
{
  public class QueriesModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<QueryExecutor>().As<IQueryExecutor>();
    }
  }
}