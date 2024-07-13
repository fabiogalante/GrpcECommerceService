using GrpcClientWebApi.Endpoints;
using GrpcECommerceService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

builder.Services.AddGrpcClient<Product.ProductClient>(o =>
{
    o.Address = new Uri("https://localhost:5001");
});
builder.Services.AddGrpcClient<Order.OrderClient>(o =>
{
    o.Address = new Uri("https://localhost:5001");
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGrpcService<Product.ProductClient>();

app.MapGrpcService<Order.OrderClient>();







ProductApi.MapEndpoints(app);
OrderApi.MapEndpoints(app);
app.Run();

