using System.Threading;
using System.Threading.Tasks;

namespace Qest.Example.Services
{
  public interface IEmailService
  {
    Task SendMessage(string address, string subject, string body, CancellationToken cancellationToken);
  }
}
