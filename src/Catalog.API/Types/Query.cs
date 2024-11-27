namespace eShop.Catalog.Types;

public class Query
{
    private readonly CatalogContext _context;

    public Query(CatalogContext context)
    {
        _context = context;
    }

    [UsePaging(DefaultPageSize = 1, MaxPageSize = 10)]
    [UseProjection]
    [UseFiltering]
    public IQueryable<Brand> GetBrands(CatalogContext context) => context.Brands;

    [UseFirstOrDefault]
    [UseProjection]
    public IQueryable<Brand> GetBrandById(int id, CatalogContext context) => context.Brands.Where(x => x.Id == id);
    
    [UseProjection]
    [UseFiltering]
    public IQueryable<Product> GetProducts(CatalogContext context)
        => context.Products;
    [UseFirstOrDefault]
    [UseProjection]
    public IQueryable<Product> GetProductById(int id, CatalogContext context)
        => context.Products.Where(x => x.Id == id);
}