using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Qest.Example.Repositories;
using Qest.Example.Services;

namespace Qest.Example.Users.Commands.Handlers
{
  internal sealed class CreateUserCommandHandler: IRequestHandler<CreateUserCommand, Guid?>
  {
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;

    public CreateUserCommandHandler(
      IUserRepository userRepository,
      IEmailService emailService)
    {
      _userRepository = userRepository;
      _emailService = emailService;
    }

    public async Task<Guid?> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
      var userId = await _userRepository.CreateAsync(request.Model, cancellationToken);

      if (userId.HasValue)
      {
        await _emailService.SendMessage(
          request.Model.Email,
          $"User '{request.Model.FirstName} {request.Model.LastName}' added",
          "Your contact has been added to database.",
          cancellationToken);
      }

      return userId;
    }
  }
}
