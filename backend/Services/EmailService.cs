using MailKit.Net.Smtp;
using MimeKit;

namespace backend.Services;

public class EmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(
        string to,
        string subject,
        string body)
    {
        var email = new MimeMessage();

        email.From.Add(
            MailboxAddress.Parse("newsletter@test.com")
        );

        email.To.Add(
            MailboxAddress.Parse(to)
        );

        email.Subject = subject;

        email.Body = new TextPart("html")
        {
            Text = body
        };

        using var smtp = new SmtpClient();

        await smtp.ConnectAsync(
            _configuration["MailSettings:Host"],
            int.Parse(_configuration["MailSettings:Port"]!),
            false
        );

        await smtp.AuthenticateAsync(
            _configuration["MailSettings:Username"],
            _configuration["MailSettings:Password"]
        );

        await smtp.SendAsync(email);

        await smtp.DisconnectAsync(true);
    }
}