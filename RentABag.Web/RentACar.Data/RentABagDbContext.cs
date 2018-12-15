﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentABag.Models;

namespace RentABag.Web.Data
{
    public class RentABagDbContext : IdentityDbContext<RentABagUser>
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Bag> Bags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Designer> Designers { get; set; }
        public DbSet<DiscountCode> DiscountCodes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<BagShop> BagShops { get; set; }

        public RentABagDbContext(DbContextOptions<RentABagDbContext> options)
            : base(options)
        {
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BagShop>()
                .HasKey(x => new { x.BagId, x.ShopId });

            modelBuilder.Entity<BagShop>()
                .HasOne(x => x.Bag)
                .WithMany(x => x.BagShops)
                .HasForeignKey(x => x.BagId);

            modelBuilder.Entity<BagShop>()
                .HasOne(x => x.Shop)
                .WithMany(x => x.BagShops)
                .HasForeignKey(x => x.ShopId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
