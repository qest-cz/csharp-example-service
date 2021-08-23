using System;

namespace Qest.Example.Service.Users.V1
{
  public class UserDetailResponse
  {
    public Guid Id { get; set; }

    public UserRole Role { get; set; }

    public string Email { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Notes { get; set; }
  }
}
