using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Qest.Example.Users.Repositories
{
  public interface IUserRepository
  {
    Task<IReadOnlyCollection<UserPreviewDto>> GetManyAsync(UserQueryDto model, CancellationToken cancellationToken);

    Task<Guid?> CreateAsync(UserCreationDto model, CancellationToken cancellationToken);

    Task<UserDetailDto?> GetDetailByIdAsync(Guid userId, CancellationToken cancellationToken);

    Task<UserDetailDto?> UpdateAsync(Guid userId, UserUpdateDto model, CancellationToken cancellationToken);

    Task<bool> DeleteAsync(Guid userId, CancellationToken cancellationToken);
  }
}
