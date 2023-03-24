using Microsoft.EntityFrameworkCore;
using FluentApi.Entities;
using Models;
using FluentApi;
using BusinessLogic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*
var conObj = builder.Configuration.GetConnectionString("ScheduleDB");*/
builder.Services.AddDbContext<AvailabilityScheduleContext>(options => options.UseSqlServer("Server=doctor-availability-server.database.windows.net,1433;Initial Catalog=AvailabilitySchedule;Persist Security Info=False;User ID=Srinu;Password=Doctor@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));

builder.Services.AddScoped<IRepo<DoctorSchedule>, Repo>();
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
