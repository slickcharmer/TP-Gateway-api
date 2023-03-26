using AuditFluentApi.Entites;
using AuditFluentApi;
using AuditModels;
using Microsoft.EntityFrameworkCore;
using AuditLogic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AuditServiceContext>(options => options.UseSqlServer("Server=tcp:physicianavailabilityservice.database.windows.net,1433;Initial Catalog=audit_service;Persist Security Info=False;User ID=Srinu;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));

builder.Services.AddScoped<IRepo<Audit>, Repo>();

builder.Services.AddScoped<ILogic, Logic>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
