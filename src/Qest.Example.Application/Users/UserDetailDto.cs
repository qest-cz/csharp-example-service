using System;

namespace Qest.Example.Users
{
  public record UserDetailDto
  {
    public Guid Id { get; init; }

    public UserRole Role { get; init; }

    public string Email { get; set; } = null!;

    public string FirstName { get; init; } = null!;

    public string LastName { get; init; } = null!;

    public string? Notes { get; init; }
  }
}
