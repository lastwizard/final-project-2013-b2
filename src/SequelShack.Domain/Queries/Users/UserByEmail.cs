#region usings

using NHibernate;
using SequelShack.Domain.Entities;

#endregion

namespace SequelShack.Domain.Queries.Users
{
  public class UserByEmail : IQuery<User>
  {
    private readonly string _email;

    public UserByEmail(string email)
    {
      _email = email;
    }

    public User Execute(ISession session)
    {
      return session.QueryOver<User>().Where(u => u.Email == _email).SingleOrDefault();
    }
  }
}