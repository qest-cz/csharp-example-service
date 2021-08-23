using System.ComponentModel.DataAnnotations;

namespace Qest.Example.Service.Users.V1
{
  public class UserGetManyRequest
  {
    [Range(0, int.MaxValue)]
    public int Offset { get; set; }

    [Range(1, 1000)]
    public int Limit { get; set; }

    public UserRole? Role { get; set; }
  }
}
