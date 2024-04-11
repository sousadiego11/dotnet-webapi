using Microsoft.EntityFrameworkCore;
using StorageWebAPI.Database;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddControllers();
    builder.Services.AddDbContext<StorageContext>(opt => opt.UseInMemoryDatabase("ProductsList"));
    builder.Services.AddRouting(opts => opts.LowercaseUrls = true);
};

var app = builder.Build();
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
}


app.Run();