namespace Qest.Example.Users
{
  public record UserUpdateDto
  {
    public UserRole Role { get; init; }

    public string FirstName { get; init; } = null!;

    public string LastName { get; init; } = null!;

    public string? Notes { get; init; }
  }
}
