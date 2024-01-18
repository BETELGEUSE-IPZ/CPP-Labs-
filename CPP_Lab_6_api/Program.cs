using lab6_api.Data;
using lab6_api.Data.DB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.WebHost.UseUrls("http://*:5000");

var databaseProvider = args[0];
switch (databaseProvider)
{
    case "SqlServer":
        Console.WriteLine("SqlServer");
        builder.Services.AddDbContext<DBContext>(options =>
            options.UseSqlServer("Server=192.168.0.104,1433\\LAPTOP-OG0IFH3T;Initial Catalog=cp_lab6;User Id=ashvyndia;password=admin;TrustServerCertificate=True"));
        break;
    case "Postgres":
        Console.WriteLine("Postgres");
        builder.Services.AddDbContext<DBContext>(options =>
            options.UseNpgsql("Host=192.168.0.104;Port=5432;Database=cp_lab6;Username=postgres;Password=password"));
        break;
    case "Sqlite":
        Console.WriteLine("Sqlite");
        builder.Services.AddDbContext<DBContext>(options =>
            options.UseSqlite("Data Source=cp_lab6.db"));
        break;
    case "InMemory":
        Console.WriteLine("InMemory");
        builder.Services.AddDbContext<DBContext>(options =>
            options.UseInMemoryDatabase("cp_lab6"));
        break;
    default:
        throw new InvalidOperationException("Invalid DatabaseProvider specified in configuration.");
}

builder.Services.AddSingleton<LabExecutorDataSource>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy =>
{
    policy.AllowAnyOrigin()
          .AllowAnyHeader()
          .AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
