#region usings

using AutoMapper;
using SequelShack.Domain.Entities;
using SequelShack.Web.Models;

#endregion

namespace SequelShack.Web.Mapping.Profiles
{
  public class UserMappingProfile : Profile
  {
    protected override void Configure()
    {
      CreateMap<User, AccountProfileModel>();
    }
  }
}