using System;
using System.Threading;
using System.Threading.Tasks;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qest.Example.Service.Users.V1;
using Qest.Example.Users;
using Qest.Example.Users.Commands;
using Qest.Example.Users.Queries;

namespace Qest.Example.Service.Controllers.V1
{
  [ApiController]
  [Route("api/{apiVersion}/users")]
  public class UsersController: ControllerBase
  {
    private readonly IMediator fMediator;
    private readonly IMapper fMapper;

    public UsersController(
      IMediator mediator,
      IMapper mapper)
    {
      fMediator = mediator;
      fMapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserGetManyResponse))]
    public async Task<IActionResult> GetManyAsync([FromQuery] UserGetManyRequest query, CancellationToken cancellationToken)
    {
      var queryDto = fMapper.Map<UserQueryDto>(query);

      var users = await fMediator.Send(new GetUsersQuery(queryDto), cancellationToken);

      return Ok(new UserGetManyResponse
      {
        Users = fMapper.Map<UserPreviewResponse[]>(users)
      });
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserPostResponse))]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> PostAsync([FromBody] UserPostRequest body, CancellationToken cancellationToken)
    {
      var bodyDto = fMapper.Map<UserCreationDto>(body);

      var userId = await fMediator.Send(new CreateUserCommand(bodyDto), cancellationToken);
      if (userId is null)
        return Conflict();

      return StatusCode(StatusCodes.Status201Created, new UserPostResponse
      {
        UserId = userId.Value
      });
    }

    [HttpGet("{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserGetResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAsync([FromRoute] Guid userId, CancellationToken cancellationToken)
    {
      var user = await fMediator.Send(new GetUserQuery(userId), cancellationToken);
      if (user is null)
        return NotFound();

      return Ok(new UserGetResponse
      {
        User = fMapper.Map<UserDetailResponse>(user)
      });
    }

    [HttpPut("{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PutAsync([FromRoute] Guid userId, [FromBody] UserPutRequest body, CancellationToken cancellationToken)
    {
      var bodyDto = fMapper.Map<UserUpdateDto>(body);

      bool found = await fMediator.Send(new UpdateUserCommand(userId, bodyDto), cancellationToken);
      if (!found)
        return NotFound();

      return Ok();
    }

    [HttpDelete("{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid userId, CancellationToken cancellationToken)
    {
      bool success = await fMediator.Send(new DeleteUserCommand(userId), cancellationToken);

      if (!success)
        return NotFound();

      return Ok();
    }
  }
}
