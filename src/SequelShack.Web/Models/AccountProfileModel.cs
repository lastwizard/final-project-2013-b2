#region usings

using System.Collections.Generic;

#endregion

namespace SequelShack.Web.Models
{
  public class AccountProfileModel
  {
    public string Username { get; set; }
    public string Email { get; set; }
    public IEnumerable<AccountProfileSequelRowModel> Sequels { get; set; }
  }
}