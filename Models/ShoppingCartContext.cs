using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Models
{
    public class ShoppingCartContext : DbContext
    {
        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options) : base(options)
        {
            
        }

        public DbSet<ShoppingDetail> ShoppingDetails { get; set; }

        public DbSet<Cart> Cart { get; set; }
        public IQueryable<ShoppingDetail> ShoppingDetail { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingDetail>().HasData(
                new ShoppingDetail()
                {
                    Id = 1,
                    ItemName = "IPhoneXS",
                    Price = 30,
                    Description = "Solid phone",
                    ImageUrl = "https://cdn.shopify.com/s/files/1/0250/3793/0580/products/1_d539c0ca-7985-4c86-b8db-847074480619_1024x1024@2x.png?v=1558174602",
                    CategoryId = 1,
                    InStock = 5,
                    Quantity = 0,
                    Total = 0
                });

            modelBuilder.Entity<ShoppingDetail>().HasData(
                new ShoppingDetail()
                {
                    Id = 2,
                    ItemName = "AMD Ryzen 7 1700",
                    Price = 286,
                    Description = "Solid processor",
                    ImageUrl = "https://cdn.shopify.com/s/files/1/0250/3793/0580/products/1_d539c0ca-7985-4c86-b8db-847074480619_1024x1024@2x.png?v=1558174602",
                    CategoryId = 2,
                    InStock = 5,
                    Quantity = 0,
                    Total = 0
                });

            modelBuilder.Entity<ShoppingDetail>().HasData(
                new ShoppingDetail()
                {
                    Id = 3,
                    ItemName = "ACER Laptop",
                    Price = 286,
                    Description = "Solid laptop",
                    ImageUrl = "https://cdn.shopify.com/s/files/1/0250/3793/0580/products/1_d539c0ca-7985-4c86-b8db-847074480619_1024x1024@2x.png?v=1558174602",
                    CategoryId = 3,
                    InStock = 5,
                    Quantity = 0,
                    Total = 0
                });

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    CategoryId = 1,
                    Categories = "Mobile"
                });

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    CategoryId = 2,
                    Categories = "Processor"
                });

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    CategoryId = 3,
                    Categories = "Laptop"
                });
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cart>().HasData(
                new Cart()
                {
                    CartId = 1,
                    Qty = 1,
                    ProductId = 1
                });
            base.OnModelCreating(modelBuilder);
        }

    }
}
