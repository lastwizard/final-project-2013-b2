#region usings

using AutoMapper;
using SequelShack.Domain.Entities;
using SequelShack.Web.Mapping.ValueResolvers;
using SequelShack.Web.Models;

#endregion

namespace SequelShack.Web.Mapping.Profiles
{
  public class SequelMappingProfile : Profile
  {
    protected override void Configure()
    {
      CreateMap<Sequel, SequelDisplayModel>()
        .ForMember(x => x.CreatedAt, mce => mce.MapFrom(y => y.CreatedAt.ToString("MM/dd/yyyy")));

      CreateMap<SequelForm, Sequel>()
        .ForMember(x => x.Movie, mce => mce.MapFrom(y => y.MovieId))
        .ForMember(x => x.CreatedBy, mce => mce.ResolveUsing<CurrentUserResolver>());

      CreateMap<Sequel, AccountProfileSequelRowModel>();
    }
  }
}