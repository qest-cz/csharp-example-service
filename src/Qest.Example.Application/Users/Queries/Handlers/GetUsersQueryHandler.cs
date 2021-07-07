using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Qest.Example.Repositories;

namespace Qest.Example.Users.Queries.Handlers
{
  internal class GetUsersQueryHandler: IRequestHandler<GetUsersQuery, IReadOnlyList<UserPreviewDto>>
  {
    private readonly IUserRepository _userRepository;

    public GetUsersQueryHandler(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    public async Task<IReadOnlyList<UserPreviewDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
      return await _userRepository.GetManyAsync(request.Model, cancellationToken);
    }
  }
}
