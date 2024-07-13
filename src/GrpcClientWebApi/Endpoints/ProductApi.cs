using GrpcECommerceService;

namespace GrpcClientWebApi.Endpoints;

public class ProductApi
{
    public static void MapEndpoints(WebApplication app)
    {
        app.MapGet("/{productId:int}", async (int productId, Product.ProductClient client) =>
        {
            var request = new ProductRequest { ProductId = productId };

            var result = await client.GetProductAsync(request);

            return result;
        });

        app.MapGet("/products", async (Product.ProductClient client) =>
            {
                var request = new Empty();
                var result = await client.ListProductsAsync(request);
                return result;
            })
            .WithName("Get Products")
            .WithOpenApi();
    }
}