using HotChocolate.Data.Filters;
using HotChocolate.Types.Pagination;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContext<CatalogContext>(
        o => o.UseNpgsql(builder.Configuration.GetConnectionString("CatalogDB")));

builder.Services
    .AddMigration<CatalogContext, CatalogContextSeed>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .SetPagingOptions(new PagingOptions()
    {
        DefaultPageSize = 2,
        MaxPageSize = 5,
        AllowBackwardPagination = false,
        RequirePagingBoundaries = true
    })
    .AddProjections()
    .AddFiltering(config =>
    {
        config.AddDefaults()
            .BindRuntimeType<string, CustomStringOperationFilterInputType>();
    });

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);

public class CustomStringOperationFilterInputType : StringOperationFilterInputType
{
    protected override void Configure(IFilterInputTypeDescriptor descriptor)
    {
        descriptor.Operation(DefaultFilterOperations.Equals).Type<StringType>();
        descriptor.Operation(DefaultFilterOperations.StartsWith).Type<StringType>();

    }
}