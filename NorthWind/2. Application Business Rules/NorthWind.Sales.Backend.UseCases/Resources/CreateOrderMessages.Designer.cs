#nullable enable
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace NorthWind.Sales.Backend.UseCases.Resources;

public static class CreateOrderMessages
{
    static readonly ResourceManager ResourceManager = new(
        "NorthWind.Sales.Backend.UseCases.Resources.CreateOrderMessages",
        typeof(CreateOrderMessages).GetTypeInfo().Assembly);

    public static CultureInfo? Culture { get; set; }

    public static string CustomerIdNotFoundError =>
        ResourceManager.GetString(nameof(CustomerIdNotFoundError), Culture)!;
    public static string CustomerWithBalanceErrorTemplate =>
        ResourceManager.GetString(nameof(CustomerWithBalanceErrorTemplate), Culture)!;
    public static string ProductIdNotFoundErrorTemplate =>
        ResourceManager.GetString(nameof(ProductIdNotFoundErrorTemplate), Culture)!;
    public static string UnitsInStockLessThanQuantityErrorTemplate =>
        ResourceManager.GetString(nameof(UnitsInStockLessThanQuantityErrorTemplate), Culture)!;
    public static string SendEmailSubject =>
        ResourceManager.GetString(nameof(SendEmailSubject), Culture)!;
    public static string SendEmailBodyTemplate =>
        ResourceManager.GetString(nameof(SendEmailBodyTemplate), Culture)!;
    public static string StartingPurchaseOrderCreation =>
        ResourceManager.GetString(nameof(StartingPurchaseOrderCreation), Culture)!;
    public static string PurchaseOrderCreatedTemplate =>
        ResourceManager.GetString(nameof(PurchaseOrderCreatedTemplate), Culture)!;
    public static string OrderCreationCancelledTemplate =>
        ResourceManager.GetString(nameof(OrderCreationCancelledTemplate), Culture)!;
}
