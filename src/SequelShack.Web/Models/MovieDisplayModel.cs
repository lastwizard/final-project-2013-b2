#region usings

using System.Collections.Generic;

#endregion

namespace SequelShack.Web.Models
{
  public class MovieDisplayModel
  {
    public string Id { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public string Synopsis { get; set; }
    public string DetailedPosterUrl { get; set; }
    public IEnumerable<string> Cast { get; set; }
    public IEnumerable<SequelDisplayModel> Sequels { get; set; }
  }
}