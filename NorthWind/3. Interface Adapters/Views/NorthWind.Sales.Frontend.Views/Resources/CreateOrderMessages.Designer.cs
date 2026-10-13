#nullable enable
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace NorthWind.Sales.Frontend.Views.Resources;

public static class CreateOrderMessages
{
    static readonly ResourceManager ResourceManager = new(
        "NorthWind.Sales.Frontend.Views.Resources.CreateOrderMessages",
        typeof(CreateOrderMessages).GetTypeInfo().Assembly);

    public static CultureInfo? Culture { get; set; }

    public static string CustomerIdLabel =>
        ResourceManager.GetString(nameof(CustomerIdLabel), Culture)!;
    public static string ShipAddressLabel =>
        ResourceManager.GetString(nameof(ShipAddressLabel), Culture)!;
    public static string ShipCityLabel =>
        ResourceManager.GetString(nameof(ShipCityLabel), Culture)!;
    public static string ShipCountryLabel =>
        ResourceManager.GetString(nameof(ShipCountryLabel), Culture)!;
    public static string ShipPostalCodeLabel =>
        ResourceManager.GetString(nameof(ShipPostalCodeLabel), Culture)!;
    public static string ProductIdLabel =>
        ResourceManager.GetString(nameof(ProductIdLabel), Culture)!;
    public static string UnitPriceLabel =>
        ResourceManager.GetString(nameof(UnitPriceLabel), Culture)!;
    public static string QuantityLabel =>
        ResourceManager.GetString(nameof(QuantityLabel), Culture)!;
    public static string AddProductButtonText =>
        ResourceManager.GetString(nameof(AddProductButtonText), Culture)!;
    public static string SendButtonText =>
        ResourceManager.GetString(nameof(SendButtonText), Culture)!;
    public static string CreatedOrderTemplate =>
        ResourceManager.GetString(nameof(CreatedOrderTemplate), Culture)!;
    public static string CreateOrderMenuItemTitle =>
        ResourceManager.GetString(nameof(CreateOrderMenuItemTitle), Culture)!;
    public static string CreateOrderPageTitle =>
        ResourceManager.GetString(nameof(CreateOrderPageTitle), Culture)!;
}
