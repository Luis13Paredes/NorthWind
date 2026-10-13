#nullable enable
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace NorthWind.Membership.Backend.AspNetIdentity.Resources;

internal static class Messages
{
    static readonly ResourceManager ResourceManager = new(
        "NorthWind.Membership.Backend.AspNetIdentity.Resources.Messages",
        typeof(Messages).GetTypeInfo().Assembly);

    public static CultureInfo? Culture { get; set; }

    public static string DuplicateUserNameErrorMessage =>
        ResourceManager.GetString(nameof(DuplicateUserNameErrorMessage), Culture)!;
}
