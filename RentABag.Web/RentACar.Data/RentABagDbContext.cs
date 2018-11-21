using System;
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

        public RentABagDbContext(DbContextOptions<RentABagDbContext> options)
            : base(options)
        {
        }
    }
}
