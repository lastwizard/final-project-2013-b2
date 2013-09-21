#region usings

using System.Web.Mvc;
using NHibernate;
using SequelShack.Domain.Queries;
using SequelShack.Domain.Queries.Users;
using SequelShack.Web.Infrastructure.Authentication;
using SequelShack.Web.Models;

#endregion

namespace SequelShack.Web.Controllers
{
  public class RegistrationController : BaseController
  {
    private readonly IQueryExecutor _queryExecutor;
    private readonly IWebSecurity _webSecurity;

    public RegistrationController(
      ISession nhSession,
      IQueryExecutor queryExecutor,
      IWebSecurity webSecurity)
      : base(nhSession)
    {
      _queryExecutor = queryExecutor;
      _webSecurity = webSecurity;
    }

    [HttpGet]
    public ViewResult Join()
    {
      return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public ActionResult Join(JoinForm form)
    {
      if (!string.IsNullOrEmpty(form.Username) && _queryExecutor.ExecuteQuery(new UserWithUsernameAlreadyExists(form.Username)))
        ModelState.AddModelError("Username", "A user with this username already exists.");

      if (!string.IsNullOrEmpty(form.Email) && _queryExecutor.ExecuteQuery(new UserWithEmailAlreadyExists(form.Email)))
        ModelState.AddModelError("Email", "A user with this email address already exists.");

      if (!ModelState.IsValid) return View();

      _webSecurity.CreateUserAndAccount(form.Username, form.Email, form.Password);
      _webSecurity.SignIn(form.Username, form.Password, true);

      return RedirectToAction("Index", "Home");
    }
  }
}