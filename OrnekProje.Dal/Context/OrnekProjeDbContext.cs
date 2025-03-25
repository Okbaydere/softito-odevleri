using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrnekProje.Model.Core;
using OrnekProje.Model.DbViewModel;
using OrnekProje.Model.DbViewModel.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Grpc.Core.Metadata;

namespace OrnekProje.Dal.Context
{
    public class OrnekProjeDbContext: IdentityDbContext<User,Role,int>
    {
        public OrnekProjeDbContext(DbContextOptions<OrnekProjeDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(OrnekProjeDbContext).Assembly);
            foreach (var entityTyp in builder.Model.GetEntityTypes().Where(e => typeof(EntityBase).IsAssignableFrom(e.ClrType) && !e.ClrType.IsAbstract))
            {
                var parametre = Expression.Parameter(entityTyp.ClrType, "e");
                var property = Expression.Property(parametre, nameof(EntityBase.IsDelete));
                var filter = Expression.Lambda(Expression.Not(property), parametre);
                builder.Entity(entityTyp.ClrType).HasQueryFilter(filter);

                // Tablo adını değiştir
                builder.Entity<Category>().ToTable("Categories");
                builder.Entity<User>().ToTable("User");
                builder.Entity<UserRole>().ToTable("UserRole");
            }
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
