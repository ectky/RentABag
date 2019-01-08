using Microsoft.AspNetCore.Identity;
using RentABag.Models;
using RentABag.Services.Common;
using RentABag.Services.Mapping;
using RentABag.ViewModels;
using RentABag.Web.Data;
using RentABag.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.Services.Administrator
{
    public class UsersService : IUsersService
    {
        private readonly RentABagDbContext context;
        private readonly UserManager<RentABagUser> userManager;

        public UsersService(RentABagDbContext context, UserManager<RentABagUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task DeAdministrateAsync(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new InvalidOperationException("User with this id does not exist");
            }

            await userManager.RemoveFromRoleAsync(user, Constants.administratorRole);

            await userManager.AddToRoleAsync(user, Constants.userRole);
        }

        public ICollection<RentABagUser> GetAllUsers()
        {
            var users = context.Users.ToArray();

            return users;
        }

        public async Task MakeAdministratorrAsync(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new InvalidOperationException("User with this id does not exist");
            }

            userManager.RemoveFromRoleAsync(user, Constants.userRole).Wait();
            userManager.AddToRoleAsync(user, Constants.administratorRole).Wait();

            var c = 5;
        }
    }
}
