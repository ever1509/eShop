namespace eShop.Catalog.Types;

public class Query
{
    private readonly CatalogContext _context;

    public Query(CatalogContext context)
    {
        _context = context;
    }

    public IQueryable<Product> GetProducts(CatalogContext context)
        => context.Products;

    public Task<Product?> GetProductById(int id, CatalogContext context)
        => context.Products.FirstOrDefaultAsync(x => x.Id == id);
}