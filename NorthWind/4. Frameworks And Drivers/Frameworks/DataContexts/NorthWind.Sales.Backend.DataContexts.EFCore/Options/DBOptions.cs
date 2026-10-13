namespace NorthWind.Sales.Backend.DataContexts.EFCore.Options;

public class DBOptions
{
    public const string SectionKey = nameof(DBOptions);
    public required string ConnectionString { get; set; }
    public required string DomainLogsConnectionString { get; set; }
}
