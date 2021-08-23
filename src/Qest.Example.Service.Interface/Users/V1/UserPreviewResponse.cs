using System;

namespace Qest.Example.Service.Users.V1
{
  public class UserPreviewResponse
  {
    public Guid Id { get; set; }

    public UserRole Role { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
  }
}
