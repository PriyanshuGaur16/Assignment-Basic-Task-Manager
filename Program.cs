using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.API.Repositories;


var builder = WebApplication.CreateBuilder(args);


// Add services
builder.Services.AddControllers();
builder.Services.AddSingleton<ITaskRepository, InMemoryTaskRepository>();


// Allow CORS for local frontend during development
builder.Services.AddCors(options =>
{
options.AddPolicy(name: "AllowAll",
policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});


var app = builder.Build();


app.UseCors("AllowAll");
app.MapControllers();


app.Run();
