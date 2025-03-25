using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrnekProjeBusiness.Services.Abstract;
using OrnekProjeBusiness.Services.Concrete;

namespace OrnekProjeBusiness.Extensions;

public static class BllExtensions
{
    public static IServiceCollection LoadBllLayerExtension(this IServiceCollection services,
        IConfiguration configuration)
    {

        services.AddAutoMapper(typeof(BllExtensions).Assembly);
        
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        
        services.AddScoped<IUserServices, UserService>();
        services.AddScoped<IRoleServices, RoleServices>();
        
        return services;
    }
}