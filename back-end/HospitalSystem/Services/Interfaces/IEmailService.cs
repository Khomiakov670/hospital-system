using FluentResults;

namespace Services.Interfaces;

public interface IEmailService
{
    
    Task<Result> SendEmailAsync(string email, string subject, string body);
}