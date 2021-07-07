using System;

namespace Qest.Example.Users
{
  public record UserPreviewDto
  {
    public Guid Id { get; init; }

    public UserRole Role { get; init; }

    public string FirstName { get; init; } = null!;

    public string LastName { get; init; } = null!;
  }
}
