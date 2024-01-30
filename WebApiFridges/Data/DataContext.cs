using Microsoft.EntityFrameworkCore;
using WebApiFridges.Models;

namespace WebApiFridges.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }
        public DbSet<FridgeProducts> FridgeProducts { get; set; }
        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<FridgeModel> FridgeModels { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // FluentApi подход - конфигурация модели с помощью методов
        {
            // устанавливаю первичные ключи для каждой таблицы
            modelBuilder.Entity<Fridge>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<FridgeModel>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<FridgeProducts>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Product>()
                .HasKey(x => x.Id);

            // устанавливаю взаимоотношения и внешние ключи между парами
            modelBuilder.Entity<FridgeModel>()
            .HasMany(f => f.Fridges)
            .WithOne(fm => fm.FridgeModel)
            .HasForeignKey(fk => fk.ModelId);

            modelBuilder.Entity<Fridge>()
            .HasMany(fp => fp.FridgeProducts)
            .WithOne(f => f.Fridge)
            .HasForeignKey(fk => fk.FridgeId);

            modelBuilder.Entity<Product>()
            .HasMany(fp => fp.FridgeProducts)
            .WithOne(p => p.Products)
            .HasForeignKey(fk => fk.ProductId);

            // валидация данных
            modelBuilder.Entity<Fridge>(builder => {
                builder.Property(x => x.Name).IsRequired();
                builder.Property(x=>x.ModelId).IsRequired();
                builder.Property(x => x.Id).IsRequired().HasDefaultValueSql("NEWID()");
                builder.Property(x => x.OwnerName).IsRequired(false);
            });

            modelBuilder.Entity <FridgeModel>(builder => {
                builder.Property(x => x.Id).IsRequired().HasDefaultValueSql("NEWID()");
                builder.Property(x => x.Name).IsRequired();
                builder.Property(x => x.Year).IsRequired(false);
            });

            modelBuilder.Entity<FridgeProducts>(builder => {
                builder.Property(x => x.Id).IsRequired().HasDefaultValueSql("NEWID()");
                builder.Property(x => x.ProductId).IsRequired();
                builder.Property(x => x.FridgeId).IsRequired();
                builder.Property(x => x.Quantity).IsRequired();
            });

            modelBuilder.Entity<Product>(builder => {
                builder.Property(x => x.Id).IsRequired().HasDefaultValueSql("NEWID()");
                builder.Property(x => x.Name).IsRequired();
                builder.Property(x => x.DefaultQuantity).IsRequired(false);
            });
        }
    }
}
