namespace NorthStar.Application.Abstractions.Email;
public interface IEmailService
{
    Task SendAsync(Domain.People.Email email, string subject, string body);
}
