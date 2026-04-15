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
            modelBuilder.Entity<Category>()
                .HasData(
                new Category { Id = 1, Name = "Mystery" },
                new Category { Id = 2, Name = "Thriller" });

            modelBuilder.Entity<Product>()
                .HasData(
                new Product { ID = 1, Name = "Hamnet", Image = @"\Images\Products\Book2.webp", Price = 10, description = "Hamnet tells the story of a boy whose life has been all but forgotten, but whose name was given to one of the most celebrated plays ever written. It is also the story of a marriage, of a couple brought together by love and curiosity, and pulled apart by grief. Inspired by the son Shakespeare lost, Maggie O’Farrell’s breathtaking novel is a luminous portrait of a family and a tender exploration of how art can emerge from sorrow.", CategoryID = 1 },
                new Product { ID = 2, Name = "In Glass Houses", Image = @"\Images\Products\Book1.jpg", Price = 12, description = "When everyone is looking in, a killer can only hide in plain sight Eddie has always known that the wrong man was made the scapegoat for Juliet's murder. So when a new luxury sky-rise is opened by Juliet's father, just metres from where her body was discovered two decades before, Eddie can't resist finding her way in, back into a world where dangerous people operate in the shadows, and anyone might kill to keep a secret safe.", CategoryID = 2 });

            modelBuilder.Entity<Sales>()
                .HasData(
                new Sales { Id = 1, MonthName = "Jan", SalesAmount = 53, ProductID = 1 },
                new Sales { Id = 2, MonthName = "Feb", SalesAmount = 29, ProductID = 1 },
                new Sales { Id = 3, MonthName = "Mar", SalesAmount = 92, ProductID = 1 },
                new Sales { Id = 4, MonthName = "Apr", SalesAmount = 79, ProductID = 1 },
                new Sales { Id = 5, MonthName = "May", SalesAmount = 63, ProductID = 1 },
                new Sales { Id = 6, MonthName = "Jun", SalesAmount = 32, ProductID = 1 },
                new Sales { Id = 7, MonthName = "Jul", SalesAmount = 5, ProductID = 1 },
                new Sales { Id = 8, MonthName = "Aug", SalesAmount = 89, ProductID = 1 },
                new Sales { Id = 9, MonthName = "Sep", SalesAmount = 29, ProductID = 1 },
                new Sales { Id = 10, MonthName = "Oct", SalesAmount = 41, ProductID = 1 },
                new Sales { Id = 11, MonthName = "Nov", SalesAmount = 84, ProductID = 1 },
                new Sales { Id = 12, MonthName = "Dec", SalesAmount = 46, ProductID = 1 });


        }

    }
}
