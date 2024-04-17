using Microsoft.EntityFrameworkCore;
using StorageWebAPI.Database;
using StorageWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<StorageContext>(opt => opt.UseInMemoryDatabase("ProductsList"));
    builder.Services.AddRouting(opts => opts.LowercaseUrls = true);
    builder.Services.AddTransient<ProductsService>();
};

var app = builder.Build();
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
    app.MapControllers();
}


app.Run();