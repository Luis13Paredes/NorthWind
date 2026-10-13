#nullable enable
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace NorthWind.Membership.Backend.Core.Resources;

internal static class UserLoginMessages
{
    static readonly ResourceManager ResourceManager = new(
        "NorthWind.Membership.Backend.Core.Resources.UserLoginMessages",
        typeof(UserLoginMessages).GetTypeInfo().Assembly);

    public static CultureInfo? Culture { get; set; }

    public static string InvalidUserCredentialsErrorMessage =>
        ResourceManager.GetString(nameof(InvalidUserCredentialsErrorMessage), Culture)!;
    public static string UserLoginErrorTitle =>
        ResourceManager.GetString(nameof(UserLoginErrorTitle), Culture)!;
    public static string UserLoginErrorDetail =>
        ResourceManager.GetString(nameof(UserLoginErrorDetail), Culture)!;
}
