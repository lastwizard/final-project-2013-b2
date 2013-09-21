#region usings

using System.Web.Mvc;
using NHibernate;
using SequelShack.Web.Infrastructure.Filters;

#endregion

namespace SequelShack.Web.Controllers
{
  public abstract class BaseController : Controller
  {
    protected readonly ISession NhSession;

    protected BaseController(ISession nhSession)
    {
      NhSession = nhSession;
    }

    protected override void OnException(ExceptionContext exceptionContext)
    {
      if (exceptionContext.ExceptionHandled)
      {
        ElmahExceptionFilter.LogException(exceptionContext.Exception);
      }

      if (NhSession.Transaction.IsActive)
      {
        NhSession.Transaction.Rollback();
      }

      base.OnException(exceptionContext);
    }
  }
}