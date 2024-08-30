using Microsoft.EntityFrameworkCore;
using ProductService.Api.Models;

namespace ProductService.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Label> Labels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region SeedData1 inaktif
            //// Price entity için Amount alanını configure ediyoruz
            //modelBuilder.Entity<Product>().OwnsOne(p => p.Price, p =>
            //{
            //    p.Property(price => price.Amount).HasColumnType("decimal(18,2)"); // 18 basamaklı, 2 ondalık
            //});

            //// Category Seed Data
            //modelBuilder.Entity<Category>().HasData(
            //    new Category { Id = 1, Name = "Technology" },
            //    new Category { Id = 2, Name = "Books" },
            //    new Category { Id = 3, Name = "Fashion" },
            //    new Category { Id = 4, Name = "Health" },
            //    new Category { Id = 5, Name = "Sports" }
            //);

            //// Product Seed Data with Owned Types for Price and Rating
            //modelBuilder.Entity<Product>().OwnsOne(p => p.Price).HasData(
            //    new { ProductId = 1, Amount = 99.99M, Currency = "USD" },
            //    new { ProductId = 2, Amount = 149.99M, Currency = "USD" },
            //    new { ProductId = 3, Amount = 89.99M, Currency = "USD" },
            //    new { ProductId = 4, Amount = 199.99M, Currency = "USD" },
            //    new { ProductId = 5, Amount = 59.99M, Currency = "USD" },
            //    new { ProductId = 6, Amount = 79.99M, Currency = "USD" },
            //    new { ProductId = 7, Amount = 129.99M, Currency = "USD" },
            //    new { ProductId = 8, Amount = 159.99M, Currency = "USD" },
            //    new { ProductId = 9, Amount = 99.99M, Currency = "USD" },
            //    new { ProductId = 10, Amount = 49.99M, Currency = "USD" },
            //    new { ProductId = 11, Amount = 139.99M, Currency = "USD" }
            //);

            //modelBuilder.Entity<Product>().OwnsOne(p => p.Rating).HasData(
            //    new { ProductId = 1, Stars = 4.5, Reviews = 10, Min = 0.0, Max = 5.0 },
            //    new { ProductId = 2, Stars = 4.0, Reviews = 20, Min = 0.0, Max = 5.0 },
            //    new { ProductId = 3, Stars = 4.8, Reviews = 5, Min = 0.0, Max = 5.0 },
            //    new { ProductId = 4, Stars = 4.2, Reviews = 30, Min = 0.0, Max = 5.0 },
            //    new { ProductId = 5, Stars = 3.8, Reviews = 40, Min = 0.0, Max = 5.0 },
            //    new { ProductId = 6, Stars = 4.6, Reviews = 12, Min = 0.0, Max = 5.0 },
            //    new { ProductId = 7, Stars = 4.9, Reviews = 18, Min = 0.0, Max = 5.0 },
            //    new { ProductId = 8, Stars = 4.7, Reviews = 22, Min = 0.0, Max = 5.0 },
            //    new { ProductId = 9, Stars = 4.4, Reviews = 25, Min = 0.0, Max = 5.0 },
            //    new { ProductId = 10, Stars = 3.9, Reviews = 35, Min = 0.0, Max = 5.0 },
            //    new { ProductId = 11, Stars = 4.5, Reviews = 20, Min = 0.0, Max = 5.0 }
            //);

            //// Seed for ColorOption entity
            //modelBuilder.Entity<ColorOption>().HasData(
            //    new ColorOption { Id = 1, ProductId = 1, Color = "Red", Img = "red.jpg", Quantity = 10 },
            //    new ColorOption { Id = 2, ProductId = 1, Color = "Blue", Img = "blue.jpg", Quantity = 15 },
            //    new ColorOption { Id = 3, ProductId = 2, Color = "Green", Img = "green.jpg", Quantity = 12 },
            //    new ColorOption { Id = 4, ProductId = 2, Color = "Yellow", Img = "yellow.jpg", Quantity = 8 },
            //    new ColorOption { Id = 5, ProductId = 3, Color = "Black", Img = "black.jpg", Quantity = 20 },
            //    new ColorOption { Id = 6, ProductId = 4, Color = "White", Img = "white.jpg", Quantity = 25 },
            //    new ColorOption { Id = 7, ProductId = 4, Color = "Black", Img = "black.jpg", Quantity = 10 },
            //    new ColorOption { Id = 8, ProductId = 5, Color = "Red", Img = "red.jpg", Quantity = 5 },
            //    new ColorOption { Id = 9, ProductId = 5, Color = "Blue", Img = "blue.jpg", Quantity = 8 },
            //    new ColorOption { Id = 10, ProductId = 6, Color = "Blue", Img = "blue.jpg", Quantity = 15 },
            //    new ColorOption { Id = 11, ProductId = 6, Color = "Green", Img = "green.jpg", Quantity = 7 },
            //    new ColorOption { Id = 12, ProductId = 7, Color = "Yellow", Img = "yellow.jpg", Quantity = 10 },
            //    new ColorOption { Id = 13, ProductId = 7, Color = "Purple", Img = "purple.jpg", Quantity = 5 },
            //    new ColorOption { Id = 14, ProductId = 8, Color = "Orange", Img = "orange.jpg", Quantity = 9 },
            //    new ColorOption { Id = 15, ProductId = 8, Color = "White", Img = "white.jpg", Quantity = 15 },
            //    new ColorOption { Id = 16, ProductId = 9, Color = "Black", Img = "black.jpg", Quantity = 30 },
            //    new ColorOption { Id = 17, ProductId = 9, Color = "Red", Img = "red.jpg", Quantity = 12 },
            //    new ColorOption { Id = 18, ProductId = 10, Color = "Blue", Img = "blue.jpg", Quantity = 18 },
            //    new ColorOption { Id = 19, ProductId = 11, Color = "Red", Img = "red.jpg", Quantity = 7 },
            //    new ColorOption { Id = 20, ProductId = 11, Color = "White", Img = "white.jpg", Quantity = 10 }
            //);

            #endregion  SeedData1

            #region SeedData2 aktif 

            modelBuilder.Entity<ProductLabel>()
                .HasKey(pl => new { pl.ProductId, pl.LabelId });



            //modelBuilder.Entity<Product>().OwnsOne(p => p.Price);
            //modelBuilder.Entity<Product>().OwnsOne(p => p.Rating);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Technology" },
                new Category { Id = 2, Name = "Books" },
                new Category { Id = 3, Name = "Fashion" },
                new Category { Id = 4, Name = "Health" },
                new Category { Id = 5, Name = "Sports" }
            );


            // Seed data for Product with owned types
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    CategoryId = 1,
                    Price = 149.99m,
                    Img = "img1.jpg",
                    HoverImg = "hoverImg1.jpg",
                    Title = "Product 1",
                    Description = "This is Product 1"
                },
                new Product
                {
                    Id = 2,
                    CategoryId = 2,
                    Price = 129.99m,
                    Img = "img2.jpg",
                    HoverImg = "hoverImg2.jpg",
                    Title = "Product 2",
                    Description = "This is Product 2"
                },
                new Product
                {
                    Id = 3,
                    CategoryId = 3,
                    Price = 249.99m,
                    Img = "img3.jpg",
                    HoverImg = "hoverImg3.jpg",
                    Title = "Product 3",
                    Description = "This is Product 3"
                },
                new Product
                {
                    Id = 4,
                    CategoryId = 4,
                    Price = 349.99m,
                    Img = "img4.jpg",
                    HoverImg = "hoverImg4.jpg",
                    Title = "Product 4",
                    Description = "This is Product 4"
                },
                new Product
                {
                    Id = 5,
                    CategoryId = 5,
                    Price = 149.99m,
                    Img = "img5.jpg",
                    HoverImg = "hoverImg5.jpg",
                    Title = "Product 5",
                    Description = "This is Product 5"
                }
            );

            // Seed data for Price


            // Seed data for Rating
            modelBuilder.Entity<Product>().OwnsOne(p => p.Rating).HasData(
                new
                {
                    ProductId = 1,
                    Stars = 4.5,
                    Reviews = 20,
                    Min = 0.0,
                    Max = 5.0
                },
                new
                {
                    ProductId = 2,
                    Stars = 4.0,
                    Reviews = 15,
                    Min = 0.0,
                    Max = 5.0
                },
                new
                {
                    ProductId = 3,
                    Stars = 4.8,
                    Reviews = 30,
                    Min = 0.0,
                    Max = 5.0
                },
                new
                {
                    ProductId = 4,
                    Stars = 3.5,
                    Reviews = 40,
                    Min = 0.0,
                    Max = 5.0
                },
                new
                {
                    ProductId = 5,
                    Stars = 4.2,
                    Reviews = 10,
                    Min = 0.0,
                    Max = 5.0
                }
            );

            // Seed data for ColorOption
            modelBuilder.Entity<ColorOption>().HasData(
                new ColorOption { Id = 1, ProductId = 1, Color = "Red", Img = "red1.jpg", Quantity = 5 },
                new ColorOption { Id = 2, ProductId = 1, Color = "Blue", Img = "blue1.jpg", Quantity = 10 },
                new ColorOption { Id = 3, ProductId = 2, Color = "Green", Img = "green2.jpg", Quantity = 8 },
                new ColorOption { Id = 4, ProductId = 3, Color = "Yellow", Img = "yellow3.jpg", Quantity = 15 },
                new ColorOption { Id = 5, ProductId = 4, Color = "Black", Img = "black4.jpg", Quantity = 7 },
                new ColorOption { Id = 6, ProductId = 5, Color = "White", Img = "white5.jpg", Quantity = 12 }
            );

            // Seed data for ProductLabel (if necessary)
            modelBuilder.Entity<ProductLabel>().HasData(
                new ProductLabel { ProductId = 1, LabelId = 1 },
                new ProductLabel { ProductId = 1, LabelId = 2 },
                new ProductLabel { ProductId = 2, LabelId = 1 },
                new ProductLabel { ProductId = 3, LabelId = 3 },
                new ProductLabel { ProductId = 4, LabelId = 2 },
                new ProductLabel { ProductId = 5, LabelId = 3 }
            );

            // Seed data for Label
            modelBuilder.Entity<Label>().HasData(
                new Label { Id = 1, Name = "New" },
                new Label { Id = 2, Name = "Sale" },
                new Label { Id = 3, Name = "Best Seller" }
            );

            #endregion





            base.OnModelCreating(modelBuilder);
        }

    }
}
