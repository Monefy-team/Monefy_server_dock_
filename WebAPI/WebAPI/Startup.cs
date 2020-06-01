using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAPI.DAL.Extensions;
using WebAPI.Extensions;
using WebAPI.Middleware;

namespace WebAPI
{
    // Конфигурация сервера
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMonefyService(Configuration);
            services.ConfigureApp();
            services.AddCors();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // Разрешает отправлять на запросы на сервер
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()); // КроссДоменніе Запросы 
            app.UseAuthorization();
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseEndpoints(endpoints =>
            { endpoints.MapControllers(); });
        }
    }
}