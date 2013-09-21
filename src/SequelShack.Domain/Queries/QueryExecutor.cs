#region usings

using NHibernate;

#endregion

namespace SequelShack.Domain.Queries
{
  public class QueryExecutor : IQueryExecutor
  {
    private readonly ISession _session;

    public QueryExecutor(ISession session)
    {
      _session = session;
    }

    public TReturn ExecuteQuery<TReturn>(IQuery<TReturn> query)
    {
      return query.Execute(_session);
    }
  }
}