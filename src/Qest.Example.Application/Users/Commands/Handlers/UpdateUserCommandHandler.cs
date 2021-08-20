using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Qest.Example.Services;
using Qest.Example.Users.Repositories;

namespace Qest.Example.Users.Commands.Handlers
{
  internal sealed class UpdateUserCommandHandler: IRequestHandler<UpdateUserCommand, bool>
  {
    private readonly IUserRepository fUserRepository;
    private readonly IEmailService fEmailService;

    public UpdateUserCommandHandler(
      IUserRepository userRepository,
      IEmailService emailService)
    {
      fUserRepository = userRepository;
      fEmailService = emailService;
    }

    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
      var user = await fUserRepository.UpdateAsync(request.UserId, request.Model, cancellationToken);
      if (user is null)
        return false;

      await fEmailService.SendMessage(
        user.Email,
        $"User '{user.FirstName} {user.LastName}' updated",
        "Your contact has been added to database.",
        cancellationToken);

      return true;
    }
  }
}
