using GloiathNationalBank.Models;
using Microsoft.EntityFrameworkCore;


namespace GloiathNationalBank.Data
{
    public class GloiathNationalBankContext : DbContext
    {
        public GloiathNationalBankContext(DbContextOptions options) : base(options) { }


        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<CachedTransaction> CachedTransactions { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<ProductSummary> ProductSummaries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuraciones adicionales del modelo

            modelBuilder.Entity<Transaction>()
                        .Property(t => t.Id)
                        .ValueGeneratedOnAdd();  // Establecer un valor predeterminado de -1 para la propiedad Id de Transaction


            // Inicializar las tasas de conversión
            modelBuilder.Entity<Rate>().HasData(
               new Rate { Id = 1, From = "EUR", To = "USD", RateValue = 1.359m },
               new Rate { Id = 2, From = "CAD", To = "EUR", RateValue = 0.732m },
               new Rate { Id = 3, From = "USD", To = "EUR", RateValue = 0.736m },
               new Rate { Id = 4, From = "EUR", To = "CAD", RateValue = 1.366m }
            );

            // Inicializar las transacciones
            modelBuilder.Entity<Transaction>().HasData(
                new Transaction { Id = 1, Sku = "T2006", Amount = 10.00m, Currency = "USD" },
                new Transaction { Id = 2, Sku = "M2007", Amount = 34.57m, Currency = "CAD" },
                new Transaction { Id = 3, Sku = "R2008", Amount = 17.95m, Currency = "USD" },
                new Transaction { Id = 4, Sku = "T2006", Amount = 7.63m, Currency = "EUR" },
                new Transaction { Id = 5, Sku = "B2009", Amount = 21.23m, Currency = "USD" }
            );
      
        }
    }
}

