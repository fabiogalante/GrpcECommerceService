using GrpcECommerceService;

namespace GrpcClientWebApi.Endpoints;

public class OrderApi
{
    public static void MapEndpoints(WebApplication app)
    {
        app.MapPost("/create", async (OrderRequest request, Order.OrderClient client) =>
            {
                var reply = await client.CreateOrderAsync(request);
                return Results.Ok(reply);
            })
            .WithName("Create order")
            .WithOpenApi();

        app.MapGet("/order/{orderId:int}", async (int orderId, Order.OrderClient _orderClient) =>
            {
                var reply = await _orderClient.GetOrderAsync(new OrderRequest { OrderId = orderId });
                return Results.Ok(reply);
            })
            .WithName("Order by Id")
            .WithOpenApi();
    }
}