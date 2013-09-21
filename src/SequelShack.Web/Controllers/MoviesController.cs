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
  }
}