namespace eShop.Catalog.Types;

public class Query
{
    private readonly CatalogContext _context;

    public Query(CatalogContext context)
    {
        _context = context;
    }
    [UseProjection]
    public IQueryable<Product> GetProducts(CatalogContext context)
        => context.Products;
    [UseFirstOrDefault]
    [UseProjection]
    public IQueryable<Product> GetProductById(int id, CatalogContext context)
        => context.Products.Where(x => x.Id == id);
}