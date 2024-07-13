using Grpc.Core;

namespace GrpcECommerceService.Services;

public class OrderService : Order.OrderBase
{
    private static readonly List<OrderReply> Orders = new();

    public override Task<OrderReply> CreateOrder(OrderRequest request, ServerCallContext context)
    {
        var products = ProductService
            .Products
            .Where(p => request.ProductIds.Contains(p.ProductId)).ToList();
        
        
        var totalAmount = products.Sum(p => p.Price);

        var order = new OrderReply
        {
            OrderId = request.OrderId,
            Products = { products },
            TotalAmount = totalAmount
        };

        Orders.Add(order);
        return Task.FromResult(order);
    }

    public override Task<OrderReply?> GetOrder(OrderRequest request, ServerCallContext context)
    {
        var order = Orders.Find(o => o.OrderId == request.OrderId);
        return Task.FromResult(order);
    }
}