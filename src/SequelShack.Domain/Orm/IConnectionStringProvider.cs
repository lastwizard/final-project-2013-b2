namespace SequelShack.Domain.Orm
{
  public interface IConnectionStringProvider
  {
    string ConnectionString { get; }
  }
}