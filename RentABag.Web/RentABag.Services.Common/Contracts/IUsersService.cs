using RentABag.Models;
using RentABag.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentABag.Services.Common
{
    public interface IUsersService
    {
        ICollection<RentABagUser> GetAllUsers();

        Task DeAdministrateAsync(string userId);

        Task MakeAdministratorrAsync(string userId);
    }
}
