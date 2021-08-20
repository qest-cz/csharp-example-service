using System;
using System.ComponentModel.DataAnnotations;

namespace Qest.Example.SqlServer.Entities
{
  internal sealed class UserEntity
  {
    [Key]
    public Guid Id { get; set; }

    public UserRole Role { get; set; }

    [MaxLength(ModelConstants.User.EmailMaxLength)]
    public string Email { get; set; } = null!;

    [MaxLength(ModelConstants.User.FirstNameMaxLength)]
    public string FirstName { get; set; } = null!;

    [MaxLength(ModelConstants.User.LastNameMaxLength)]
    public string LastName { get; set; } = null!;

    [MaxLength(ModelConstants.User.NotesMaxLength)]
    public string? Notes { get; set; }
  }
}
