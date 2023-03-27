


using Microsoft.EntityFrameworkCore;
using Models;
using PatientFluentApi.Entities;
using PatientFluentApi;
using BusinessLogic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//var obj = builder.Configuration.GetConnectionString("LoginDB");
builder.Services.AddDbContext<PhysicianAvailabilityServiceDbContext>(options => options.UseSqlServer("Server=tcp:physicianavailabilityservice.database.windows.net,1433;Initial Catalog=PhysicianAvailabilityServiceDb;Persist Security Info=False;User ID=Srinu;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));

builder.Services.AddScoped<IRepo<PatientLogin>, Repo>();
builder.Services.AddScoped<ILogic, Logic>();


var AllowAllPolicy = "AllowAllPolicy";
builder.Services.AddCors(options =>
options.AddPolicy(AllowAllPolicy, policy => { policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(AllowAllPolicy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
