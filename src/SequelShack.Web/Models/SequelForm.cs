#region usings

using System.ComponentModel.DataAnnotations;

#endregion

namespace SequelShack.Web.Models
{
  public class SequelForm
  {
    [Required]
    public string MovieId { get; set; }

    [Required(ErrorMessage = "Don't forget a title!")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Please describe what happens next.")]
    public string Content { get; set; }
  }
}