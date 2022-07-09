using FoodsOnline.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodsOnline.API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }


        //Fluent API
        protected override void OnModelCreating(ModelBuilder model)
        {
            //Produto
            model.Entity<Product>().HasKey(c => c.ProductId);
            model.Entity<Product>().Property(c => c.Name).HasMaxLength(50).IsRequired();
            model.Entity<Product>().Property(c => c.Description).HasMaxLength(100).IsRequired();
            model.Entity<Product>().Property(c => c.Price).HasPrecision(12, 2);
            model.Entity<Product>().Property(c => c.ImagePath).HasMaxLength(255).IsRequired();


            //Categoria
            model.Entity<Category>().HasKey(c => c.CategoryId);
            model.Entity<Category>().Property(c => c.Name).HasMaxLength(100).IsRequired();
            model.Entity<Category>().HasMany(c => c.Products).WithOne(c => c.Category).IsRequired().OnDelete(DeleteBehavior.Cascade);


            //Carga Inicial
            model.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    Name = "Pizza Salgada"
                },
                 new Category
                 {
                     CategoryId = 2,
                     Name = "Pizza Doce"
                 },
                 new Category
                 {
                     CategoryId = 3,
                     Name = "Bebida"
                 }
            );
        }
    }
}
