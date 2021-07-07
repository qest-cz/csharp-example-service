namespace Qest.Example.Users
{
  public record UserQueryDto
  {
    public int Offset { get; init; }

    public int Limit { get; init; }

    public UserRole? Role { get; init; }
  }
}
