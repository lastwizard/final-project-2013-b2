#region usings

using System.Web.Mvc;
using NHibernate;
using SequelShack.Web.Infrastructure.Authentication;
using SequelShack.Web.Models;

#endregion

namespace SequelShack.Web.Controllers
{
  public class AuthenticationController : BaseController
  {
    private readonly IWebSecurity _webSecurity;

    public AuthenticationController(
      ISession nhSession,
      IWebSecurity webSecurity)
      : base(nhSession)
    {
      _webSecurity = webSecurity;
    }
  }
}