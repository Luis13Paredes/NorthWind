namespace NorthWind.Membership.Backend.AspNetIdentity.Entities;

internal class NorthWindUser : IdentityUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}
