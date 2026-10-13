#nullable enable
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace NorthWind.Exceptions.Entities.Resources;

public static class ExceptionMessages
{
    static readonly ResourceManager ResourceManager = new(
        "NorthWind.Exceptions.Entities.Resources.ExceptionMessages",
        typeof(ExceptionMessages).GetTypeInfo().Assembly);

    public static CultureInfo? Culture { get; set; }

    public static string ValidationExceptionTitle =>
        ResourceManager.GetString(nameof(ValidationExceptionTitle), Culture)!;
    public static string ValidationExceptionDetail =>
        ResourceManager.GetString(nameof(ValidationExceptionDetail), Culture)!;
    public static string UpdateExceptionTitle =>
        ResourceManager.GetString(nameof(UpdateExceptionTitle), Culture)!;
    public static string UpdateExceptionDetail =>
        ResourceManager.GetString(nameof(UpdateExceptionDetail), Culture)!;
    public static string UnhandledExceptionTitle =>
        ResourceManager.GetString(nameof(UnhandledExceptionTitle), Culture)!;
    public static string UnhandledExceptionDetail =>
        ResourceManager.GetString(nameof(UnhandledExceptionDetail), Culture)!;
    public static string UnauthorizedAccessExceptionTitle =>
        ResourceManager.GetString(nameof(UnauthorizedAccessExceptionTitle), Culture)!;
    public static string UnauthorizedAccessExceptionDetail =>
        ResourceManager.GetString(nameof(UnauthorizedAccessExceptionDetail), Culture)!;
}
