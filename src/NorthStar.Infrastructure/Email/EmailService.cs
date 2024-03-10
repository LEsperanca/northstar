using NorthStar.Application.Abstractions.Email;

namespace NorthStar.Infrastructure.Email;
internal sealed class EmailService : IEmailService
{
    public Task SendAsync(Domain.People.Email email, string subject, string body)
    {
        return Task.CompletedTask;
    }
}
