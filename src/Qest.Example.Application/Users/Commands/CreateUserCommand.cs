using System;
using MediatR;

namespace Qest.Example.Users.Commands
{
  public sealed class CreateUserCommand: IRequest<Guid?>
  {
    public CreateUserCommand(UserCreationDto model)
    {
      Model = model;
    }

    public UserCreationDto Model { get; }
  }
}
