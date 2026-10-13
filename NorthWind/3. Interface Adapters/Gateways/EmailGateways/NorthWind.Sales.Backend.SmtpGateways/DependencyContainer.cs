namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddMailServices(
        this IServiceCollection services,
        Action<SmtpOptions> configureSmtpOptions)
    {
        services.AddSingleton<MailService>();
        services.AddSingleton<NorthWind.Entities.Interfaces.IMailService>(
            sp => sp.GetRequiredService<MailService>());
        services.AddSingleton<NorthWind.Sales.Backend.BusinessObjects.Interfaces.IMailService>(
            sp => sp.GetRequiredService<MailService>());
        services.Configure(configureSmtpOptions);
        return services;
    }
}
