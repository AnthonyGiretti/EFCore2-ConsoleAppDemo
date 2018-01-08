using ConsoleAppEFCore2.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace ConsoleAppEFCore2
{
    public class AdventureWorksContextDI : DbContext
    {
        public virtual DbSet<WorkOrder> WorkOrders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Person> Persons { get; set; }

        [DbFunction("ufnGetStock","dbo")]
        public static int GetProductStock(int productId)
        {
            throw new NotImplementedException();
        }

        public AdventureWorksContextDI(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Production");
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductDetailConfiguration());
            modelBuilder.ApplyConfiguration(new WorkOrderConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }

    public class AdventureWorksContext : DbContext
    {
        public virtual DbSet<WorkOrder> WorkOrders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Person> Persons { get; set; }

        [DbFunction("ufnGetStock", "dbo")]
        public static int GetProductStock(int productId)
        {
            throw new NotImplementedException();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@const.connectionString);

            var lf = new LoggerFactory();
            lf.AddProvider(new MyLoggerProvider());
            optionsBuilder.UseLoggerFactory(lf);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Production");
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductDetailConfiguration());
            modelBuilder.ApplyConfiguration(new WorkOrderConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        
    }

}

