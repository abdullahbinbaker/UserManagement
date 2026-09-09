using Microsoft.Extensions.DependencyInjection;
using UserManagement.Application.Services;

namespace UserManagement.Application;

public static class Setup
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}
