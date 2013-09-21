#region usings

using System.Web.Mvc;
using AutoMapper;
using NHibernate;
using SequelShack.Domain.Entities;
using SequelShack.Web.Models;

#endregion

namespace SequelShack.Web.Controllers
{
  public class MoviesController : BaseController
  {
    private readonly IMappingEngine _mappingEngine;

    public MoviesController(
      ISession nhSession,
      IMappingEngine mappingEngine)
      : base(nhSession)
    {
      _mappingEngine = mappingEngine;
    }

    public ActionResult Show(string id)
    {
      var movie = NhSession.Get<Movie>(id);
      var model = _mappingEngine.Map<MovieDisplayModel>(movie);
      return View(model);
    }

    [Authorize, ValidateAntiForgeryToken]
    public ActionResult SaveSequel(SequelForm model)
    {
      if (!ModelState.IsValid)
      {
        var movie = NhSession.Get<Movie>(model.MovieId);
        var movieModel = _mappingEngine.Map<MovieDisplayModel>(movie);
        return View("Show", movieModel);
      }

      // For the second argument to Map pass the following: opts => opts.ConstructServicesUsing(DependencyResolver.Current.GetService)
      var sequel = _mappingEngine.Map<Sequel>(model, opts => opts.ConstructServicesUsing(DependencyResolver.Current.GetService));
      NhSession.Save(sequel);

      return RedirectToAction("Show", new {Id = model.MovieId});
    }
  }
}