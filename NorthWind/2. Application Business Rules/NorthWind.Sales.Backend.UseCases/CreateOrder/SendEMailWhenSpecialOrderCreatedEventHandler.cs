namespace NorthWind.Sales.Backend.UseCases.CreateOrder;

internal class SendEMailWhenSpecialOrderCreatedEventHandler(
    NorthWind.Sales.Backend.BusinessObjects.Interfaces.IMailService mailService) :
    IDomainEventHandler<SpecialOrderCreatedEvent>
{
    public Task Handle(SpecialOrderCreatedEvent createdOrder)
    {
        return mailService.SendMailToAdministratorAsync(
            CreateOrderMessages.SendEmailSubject,
            string.Format(CreateOrderMessages.SendEmailBodyTemplate,
                createdOrder.OrderId, createdOrder.ProductsCount));
    }
}
