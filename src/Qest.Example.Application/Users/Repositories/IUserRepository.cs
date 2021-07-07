using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Qest.Example.Users;

namespace Qest.Example.Repositories
{
  public interface IUserRepository
  {
    Task<IReadOnlyList<UserPreviewDto>> GetManyAsync(UserQueryDto model, CancellationToken cancellationToken);
    Task<Guid?> CreateAsync(UserCreationDto model, CancellationToken cancellationToken);
    Task<UserDetailDto?> GetDetailByIdAsync(Guid userId, CancellationToken cancellationToken);
    Task<UserDetailDto?> UpdateAsync(Guid userId, UserUpdateDto model, CancellationToken cancellationToken);
  }
}
