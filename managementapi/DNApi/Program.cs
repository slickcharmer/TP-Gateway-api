using BusinessLogicLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
var connectionString = $"Server={dbHost},1433;Initial Catalog={dbName};Persist Security Info=False;User ID=Manoj;Password={dbPassword};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=true;Connection Timeout=30;";
builder.Services.AddDbContext<DataLayer.Entities.ManojDbContext>(opt => opt.UseSqlServer(connectionString));

//builder.Services.AddScoped<DataLayer.Entities.ManojDbContext>();

builder.Services.AddScoped<DataLayer.IDoctorRepo, DoctorEFRepo>();
builder.Services.AddScoped<DataLayer.INurseRepo, NurseEFRepo>();
builder.Services.AddScoped<BusinessLogicLayer.IDoctorLogic, DoctorLogic>();
builder.Services.AddScoped<BusinessLogicLayer.INurseLogic, NurseLogic>();


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
