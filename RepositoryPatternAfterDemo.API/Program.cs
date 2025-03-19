using Microsoft.EntityFrameworkCore;
using RepositoryPatternAfterDemo.Application.Abstract;
using RepositoryPatternAfterDemo.Application.Concrete;
using RepositoryPatternAfterDemo.DataAccess.Abstract;
using RepositoryPatternAfterDemo.DataAccess.Concrete;

var builder = WebApplication.CreateBuilder(args);

// 1) appsettings.json üzerinden connection string çekilir
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2) EF Core DbContext
builder.Services.AddDbContext<MyAppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// 3) IDbContext -> MyAppDbContext
builder.Services.AddScoped<IMyAppDbContext, MyAppDbContext>();

// 4) Service (ICityService -> CityService)
builder.Services.AddScoped<ICityService, CityService>();

// 5) Controllers & Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 6) Pipeline (Swagger, Routing, etc.)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
