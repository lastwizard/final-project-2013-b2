#region usings

using System.ComponentModel.DataAnnotations;

#endregion

namespace SequelShack.Web.Models
{
  public class SignInForm
  {
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

    public bool RememberMe { get; set; }

    public string ReturnUrl { get; set; }
  }
}