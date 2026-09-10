using Microsoft.Extensions.DependencyInjection;
using UserManagement.Application.Services;
using UserManagement.Application.Mappers;
using AutoMapper;
namespace UserManagement.Application;

public static class Setup
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddAutoMapper(cfg => {
            cfg.AddProfile<UserProfile>();
            });
        return services;
    }
}
