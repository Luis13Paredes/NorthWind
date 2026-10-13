namespace NorthWind.Sales.Backend.Repositories.Interfaces;

public interface INorthWindSalesQueriesDataContext
{
    IQueryable<Entities.Customer> Customers { get; }
    IQueryable<Entities.Product> Products { get; }
    Task<ReturnType> FirstOrDefaultAync<ReturnType>(
        IQueryable<ReturnType> queryable);
    Task<IEnumerable<ReturnType>> ToListAsync<ReturnType>(
        IQueryable<ReturnType> queryable);
}
