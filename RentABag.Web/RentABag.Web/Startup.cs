﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using RentABag.Models;
using RentABag.Services;
using RentABag.Services.Common;
using RentABag.Services.Mapping;
using RentABag.ViewModels;
using RentABag.Web.Data;
using RentABag.Web.Middlewares;
using System;
using System.IO;

namespace RentABag.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<RentABagDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<RentABagUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = false;
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.DefaultLockoutTimeSpan = new TimeSpan(1, 0, 0, 0);
            })
                .AddEntityFrameworkStores<RentABagDbContext>()
                .AddRoles<IdentityRole>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            services.AddScoped<IUserClaimsPrincipalFactory<RentABagUser>
                , UserClaimsPrincipalFactory<RentABagUser,
            IdentityRole>>();

            services.AddSingleton<IFileProvider>(
                new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

            services.AddScoped<IAddressesService, AddressesService>();
            services.AddScoped<IDesignersService, DesignersService>();
            services.AddScoped<ICategoriesService, CategoriesService>();
            services.AddScoped<IShopsService, ShopsService>();
            services.AddScoped<IBagsService, BagsService>();
            services.AddScoped<ICollectionsService, CollectionsService>();
            services.AddScoped<IMessagesService, MessagesService>();
            services.AddScoped<IReviewsService, ReviewsService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<IDiscountCodesService, DiscountCodesService>();

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.Cookie.HttpOnly = true;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAuthentication()
                .AddFacebook(fbOptions =>
                {
                    fbOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                    fbOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                    fbOptions.Scope.Add("user_birthday");
                    fbOptions.Scope.Add("user_location");
                    fbOptions.Fields.Add("birthday");
                    fbOptions.Fields.Add("location");
                });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseSeeder();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute("areaRoute", "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
