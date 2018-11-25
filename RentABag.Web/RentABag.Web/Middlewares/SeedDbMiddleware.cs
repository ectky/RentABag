using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using RentABag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.Middlewares
{
    public class SeedDbMiddleware
    {
        private readonly RequestDelegate next;

        public SeedDbMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IServiceProvider provider)
        {
            RoleManager<IdentityRole> roleManager = (RoleManager<IdentityRole>)provider.GetService(typeof(RoleManager<IdentityRole>));

            UserManager<RentABagUser> userManager = (UserManager<RentABagUser>)provider.GetService(typeof(UserManager<RentABagUser>));

            var adminRoleExists = roleManager.RoleExistsAsync("Administrator").GetAwaiter().GetResult();
            if (!adminRoleExists)
            {
                roleManager.CreateAsync(new IdentityRole("Administrator")).GetAwaiter().GetResult();
            }
            var userRoleExists = roleManager.RoleExistsAsync("User").GetAwaiter().GetResult();
            if (!userRoleExists)
            {
                roleManager.CreateAsync(new IdentityRole("User")).GetAwaiter().GetResult();
            }

            if (!userManager.Users.Any())
            {
                var address = new Address
                {
                    Country = "Bulgaria",
                    City = "Dimitrovgrad",
                    PostCode = "6900",
                    ActualAddress = "Admin address"
                };

                var user = new RentABagUser
                {
                    UserName = "admin",
                    Email = "admin@rentabag.com",
                    FullName = "Admin Admin",
                    Birthday = new DateTime(1999,11,11),
                    Address = address
                };

                var result = userManager.CreateAsync(user, "123456").GetAwaiter().GetResult();
                userManager.AddToRoleAsync(user, "Administrator").GetAwaiter().GetResult();
            }

            await this.next(httpContext);
        }
    }
}
