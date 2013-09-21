#region usings

using AutoMapper;
using NHibernate;
using SequelShack.Domain.Entities;

#endregion

namespace SequelShack.Web.Mapping.TypeConverters
{
  public class StringIdToMovieTypeConverter : ITypeConverter<string, Movie>
  {
    private readonly ISession _session;

    public StringIdToMovieTypeConverter(ISession session)
    {
      _session = session;
    }

    public Movie Convert(ResolutionContext context)
    {
      if (context.IsSourceValueNull) return null;

      var movie = _session.Get<Movie>(context.SourceValue);
      return movie;
    }
  }
}