namespace NorthWind.Membership.Backend.Core.Options;

public class JwtOptions
{
    public const string SectionKey = nameof(JwtOptions);
    public required string SecurityKey { get; set; }
    public required string ValidIssuer { get; set; }
    public required string ValidAudience { get; set; }
    public int ExpireInMinutes { get; set; }
}
