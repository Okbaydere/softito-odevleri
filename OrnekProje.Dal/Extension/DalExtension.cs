using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrnekProje.Dal.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrnekProje.Dal.Repository.Abstract;
using OrnekProje.Dal.Repository.Concrete;
using OrnekProje.Model.DbViewModel;
using OrnekProje.Model.DbViewModel.Identity;
using OrnekProje.Model.DTOs.Data;
using OrnekProje.Model.DTOs.IdentityDto;

namespace OrnekProje.Dal.Extension
{
    public static class DalExtension
    {
        public static IServiceCollection LoadDalLayerExtension(this ServiceCollection services,IConfiguration configuration)
        {
            var env = configuration["Environment"] ?? throw new ArgumentException("Environment configuration is missin");
            var ConnectionString = env == "Development" ?
                configuration.GetConnectionString("TestDatabase") ?? 
                throw new ArgumentNullException("Test database ConnectionString") : 
                configuration.GetConnectionString("LiveDatabase") ?? 
                throw new ArgumentNullException("LiveDatabase connection is string missing");

            //DbContext
            services.AddDbContext<OrnekProjeDbContext>(options =>
            options.UseSqlServer(ConnectionString, sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(15), errorNumbersToAdd: null);
                sqlOptions.CommandTimeout(30);
            }));
            services.AddScoped<IRepositoryDto<CategoryDto>, RepositoryDto<Category, CategoryDto>>();
            services.AddScoped<IRepositoryDto<ProductDto>, RepositoryDto<Product, ProductDto>>();

            services.AddScoped<IRepositoryDto<UserDto>, RepositoryDto<User, UserDto>>();
            services.AddScoped<IRepositoryDto<RoleDto>, RepositoryDto<Role, RoleDto>>();
            
            return services;
        }
    }
}
