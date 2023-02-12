using CardOrganizer.Application.Services;
using CardOrganizer.Infrastructure.Services;

namespace CardOrganizer.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
       
        return services;
    }
    
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IAccountService, AccountService>();
        
        return services;
    }
}