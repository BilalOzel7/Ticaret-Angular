using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticaret.Core.DbModels;
using Ticaret.Core.DbModels.Identity;
using Ticaret.Core.DbModels.OrderAggregate;

namespace Ticaret.Infrastructure.DataContext
{
   public class StoreContext:IdentityDbContext<AppUser>
    {
        public StoreContext(DbContextOptions<StoreContext> options):base(options)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Core.DbModels.Identity.Address> Addresses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
