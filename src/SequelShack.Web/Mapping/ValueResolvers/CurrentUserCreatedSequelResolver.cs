#region usings

using AutoMapper;
using SequelShack.Domain.Entities;
using SequelShack.Web.Infrastructure.Authentication;

#endregion

namespace SequelShack.Web.Mapping.ValueResolvers
{
  public class CurrentUserResolver : ValueResolver<object, User>
  {
    private readonly IWebSecurity _webSecurity;

    public CurrentUserResolver(IWebSecurity webSecurity)
    {
      _webSecurity = webSecurity;
    }

    protected override User ResolveCore(object source)
    {
      return _webSecurity.GetCurrentUser();
    }
  }
}