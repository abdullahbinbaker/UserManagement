using UserManagement.Application;
using UserManagement.Domain;
using UserManagement.Integration;
using Serilog;
using Microsoft.AspNetCore.Diagnostics;

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
builder.Services.AddSwaggerGen();

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


app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();




//app.UseAuthorization();


app.MapControllers();

app.Run();



