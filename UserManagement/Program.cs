using UserManagement.Application;
using UserManagement.Domain;
using UserManagement.Integration;
using Serilog;
using Microsoft.AspNetCore.Diagnostics;
using UserManagement.Middleware;
using UserManagement.ApiKay;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File(path: "logs/log-.txt",
                       rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.OperationFilter<ApiKayHeader>();
});

builder.Services.AddDomainLayer(builder.Configuration);
builder.Services.AddIntegrationLayer();
builder.Services.AddApplicationLayer();

var app = builder.Build();


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();


//app.UseAuthorization();


app.MapControllers();

app.Run();



