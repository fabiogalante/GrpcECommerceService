using Grpc.Core;

namespace GrpcECommerceService.Services;

public class ProductService : Product.ProductBase
{
    public static readonly List<ProductReply> Products =
    [
        new ProductReply { ProductId = 1, Name = "Product 1", Price = 9.99F },
        new ProductReply { ProductId = 2, Name = "Product 2", Price = 19.99F },
        new ProductReply { ProductId = 3, Name = "Product 3", Price = 29.99F }
    ];

    public override Task<ProductReply?> GetProduct(ProductRequest request, ServerCallContext context)
    {
        var product = Products.Find(p => p.ProductId == request.ProductId);
        return Task.FromResult(product);
    }

    public override Task<ProductListReply> ListProducts(Empty request, ServerCallContext context)
    {
        var reply = new ProductListReply();
        reply.Products.AddRange(Products);
        return Task.FromResult(reply);
    }
}