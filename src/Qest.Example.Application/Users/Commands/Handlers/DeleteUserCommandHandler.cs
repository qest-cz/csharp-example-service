using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Qest.Example.Services;
using Qest.Example.Users.Repositories;

namespace Qest.Example.Users.Commands.Handlers
{
  internal sealed class DeleteUserCommandHandler: IRequestHandler<DeleteUserCommand, bool>
  {
    private readonly IUserRepository fUserRepository;
    private readonly IEmailService fEmailService;

    public DeleteUserCommandHandler(
      IUserRepository userRepository,
      IEmailService emailService)
    {
      fUserRepository = userRepository;
      fEmailService = emailService;
    }

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
      var success = await fUserRepository.DeleteAsync(request.UserId, cancellationToken);

      /*      await fEmailService.SendMessage(
              user.Email,
              $"User '{user.FirstName} {user.LastName}' updated",
              "Your contact has been added to database.",
              cancellationToken);
      */

      return success;
    }
  }
}
