#nullable enable
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace NorthWind.Membership.Frontend.RazorViews.Resources;

public static class UserRegistrationMessages
{
    static readonly ResourceManager ResourceManager = new(
        "NorthWind.Membership.Frontend.RazorViews.Resources.UserRegistrationMessages",
        typeof(UserRegistrationMessages).GetTypeInfo().Assembly);

    public static CultureInfo? Culture { get; set; }

    public static string ConfirmPasswordErrorMessage =>
        ResourceManager.GetString(nameof(ConfirmPasswordErrorMessage), Culture)!;
    public static string RegisteredUserMessage =>
        ResourceManager.GetString(nameof(RegisteredUserMessage), Culture)!;
    public static string FirstNameLabel =>
        ResourceManager.GetString(nameof(FirstNameLabel), Culture)!;
    public static string LastNameLabel =>
        ResourceManager.GetString(nameof(LastNameLabel), Culture)!;
    public static string PasswordConfirmationLabel =>
        ResourceManager.GetString(nameof(PasswordConfirmationLabel), Culture)!;
    public static string RegisterButtonText =>
        ResourceManager.GetString(nameof(RegisterButtonText), Culture)!;
}
