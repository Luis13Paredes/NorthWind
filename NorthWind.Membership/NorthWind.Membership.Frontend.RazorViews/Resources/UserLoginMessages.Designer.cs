#nullable enable
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace NorthWind.Membership.Frontend.RazorViews.Resources;

public static class UserLoginMessages
{
    static readonly ResourceManager ResourceManager = new(
        "NorthWind.Membership.Frontend.RazorViews.Resources.UserLoginMessages",
        typeof(UserLoginMessages).GetTypeInfo().Assembly);

    public static CultureInfo? Culture { get; set; }

    public static string LoginButtonText =>
        ResourceManager.GetString(nameof(LoginButtonText), Culture)!;
}
