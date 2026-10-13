#nullable enable
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace NorthWind.Membership.Frontend.RazorViews.Resources;

public static class CommonMessages
{
    static readonly ResourceManager ResourceManager = new(
        "NorthWind.Membership.Frontend.RazorViews.Resources.CommonMessages",
        typeof(CommonMessages).GetTypeInfo().Assembly);

    public static CultureInfo? Culture { get; set; }

    public static string OK =>
        ResourceManager.GetString(nameof(OK), Culture)!;
    public static string EmailLabel =>
        ResourceManager.GetString(nameof(EmailLabel), Culture)!;
    public static string PasswordLabel =>
        ResourceManager.GetString(nameof(PasswordLabel), Culture)!;
    public static string CreateAccountText =>
        ResourceManager.GetString(nameof(CreateAccountText), Culture)!;
    public static string LoginText =>
        ResourceManager.GetString(nameof(LoginText), Culture)!;
    public static string CloseSessionText =>
        ResourceManager.GetString(nameof(CloseSessionText), Culture)!;
}
