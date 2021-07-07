using System;
using MediatR;

namespace Qest.Example.Users.Queries
{
  public sealed class GetUserQuery: IRequest<UserDetailDto?>
  {
    public GetUserQuery(Guid userId)
    {
      UserId = userId;
    }

    public Guid UserId { get; }
  }
}
