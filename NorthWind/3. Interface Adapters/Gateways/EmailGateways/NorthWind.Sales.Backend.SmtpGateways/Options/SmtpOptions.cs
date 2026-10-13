namespace NorthWind.Sales.Backend.SmtpGateways.Options;

public class SmtpOptions
{
    public const string SectionKey = nameof(SmtpOptions);

    public required string SmtpHost { get; set; }
    public int SmtpHostPort { get; set; }
    public required string SmtpUserName { get; set; }
    public required string SmtpPassword { get; set; }
    public required string SenderEmail { get; set; }
    public required string AdministratorEmail { get; set; }
}
