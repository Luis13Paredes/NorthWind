namespace NorthWind.Sales.Backend.DataContexts.EFCore.Services;

internal class NorthWindSalesQueriesDataContext :
    NorthWindSalesContext,
    INorthWindSalesQueriesDataContext
{
    public NorthWindSalesQueriesDataContext(IOptions<DBOptions> dbOptions)
        : base(dbOptions)
    {
        ChangeTracker.QueryTrackingBehavior =
            QueryTrackingBehavior.NoTracking;
    }

    public new IQueryable<Repositories.Entities.Customer> Customers => base.Customers;
    public new IQueryable<Repositories.Entities.Product> Products => base.Products;

    public async Task<ReturnType> FirstOrDefaultAync<ReturnType>(
        IQueryable<ReturnType> queryable) =>
        (await queryable.FirstOrDefaultAsync())!;

    public async Task<IEnumerable<ReturnType>> ToListAsync<ReturnType>(
        IQueryable<ReturnType> queryable) =>
        await queryable.ToListAsync();
}
