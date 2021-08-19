using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Qest.Example.Repositories;

namespace Qest.Example.Users.Queries.Handlers
{
  internal class GetUserQueryHandler: IRequestHandler<GetUserQuery, UserDetailDto?>
  {
    private readonly IUserRepository fUserRepository;

    public GetUserQueryHandler(IUserRepository userRepository)
    {
      fUserRepository = userRepository;
    }

    public async Task<UserDetailDto?> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
      return await fUserRepository.GetDetailByIdAsync(request.UserId, cancellationToken);
    }
  }
}
