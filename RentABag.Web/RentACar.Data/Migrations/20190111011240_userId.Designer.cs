﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentABag.Web.Data;

namespace RentABag.Data.Migrations
{
    [DbContext(typeof(RentABagDbContext))]
    [Migration("20190111011240_userId")]
    partial class userId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("RentABag.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActualAddress");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<int?>("OrderId");

                    b.Property<string>("PostCode");

                    b.Property<int?>("ShopId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .IsUnique()
                        .HasFilter("[OrderId] IS NOT NULL");

                    b.HasIndex("ShopId")
                        .IsUnique()
                        .HasFilter("[ShopId] IS NOT NULL");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("RentABag.Models.Bag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<int>("CollectionId");

                    b.Property<string>("Description");

                    b.Property<int>("DesignerId");

                    b.Property<decimal>("DiscountPercent");

                    b.Property<byte[]>("Image");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CollectionId");

                    b.HasIndex("DesignerId");

                    b.ToTable("Bags");
                });

            modelBuilder.Entity("RentABag.Models.BagOrder", b =>
                {
                    b.Property<int>("BagId");

                    b.Property<int>("OrderId");

                    b.Property<DateTime>("GetDate");

                    b.Property<int>("RentalDays");

                    b.Property<DateTime>("ReturnDate");

                    b.HasKey("BagId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("BagOrders");
                });

            modelBuilder.Entity("RentABag.Models.BagShop", b =>
                {
                    b.Property<int>("BagId");

                    b.Property<int>("ShopId");

                    b.HasKey("BagId", "ShopId");

                    b.HasIndex("ShopId");

                    b.ToTable("BagShops");
                });

            modelBuilder.Entity("RentABag.Models.Cart", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BagId");

                    b.Property<string>("CartId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("GetDate");

                    b.Property<int>("RentalDays");

                    b.Property<DateTime>("ReturnDate");

                    b.HasKey("RecordId");

                    b.HasIndex("BagId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("RentABag.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("RentABag.Models.Collection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("RentABag.Models.Designer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<byte[]>("Image");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Designers");
                });

            modelBuilder.Entity("RentABag.Models.DiscountCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<decimal>("DiscountPercent");

                    b.HasKey("Id");

                    b.ToTable("DiscountCodes");
                });

            modelBuilder.Entity("RentABag.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("RentABag.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId");

                    b.Property<int?>("DiscountCodeId");

                    b.Property<int?>("ShopId");

                    b.Property<int>("Status");

                    b.Property<decimal>("Total");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("DiscountCodeId");

                    b.HasIndex("ShopId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("RentABag.Models.RentABagUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<int>("AddressId");

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("RentABag.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BagId");

                    b.Property<string>("Comment");

                    b.Property<int?>("DesignerId");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<int>("Rating");

                    b.Property<DateTime>("ReviewedOn");

                    b.Property<int?>("ShopId");

                    b.HasKey("Id");

                    b.HasIndex("BagId");

                    b.HasIndex("DesignerId");

                    b.HasIndex("ShopId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("RentABag.Models.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId");

                    b.Property<string>("Description");

                    b.Property<decimal>("DiscountPercent");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RentABag.Models.RentABagUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RentABag.Models.RentABagUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RentABag.Models.RentABagUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RentABag.Models.RentABagUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RentABag.Models.Address", b =>
                {
                    b.HasOne("RentABag.Models.Order", "Order")
                        .WithOne("Address")
                        .HasForeignKey("RentABag.Models.Address", "OrderId");

                    b.HasOne("RentABag.Models.Shop", "Shop")
                        .WithOne("Address")
                        .HasForeignKey("RentABag.Models.Address", "ShopId");

                    b.HasOne("RentABag.Models.RentABagUser", "User")
                        .WithOne("Address")
                        .HasForeignKey("RentABag.Models.Address", "UserId");
                });

            modelBuilder.Entity("RentABag.Models.Bag", b =>
                {
                    b.HasOne("RentABag.Models.Category", "Category")
                        .WithMany("Bags")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RentABag.Models.Collection", "Collection")
                        .WithMany("Bags")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RentABag.Models.Designer", "Designer")
                        .WithMany("Bags")
                        .HasForeignKey("DesignerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RentABag.Models.BagOrder", b =>
                {
                    b.HasOne("RentABag.Models.Bag", "Bag")
                        .WithMany("BagOrders")
                        .HasForeignKey("BagId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RentABag.Models.Order", "Order")
                        .WithMany("BagOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RentABag.Models.BagShop", b =>
                {
                    b.HasOne("RentABag.Models.Bag", "Bag")
                        .WithMany("BagShops")
                        .HasForeignKey("BagId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RentABag.Models.Shop", "Shop")
                        .WithMany("BagShops")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RentABag.Models.Cart", b =>
                {
                    b.HasOne("RentABag.Models.Bag", "Bag")
                        .WithMany()
                        .HasForeignKey("BagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RentABag.Models.Order", b =>
                {
                    b.HasOne("RentABag.Models.DiscountCode", "DiscountCode")
                        .WithMany()
                        .HasForeignKey("DiscountCodeId");

                    b.HasOne("RentABag.Models.Shop", "Shop")
                        .WithMany()
                        .HasForeignKey("ShopId");

                    b.HasOne("RentABag.Models.RentABagUser", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("RentABag.Models.Review", b =>
                {
                    b.HasOne("RentABag.Models.Bag", "Bag")
                        .WithMany("Reviews")
                        .HasForeignKey("BagId");

                    b.HasOne("RentABag.Models.Designer")
                        .WithMany("Reviews")
                        .HasForeignKey("DesignerId");

                    b.HasOne("RentABag.Models.Shop", "Shop")
                        .WithMany("Reviews")
                        .HasForeignKey("ShopId");
                });
#pragma warning restore 612, 618
        }
    }
}
