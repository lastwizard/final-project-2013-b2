#region usings

using System.Web.Mvc;
using AutoMapper;
using NHibernate;
using SequelShack.Web.Infrastructure.Authentication;
using SequelShack.Web.Models;

#endregion

namespace SequelShack.Web.Controllers
{
  [Authorize]
  public class AccountController : BaseController
  {
    private readonly IMappingEngine _mappingEngine;
    private readonly IWebSecurity _webSecurity;

    public AccountController(
      ISession nhSession,
      IMappingEngine mappingEngine,
      IWebSecurity webSecurity)
      : base(nhSession)
    {
      _mappingEngine = mappingEngine;
      _webSecurity = webSecurity;
    }
  }
}