using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Qest.Example.Users;
using Qest.Example.Users.Repositories;

namespace Qest.Example.SqlServer.Users.Repositories
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

    public async Task<Guid?> CreateAsync(UserCreationDto model, CancellationToken cancellationToken)
    {
      var user = fDbContext.Users.Add(fMapper.Map<UserEntity>(model));

      await fDbContext.SaveChangesAsync(cancellationToken);
      return user.Entity.Id;
    }

    public Task<UserDetailDto?> GetDetailByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<UserDetailDto?> UpdateAsync(Guid userId, UserUpdateDto model, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(Guid userId, CancellationToken cancellationToken)
    {
      UserEntity? user = fDbContext.Users.Find(userId);

      if (user is not null)
      {
        fDbContext.Users.Remove(user);
        await fDbContext.SaveChangesAsync(cancellationToken);

        return true;
      }

      return false;
    }
  }
}
