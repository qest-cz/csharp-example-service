using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Qest.Example.Services;
using Qest.Example.SqlServer;
using Qest.Example.SqlServer.Users.Repositories;
using Qest.Example.Users.Repositories;

namespace Qest.Example
{
  public static class ServiceCollectionExtensions
  {
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
    {
      services.AddTransient<IEmailService, EmailService>();

      services.AddScoped<IUserRepository, UserRepository>();

      services.AddDbContextPool<ExampleDbContext>(options => options.UseInMemoryDatabase("example"));

      return services;
    }
  }
}
