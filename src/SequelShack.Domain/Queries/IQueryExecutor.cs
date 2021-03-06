namespace SequelShack.Domain.Queries
{
  public interface IQueryExecutor
  {
    TReturn ExecuteQuery<TReturn>(IQuery<TReturn> query);
  }
}