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

    [HttpGet]
    public ActionResult SignIn(string returnUrl)
    {
      ViewBag.ReturnUrl = returnUrl;
      return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public ActionResult SignIn(SignInForm model)
    {
      if (ModelState.IsValid)
      {
        if (_webSecurity.SignIn(model.Username, model.Password, true))
        {
          return Url.IsLocalUrl(model.ReturnUrl) ? (ActionResult) Redirect(model.ReturnUrl) : RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError("", "The username or password provided is incorrect.");
      }

      return View(model);
    }

    public ActionResult SignOut()
    {
      _webSecurity.SignOut();
      return RedirectToAction("Index", "Home");
    }
  }
}