#region usings

using NHibernate.Bytecode;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using NHibernate;
using SequelShack.Domain.Entities;

#endregion

namespace SequelShack.Domain.Orm
{
  public class SessionFactoryBuilder
  {
    private readonly IConnectionStringProvider _connectionStringProvider;

    public SessionFactoryBuilder(IConnectionStringProvider connectionStringProvider)
    {
      _connectionStringProvider = connectionStringProvider;
    }

    public ISessionFactory BuildISessionFactory()
    {
      var mapper = new ModelMapper();
      mapper.AddMappings(typeof(Movie).Assembly.GetExportedTypes());
      var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

      var configuration = new Configuration()
        .Proxy(p => p.ProxyFactoryFactory<DefaultProxyFactoryFactory>())
        .DataBaseIntegration(
          di =>
          {
            di.ConnectionString = _connectionStringProvider.ConnectionString;
            di.Dialect<MsSqlAzure2008Dialect>();
          });
      configuration.AddMapping(mapping);

      var sessionFactory = configuration.BuildSessionFactory();
      return sessionFactory;

    }
  }
}