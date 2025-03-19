using Microsoft.EntityFrameworkCore;
using RepositoryPatternDemo.Application.Abstract;
using RepositoryPatternDemo.Application.Concrete;
using RepositoryPatternDemo.DataAccess.Abstract;
using RepositoryPatternDemo.DataAccess.Concrete;
using RepositoryPatternDemo.DataAccess.Context;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuration (appsettings.json vb.) üzerinden connection string alýnýr
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. EF Core DbContext
builder.Services.AddDbContext<MyAppDbContext>(options =>
    options.UseSqlServer(connectionString)
);

// 3. Generic Repository (IGenericRepository<T>)
builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

// 4. Service (ICityService -> CityService)
builder.Services.AddScoped<ICityService, CityService>();

// 5. Controllers & Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 6. Pipeline & Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
