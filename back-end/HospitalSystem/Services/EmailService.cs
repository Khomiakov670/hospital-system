using FluentResults;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Services.Interfaces;
using Services.Options;

namespace Services;

public class EmailService : IEmailService
{
    private readonly EmailOptions _options;

    public EmailService(IOptions<EmailOptions> options)
    {
        _options = options.Value;
    }

    public async Task<Result> SendEmailAsync(string email, string subject, string body)
    {
        var emailMessage = new MimeMessage();
        var addressFrom = new MailboxAddress(_options.Username,
            _options.From);
        var addressTo = new MailboxAddress(string.Empty,
            email);

        emailMessage.From.Add(addressFrom);
        emailMessage.To.Add(addressTo);
        emailMessage.Subject = subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = body,
        };

        using var client = new SmtpClient();

        var smtpServer = _options.SmptServer;
        var port = int.Parse(_options.Port);

        try
        {
            await client.ConnectAsync(smtpServer,
                port,
                SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(addressFrom.Address,
                _options.Password);
            await client.SendAsync(emailMessage);
        }
        catch (Exception ex)
        {
            return Result.Fail(ex.Message);
        }
        finally
        {
            await client.DisconnectAsync(true);
        }

        return Result.Ok();
    }
}