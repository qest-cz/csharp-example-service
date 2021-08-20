using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Qest.Example.Repositories;

namespace Qest.Example.Users.Queries.Handlers
{
  internal class GetUsersQueryHandler: IRequestHandler<GetUsersQuery, IReadOnlyCollection<UserPreviewDto>>
  {
    private readonly IUserRepository fUserRepository;

    public GetUsersQueryHandler(IUserRepository userRepository)
    {
      fUserRepository = userRepository;
    }

    public async Task<IReadOnlyCollection<UserPreviewDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
      return await fUserRepository.GetManyAsync(request.Model, cancellationToken);
    }
  }
}
