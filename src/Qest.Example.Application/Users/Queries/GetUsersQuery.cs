﻿using System.Collections.Generic;
using MediatR;

namespace Qest.Example.Users.Queries
{
  public sealed class GetUsersQuery: IRequest<IReadOnlyCollection<UserPreviewDto>>
  {
    public GetUsersQuery(UserQueryDto model)
    {
      Model = model;
    }

    public UserQueryDto Model { get; }
  }
}
