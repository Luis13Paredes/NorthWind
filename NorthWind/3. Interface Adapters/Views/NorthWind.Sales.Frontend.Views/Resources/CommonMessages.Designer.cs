#nullable enable
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace NorthWind.Sales.Frontend.Views.Resources;

public static class CommonMessages
{
    static readonly ResourceManager ResourceManager = new(
        "NorthWind.Sales.Frontend.Views.Resources.CommonMessages",
        typeof(CommonMessages).GetTypeInfo().Assembly);

    public static CultureInfo? Culture { get; set; }

    public static string OK =>
        ResourceManager.GetString(nameof(OK), Culture)!;
    public static string NavBarBrandTitle =>
        ResourceManager.GetString(nameof(NavBarBrandTitle), Culture)!;
    public static string HomeMenuItemTitle =>
        ResourceManager.GetString(nameof(HomeMenuItemTitle), Culture)!;
    public static string AboutTitle =>
        ResourceManager.GetString(nameof(AboutTitle), Culture)!;
}
