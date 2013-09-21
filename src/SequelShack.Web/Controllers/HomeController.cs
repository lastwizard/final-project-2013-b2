#region usings

using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using NHibernate;
using SequelShack.Domain.Queries;
using SequelShack.Domain.Queries.Movies;
using SequelShack.Web.Models;

#endregion

namespace SequelShack.Web.Controllers
{
  public class HomeController : BaseController
  {
    private readonly IMappingEngine _mappingEngine;
    private readonly IQueryExecutor _queryExecutor;

    public HomeController(
      ISession nhSession,
      IQueryExecutor queryExecutor,
      IMappingEngine mappingEngine)
      : base(nhSession)
    {
      _queryExecutor = queryExecutor;
      _mappingEngine = mappingEngine;
    }

    public ActionResult Index()
    {
      var movies = _queryExecutor.ExecuteQuery(new MoviesForFrontPage());
      var models = _mappingEngine.Map<IEnumerable<MovieMediaItemModel>>(movies);

      return View(models);
    }
  }
}