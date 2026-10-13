#nullable enable
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace NorthWind.Membership.Backend.Core.Resources;

internal static class UserRegistrationMessages
{
    static readonly ResourceManager ResourceManager = new(
        "NorthWind.Membership.Backend.Core.Resources.UserRegistrationMessages",
        typeof(UserRegistrationMessages).GetTypeInfo().Assembly);

    public static CultureInfo? Culture { get; set; }

    public static string UserRegistrationErrorTitle =>
        ResourceManager.GetString(nameof(UserRegistrationErrorTitle), Culture)!;
    public static string UserRegistrationErrorDetail =>
        ResourceManager.GetString(nameof(UserRegistrationErrorDetail), Culture)!;
}
