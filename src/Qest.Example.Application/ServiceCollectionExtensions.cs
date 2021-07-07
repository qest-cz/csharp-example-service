using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Qest.Example
{
  public static class ServiceCollectionExtensions
  {
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
      services.AddMediatR(typeof(ServiceCollectionExtensions));

      return services;
    }
  }
}
