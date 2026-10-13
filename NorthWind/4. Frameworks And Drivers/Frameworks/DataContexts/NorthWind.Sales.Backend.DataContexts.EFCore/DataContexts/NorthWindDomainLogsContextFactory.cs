namespace NorthWind.Sales.Backend.DataContexts.EFCore.DataContexts;

internal class NorthWindDomainLogsContextFactory :
    IDesignTimeDbContextFactory<NorthWindDomainLogsContext>
{
    public NorthWindDomainLogsContext CreateDbContext(string[] args)
    {
        IOptions<DBOptions> DbOptions =
            Microsoft.Extensions.Options.Options.Create(
                new DBOptions
                {
                    ConnectionString = string.Empty,
                    DomainLogsConnectionString =
                        "Server=(localdb)\\mssqllocaldb;Database=NorthWindLogsDB"
                });

        return new NorthWindDomainLogsContext(DbOptions);
    }
}
