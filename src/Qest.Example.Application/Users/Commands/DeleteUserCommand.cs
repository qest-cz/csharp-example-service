using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Qest.Example.Users.Commands
{
  public sealed class DeleteUserCommand: IRequest<bool>
  {
    public DeleteUserCommand(Guid userId)
    {
      UserId = userId;
    }

    public Guid UserId { get; }
  }
}
