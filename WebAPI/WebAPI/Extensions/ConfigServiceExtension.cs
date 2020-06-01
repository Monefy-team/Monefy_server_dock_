using Microsoft.Extensions.DependencyInjection;
using WebAPI.BLL.Interfaces;
using WebAPI.BLL.Services;

namespace WebAPI.Extensions
{
    public static class ConfigServiceExtension
    {
        
        // Dependency Injection - Инициализирует неявно обьект
        public static void ConfigureApp(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFinanceService, FinanceService>();
        }
    }
}