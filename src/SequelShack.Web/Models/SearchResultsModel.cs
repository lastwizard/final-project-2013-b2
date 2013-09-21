#region usings

using System.Collections.Generic;

#endregion

namespace SequelShack.Web.Models
{
  public class SearchResultsModel
  {
    public string SearchedFor { get; set; }
    public IEnumerable<MovieMediaItemModel> SearchResults { get; set; }
  }
}