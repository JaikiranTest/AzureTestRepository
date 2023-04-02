using Microsoft.EntityFrameworkCore;
using WebAPITest.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<TestContext>(options =>
{
    options.UseSqlServer("Server=tcp:sqlazuredbjk.database.windows.net,1433;Initial Catalog=JKTestDB;Persist Security Info=False;User ID=sqladmin;Password=admin@123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    //options.UseSqlServer("Server=LAPTOP-HABKKK1S;Database=Test;Trusted_Connection=True;TrustServerCertificate=True;");
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
