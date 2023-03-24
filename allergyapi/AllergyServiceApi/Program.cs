using BusinessLogic;
using DataFluentApi;
using DataFluentApi.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/*
var config = builder.Configuration.GetConnectionString("connectionstring");*/
builder.Services.AddDbContext<AllergyServiceDbContext>(options => options.UseSqlServer("Server=tcp:allergyservice.database.windows.net,1433;Initial Catalog=AllergyServiceDb;Persist Security Info=False;User ID=Rizwan;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
builder.Services.AddScoped<IEFRepo, AllergyEFRepo>();


builder.Services.AddScoped<ILogic,Logic>();


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
