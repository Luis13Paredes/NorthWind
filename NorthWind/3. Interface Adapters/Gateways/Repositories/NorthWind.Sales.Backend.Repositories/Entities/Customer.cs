namespace NorthWind.Sales.Backend.Repositories.Entities;

public class Customer
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public decimal CurrentBalance { get; set; }
}
