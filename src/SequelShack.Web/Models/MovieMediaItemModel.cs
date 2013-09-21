#region usings

using System.Collections.Generic;

#endregion

namespace SequelShack.Web.Models
{
  public class MovieMediaItemModel
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public int? Year { get; set; }
    public string Synopsis { get; set; }
    public string ProfilePosterUrl { get; set; }
    public IEnumerable<string> Cast { get; set; }
  }
}