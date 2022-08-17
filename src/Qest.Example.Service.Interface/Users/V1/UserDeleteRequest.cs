using System;
using System.ComponentModel.DataAnnotations;

namespace Qest.Example.Service.Users.V1
{
  internal class UserDeleteRequest
  {
    [Required]
    public Guid UserId { get; set; }
  }
}
