#region usings

using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using SequelShack.Domain.Entities;

#endregion

namespace SequelShack.Domain.Queries.Movies
{
  public class MoviesWithTitleLike : IQuery<IEnumerable<Movie>>
  {
    private readonly string _query;

    public MoviesWithTitleLike(string query)
    {
      _query = query;
    }

    public IEnumerable<Movie> Execute(ISession session)
    {
      var movies = session.QueryOver<Movie>()
                          .WhereRestrictionOn(m => m.Title).IsLike(_query, MatchMode.Anywhere)
                          .List();
      return movies;
    }
  }
}