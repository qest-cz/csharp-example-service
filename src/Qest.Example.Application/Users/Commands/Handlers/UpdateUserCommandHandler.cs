using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Qest.Example.Repositories;
using Qest.Example.Services;

namespace Qest.Example.Users.Commands.Handlers
{
  internal sealed class UpdateUserCommandHandler: IRequestHandler<UpdateUserCommand, bool>
  {
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;

    public UpdateUserCommandHandler(
      IUserRepository userRepository,
      IEmailService emailService)
    {
      _userRepository = userRepository;
      _emailService = emailService;
    }

    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
      var user = await _userRepository.UpdateAsync(request.UserId, request.Model, cancellationToken);
      if (user is null)
        return false;

      await _emailService.SendMessage(
        user.Email,
        $"User '{user.FirstName} {user.LastName}' updated",
        "Your contact has been added to database.",
        cancellationToken);

      return true;
    }
  }
}
