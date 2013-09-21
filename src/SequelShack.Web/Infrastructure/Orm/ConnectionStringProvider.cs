#region usings

using System.Configuration;
using SequelShack.Domain.Orm;

#endregion

namespace SequelShack.Web.Infrastructure.Orm
{
  public class ConnectionStringProvider : IConnectionStringProvider
  {
    public string ConnectionString
    {
      get { return ConfigurationManager.ConnectionStrings["Primary"].ConnectionString; }
    }
  }
}