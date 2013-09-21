#region usings

using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SequelShack.Domain.Entities;
using SequelShack.Web.Mapping.TypeConverters;
using SequelShack.Web.Models;

#endregion

namespace SequelShack.Web.Mapping.Profiles
{
  public class MovieMappingProfile : Profile
  {
    protected override void Configure()
    {
      CreateMap<Movie, MovieDisplayModel>()
        .ForMember(mm => mm.Cast, mce => mce.MapFrom(m => ConvertCharactersIntoCastList(m.Characters)));

      CreateMap<Movie, MovieMediaItemModel>()
        .ForMember(mm => mm.Cast, mce => mce.MapFrom(m => ConvertCharactersIntoCastList(m.Characters)));

      CreateMap<string, Movie>().ConvertUsing<StringIdToMovieTypeConverter>();
    }

    private static IEnumerable<string> ConvertCharactersIntoCastList(IEnumerable<Character> characters)
    {
      var castList =
        from c in characters
        group c by c.Actor
        into charactersByActor
        select string.Format(
          "{0}{1}{2}",
          charactersByActor.Key.Name,
          charactersByActor.All(c => string.IsNullOrEmpty(c.Name)) ? string.Empty : " - ",
          string.Join(", ", charactersByActor.Select(c => c.Name)));

      return castList.ToArray();
    }
  }
}