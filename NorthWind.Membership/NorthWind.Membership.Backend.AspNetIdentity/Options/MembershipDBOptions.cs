namespace NorthWind.Membership.Backend.AspNetIdentity.Options;

public class MembershipDBOptions
{
    public const string SectionKey = nameof(MembershipDBOptions);
    public required string ConnectionString { get; set; }
}
