namespace NorthWind.Sales.Backend.SmtpGateways.Options;

public class SmtpOptions
{
    public const string SectionKey = nameof(SmtpOptions);

    public required string SmtpHost { get; set; }

    public int SmtpPort { get; set; } = 587;

    // Compatibilidad con configuraciones existentes que usan SmtpHostPort.
    public int SmtpHostPort
    {
        get => SmtpPort;
        set => SmtpPort = value;
    }

    public required string SmtpUserName { get; set; }
    public required string SmtpPassword { get; set; }
    public required string SenderEmail { get; set; }
    public required string AdministratorEmail { get; set; }
}
