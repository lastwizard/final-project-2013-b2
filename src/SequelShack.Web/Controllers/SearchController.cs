﻿#region usings

using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using NHibernate;
using SequelShack.Domain.Entities;
using SequelShack.Domain.Queries;
using SequelShack.Domain.Queries.Movies;
using SequelShack.Web.Models;

#endregion

namespace SequelShack.Web.Controllers
{
  public class SearchController : BaseController
  {
    private readonly IMappingEngine _mappingEngine;
    private readonly IQueryExecutor _queryExecutor;

    public SearchController(
      ISession nhSession,
      IMappingEngine mappingEngine,
      IQueryExecutor queryExecutor)
      : base(nhSession)
    {
      _mappingEngine = mappingEngine;
      _queryExecutor = queryExecutor;
    }
  }
}