using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Qest.Example.Repositories;
using Qest.Example.SqlServer;
using Qest.Example.SqlServer.Repositories;

namespace Qest.Example
{
  public static class ServiceCollectionExtensions
  {
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
    {
      services.AddScoped<IUserRepository, UserRepository>();

      services.AddDbContextPool<ExampleDbContext>(options => options.UseInMemoryDatabase("example"));

      return services;
    }
  }
}
