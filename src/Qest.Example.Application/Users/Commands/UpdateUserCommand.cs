using System;
using MediatR;

namespace Qest.Example.Users.Commands
{
  public sealed class UpdateUserCommand: IRequest<bool>
  {
    public UpdateUserCommand(Guid userId, UserUpdateDto model)
    {
      UserId = userId;
      Model = model;
    }

    public Guid UserId { get; }

    public UserUpdateDto Model { get; }
  }
}
