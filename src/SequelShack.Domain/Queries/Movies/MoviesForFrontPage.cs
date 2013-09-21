#region usings

using System.Collections.Generic;
using NHibernate;
using SequelShack.Domain.Entities;

#endregion

namespace SequelShack.Domain.Queries.Movies
{
  public class MoviesForFrontPage : IQuery<IEnumerable<Movie>>
  {
    public IEnumerable<Movie> Execute(ISession session)
    {
      return session
        .QueryOver<Movie>()
        .Where(m => m.OnFrontPage)
        .OrderBy(m => m.Title).Asc
        .List();
    }
  }
}