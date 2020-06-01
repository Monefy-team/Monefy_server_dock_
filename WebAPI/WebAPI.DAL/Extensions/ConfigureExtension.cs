
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.DAL.EF;
using WebAPI.DAL.EFRepositories;
using WebAPI.DAL.Entities;
using WebAPI.DAL.Interfaces;

namespace WebAPI.DAL.Extensions
{
    public static class ConfigureExtension
    {
        public static void AddMonefyService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>(); // DI
            
            services.AddDbContext<MonefyContext>(options =>
                options.UseLazyLoadingProxies()  // использование ленивой загрузки
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))); // строка подключения

            services
                .AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<MonefyContext>();
        }

    }
}