using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Qest.Example.Service
{
  public class Program
  {
    public static Task Main(string[] args)
    {
      return CreateHostBuilder(args)
        .Build()
        .RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
      return Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
          webBuilder.UseStartup<Startup>();
        });
    }
  }
}
