#region usings

using System.ComponentModel.DataAnnotations;

#endregion

namespace SequelShack.Web.Models
{
  public class JoinForm
  {
    [Required, StringLength(25, ErrorMessage = "Usernames cannot be longer than 25 characters.")]
    public string Username { get; set; }

    [Required, StringLength(256), EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required, Compare("Password", ErrorMessage = "The passwords must match."), Display(Name = "Confirm Password")]
    public string ConfirmPassword { get; set; }
  }
}