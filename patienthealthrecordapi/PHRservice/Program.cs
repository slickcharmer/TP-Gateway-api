using BusinessLogic;
using PHREntityFrame.Entities;
using EntityFrame;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddXmlSerializerFormatters();

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        }
        )
    );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/*
var config = builder.Configuration.GetConnectionString("HospitalDb");*/
builder.Services.AddDbContext<PatientHealthDbContext>(Options => Options.UseSqlServer("Server=tcp:yashu-db-server.database.windows.net,1433;Initial Catalog=Patient_Health_DB; User ID=yashu;Password=Yash@123;"));
builder.Services.AddScoped<IRepo, EfRepo>();
builder.Services.AddScoped<ILogic, Logic>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
