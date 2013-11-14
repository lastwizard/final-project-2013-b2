#region usings

using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;

#endregion

namespace SequelShack.Web.App_Start
{
  public static class AutoMapperConfig
  {
    public static void Configure(IEnumerable<Profile> profiles)
    {
      Mapper.Initialize(cfg =>
        {
          cfg.ConstructServicesUsing(type => DependencyResolver.Current.GetService(type));
          foreach (var profile in profiles)
          {
            cfg.AddProfile(profile);
          }
        });
    }
  }
}