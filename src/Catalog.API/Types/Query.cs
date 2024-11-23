namespace eShop.Catalog.Types;

public class Query
{
    private readonly CatalogContext _context;

    public Query(CatalogContext context)
    {
        _context = context;
    }

    public IQueryable<Product> GetProducts() => _context.Products;
}