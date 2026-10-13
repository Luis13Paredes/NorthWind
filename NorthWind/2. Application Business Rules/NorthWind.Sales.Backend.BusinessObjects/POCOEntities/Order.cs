namespace NorthWind.Sales.Backend.BusinessObjects.POCOEntities;

public class Order
{
    public int Id { get; set; }
    public required string CustomerId { get; set; }
    public required string ShipAddress { get; set; }
    public required string ShipCity { get; set; }
    public required string ShipCountry { get; set; }
    public required string ShipPostalCode { get; set; }

    public ShippingType ShippingType { get; set; } = ShippingType.Road;
    public DiscountType DiscountType { get; set; } = DiscountType.Percentage;
    public double Discount { get; set; } = 10;
    public DateTime OrderDate { get; set; } = DateTime.Now;
}
