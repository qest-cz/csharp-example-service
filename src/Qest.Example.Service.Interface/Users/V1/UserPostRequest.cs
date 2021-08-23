using System.ComponentModel.DataAnnotations;

namespace Qest.Example.Service.Users.V1
{
  public class UserPostRequest
  {
    public UserRole Role { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [StringLength(ModelConstants.User.FirstNameMaxLength, MinimumLength = 1)]
    public string FirstName { get; set; } = null!;

    [Required]
    [StringLength(ModelConstants.User.LastNameMaxLength, MinimumLength = 1)]
    public string LastName { get; set; } = null!;

    [MaxLength(ModelConstants.User.NotesMaxLength)]
    public string? Notes { get; set; }
  }
}
