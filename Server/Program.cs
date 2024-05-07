using BL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<BlManager>();
builder.Services.AddControllers();


var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

builder.Services.AddCors(options =>
{
    var frontend_url = configuration.GetValue<string>("frontend_url");
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontend_url).AllowAnyMethod().AllowAnyHeader();
    });
});
var app = builder.Build();
app.UseHttpsRedirection();
app.UseCors();
app.MapControllers();
//app.MapGet("/", () => "Hello World!");

app.Run();
