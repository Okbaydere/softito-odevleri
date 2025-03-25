using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrnekProje.Model.DbViewModel;

namespace OrnekProje.Dal.ORM.ProductConfigs;

public class ProductConfiguration:IEntityTypeConfiguration<Product> 
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x=> x.Name).HasMaxLength(50).IsRequired();
        builder.Property(x=>x.Description).HasMaxLength(500).IsRequired();
        builder.Property(x=>x.Price).HasPrecision(18,2);
        builder.HasOne(x=>x.Category).WithMany().HasForeignKey(x=>x.CategoryId).OnDelete(DeleteBehavior.Restrict);
        
    }
}