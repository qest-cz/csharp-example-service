using System.ComponentModel.DataAnnotations;

namespace Qest.Example.Service.Users.V1
{
  public class UserPutRequest
  {
    public UserRole Role { get; set; }

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
