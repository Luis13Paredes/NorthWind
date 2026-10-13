namespace NorthWind.Sales.Backend.SmtpGateways;

internal class MailService(IOptions<SmtpOptions> smtpOptions,
    ILogger<MailService> logger) :
    NorthWind.Sales.Backend.BusinessObjects.Interfaces.IMailService,
    NorthWind.Entities.Interfaces.IMailService
{
    public async Task SendMailToAdministratorAsync(
        string subject, string body)
    {
        try
        {
            int Port = smtpOptions.Value.SmtpPort is 0
                ? smtpOptions.Value.SmtpHostPort
                : smtpOptions.Value.SmtpPort;

            using MailMessage Message =
                new MailMessage(smtpOptions.Value.SenderEmail,
                    smtpOptions.Value.AdministratorEmail);
            Message.Subject = subject;
            Message.Body = body;

            using SmtpClient Client = new SmtpClient(
                smtpOptions.Value.SmtpHost, Port)
            {
                Credentials = new NetworkCredential(
                    smtpOptions.Value.SmtpUserName,
                    smtpOptions.Value.SmtpPassword),
                EnableSsl = true
            };

            await Client.SendMailAsync(Message);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            throw;
        }
    }

    Task NorthWind.Entities.Interfaces.IMailService.SendMailToAdministrator(
        string subject, string body) =>
        SendMailToAdministratorAsync(subject, body);
}
