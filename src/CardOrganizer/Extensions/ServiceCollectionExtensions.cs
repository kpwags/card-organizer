namespace CardOrganizer.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IBrandRespository, BrandRepository>();
        services.AddTransient<IBaseballCardRepository, BaseballCardRepository>();
        
        return services;
    }
    
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IAccountService, AccountService>();
        services.AddTransient<IFileService, FileService>();
        services.AddTransient<IImageService, ImageService>();
        
        return services;
    }
}