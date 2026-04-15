using Blazor26.Models.Models;
using Microsoft.EntityFrameworkCore;


namespace Blazor26.DataAccess.DataAccess
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options) 
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sales> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Desktops" },
                new Category { Id = 2, Name = "Printers" },
                new Category { Id = 3, Name = "Display Tables" }
            );

            modelBuilder.Entity<Product>()
                .Property(p => p.ID)
                .ValueGeneratedNever();

            modelBuilder.Entity<Product>().HasData(
                new Product { ID = 1, Name = "HP PRo", CategoryID = 1, description = "Big desktop PC", Price = 892.99f },
                new Product { ID = 2, Name = "Dell X100", CategoryID = 1, description = "Not a laptop", Price = 140.99f },
                new Product { ID = 3, Name = "HP 450x", CategoryID = 2, description = "bad colour printer", Price = 1200.99f },
                new Product { ID = 4, Name = "HP Meezie", CategoryID = 2, description = "Good colour printer", Price = 12500.99f },
                new Product { ID = 5, Name = "Gala Table", CategoryID = 3, description = "Very Big Table", Price = 12123.99f },
                new Product { ID = 6, Name = "DreamTop", CategoryID = 3, description = "Big Table", Price = 900.99f }

            );

            modelBuilder.Entity<Sales>()
                .Property(s => s.Id)
                .ValueGeneratedNever();

            var salesData = new List<Sales>();
            int id = 1;

            var startDate = new DateTime(2024, 1, 1);

            for (int productId = 1; productId <= 6; productId++)
            {
                decimal baseSales = 1000 + (productId * 200);

                for (int i = 0; i < 12; i++)
                {
                    var date = startDate.AddMonths(i);

                    salesData.Add(new Sales
                    {
                        Id = id++,
                        ProductID = productId,
                        MonthName = date,
                        SalesAmount = baseSales + (i * 100)
                    });
                }
            }

            modelBuilder.Entity<Sales>().HasData(salesData);
        

        }
    }
}
