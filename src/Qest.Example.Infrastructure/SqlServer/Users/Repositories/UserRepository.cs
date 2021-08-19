using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Qest.Example.Repositories;
using Qest.Example.Users;

namespace Qest.Example.SqlServer.Repositories
{
  internal sealed class UserRepository: IUserRepository
  {
    private readonly ExampleDbContext fDbContext;
    private readonly IMapper fMapper;

    public UserRepository(
      ExampleDbContext dbContext,
      IMapper mapper)
    {
      fDbContext = dbContext;
      fMapper = mapper;
    }

    public async Task<IReadOnlyCollection<UserPreviewDto>> GetManyAsync(UserQueryDto model, CancellationToken cancellationToken)
    {
      var query = fDbContext.Users
        .AsNoTracking();

      if (model.Role.HasValue)
        query = query.Where(e => e.Role == model.Role.Value);

      return await query
        .OrderBy(e => e.LastName)
        .ThenBy(e => e.FirstName)
        .Skip(model.Offset)
        .Take(model.Limit)
        .ProjectToType<UserPreviewDto>(fMapper.Config)
        .ToListAsync(cancellationToken);
    }

    public Task<Guid?> CreateAsync(UserCreationDto model, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<UserDetailDto?> GetDetailByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<UserDetailDto?> UpdateAsync(Guid userId, UserUpdateDto model, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }
  }
}
