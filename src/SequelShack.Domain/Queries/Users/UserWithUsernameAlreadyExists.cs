#region usings

using System;
using NHibernate;
using SequelShack.Domain.Entities;

#endregion

namespace SequelShack.Domain.Queries.Users
{
  public class UserWithUsernameAlreadyExists : IQuery<bool>
  {
    private readonly int? _id;
    private readonly string _username;

    public UserWithUsernameAlreadyExists(string username, int? id = null)
    {
      _id = id;
      _username = username;
    }

    public Boolean Execute(ISession session)
    {
      var query = session.QueryOver<User>().Where(u => u.Username == _username);
      if (_id != null) query.And(u => u.Id != _id);
      return query.RowCount() > 0;
    }
  }
}