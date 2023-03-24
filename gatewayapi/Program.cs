using Ocelot.Cache.Middleware;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();
builder.Services.AddOcelot(builder.Configuration);

builder.Services.AddCors(opt => opt.AddPolicy("corsapp", builder =>
{
    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();
app.UseCors("corsapp");
await app.UseOcelot();
// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
