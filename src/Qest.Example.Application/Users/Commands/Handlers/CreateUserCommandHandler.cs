using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Qest.Example.Services;
using Qest.Example.Users.Repositories;

namespace Qest.Example.Users.Commands.Handlers
{
  internal sealed class CreateUserCommandHandler: IRequestHandler<CreateUserCommand, Guid?>
  {
    private readonly IUserRepository fUserRepository;
    private readonly IEmailService fEmailService;

    public CreateUserCommandHandler(
      IUserRepository userRepository,
      IEmailService emailService)
    {
      fUserRepository = userRepository;
      fEmailService = emailService;
    }

    public async Task<Guid?> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
      var userId = await fUserRepository.CreateAsync(request.Model, cancellationToken);

      if (userId.HasValue)
      {
        await fEmailService.SendMessage(
          request.Model.Email,
          $"User '{request.Model.FirstName} {request.Model.LastName}' added",
          "Your contact has been added to database.",
          cancellationToken);
      }

      return userId;
    }
  }
}
