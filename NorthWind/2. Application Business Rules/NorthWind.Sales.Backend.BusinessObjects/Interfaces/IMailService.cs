namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces;

public interface IMailService
{
    Task SendMailToAdministratorAsync(string subject, string body);
}
