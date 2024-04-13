using Microsoft.EntityFrameworkCore;
using StorageWebAPI.Database;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TodoContext") ?? throw new InvalidOperationException("Connection string 'TodoContext' not found.")));
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<StorageContext>(opt => opt.UseInMemoryDatabase("ProductsList"));
    builder.Services.AddRouting(opts => opts.LowercaseUrls = true);
};

var app = builder.Build();
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
    app.MapControllers();
}


app.Run();