using BL;
using Microsoft.AspNetCore.Hosting;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<BlManager>();
builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();
//app.MapGet("/", () => "Hello World!");

app.Run();
