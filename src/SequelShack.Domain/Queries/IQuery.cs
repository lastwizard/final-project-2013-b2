#region usings

using NHibernate;

#endregion

namespace SequelShack.Domain.Queries
{
  public interface IQuery<out TReturn>
  {
    TReturn Execute(ISession session);
  }
}