using System.Threading;
using System.Threading.Tasks;

namespace Qest.Example.Services
{
  internal sealed class EmailService: IEmailService
  {
    public async Task SendMessage(string address, string subject, string body, CancellationToken cancellationToken)
    {
      // SIMULATION OF EMAIL SENDING
      await Task.Delay(20, cancellationToken);
    }
  }
}
