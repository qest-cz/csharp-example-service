using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Qest.Example.Repositories;

namespace Qest.Example.Users.Queries.Handlers
{
  internal class GetUserQueryHandler: IRequestHandler<GetUserQuery, UserDetailDto?>
  {
    private readonly IUserRepository _userRepository;

    public GetUserQueryHandler(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    public async Task<UserDetailDto?> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
      return await _userRepository.GetDetailByIdAsync(request.UserId, cancellationToken);
    }
  }
}
