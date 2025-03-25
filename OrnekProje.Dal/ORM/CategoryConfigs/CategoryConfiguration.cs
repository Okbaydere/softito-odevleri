using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrnekProje.Model.DbViewModel;

namespace OrnekProje.Dal.ORM.CategoryConfigs;

public class CategoryConfiguration:IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(x=>x.Description).HasMaxLength(500).IsRequired();
    }
}