using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.DAL.Entities;

namespace WebAPI.DAL.Configuration
{
    public class FinanceConfiguration : IEntityTypeConfiguration<Finance>
    {
        public void Configure(EntityTypeBuilder<Finance> builder)
        {
            builder
                .Property(x => x.Amount)
                .IsRequired();
            
            builder
                .Property(x => x.Comment)
                .IsRequired().HasMaxLength(70);
        }
    }
}