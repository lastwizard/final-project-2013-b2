#region usings

using SequelShack.Domain.Orm;
using WebMatrix.WebData;

#endregion

namespace SequelShack.Web.App_Start
{
  public static class AuthConfig
  {
    public static void Configure(IConnectionStringProvider connectionStringProvider)
    {
      WebSecurity.InitializeDatabaseConnection(connectionStringProvider.ConnectionString, "System.Data.SqlClient", "User", "Id", "Username", false);
    }
  }
}