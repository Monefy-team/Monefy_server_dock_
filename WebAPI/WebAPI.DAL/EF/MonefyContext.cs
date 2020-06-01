using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAPI.DAL.Configuration;
using WebAPI.DAL.Entities;

namespace WebAPI.DAL.EF
{
    public class MonefyContext : IdentityDbContext<User>
    {
        private DbSet<Finance> Finances { get; set; } // таблица Finances
        
        // передаем в параметре опции entity framework 
        public MonefyContext(DbContextOptions<MonefyContext> options) : base(options)
        {
            Database.EnsureCreated(); // создаем базу данных если есть то пропускаем
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // применяем конфигурацию для финансов
            builder.ApplyConfiguration(new FinanceConfiguration());
            base.OnModelCreating(builder);
        }
    }
}