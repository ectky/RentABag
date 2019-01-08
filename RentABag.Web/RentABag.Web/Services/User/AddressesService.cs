using RentABag.Models;
using RentABag.Services.Common;
using RentABag.Web.Data;
using System.Linq;

namespace RentABag.Web.Services.User
{
    public class AddressesService : IAddressesService
    {
        private readonly RentABagDbContext context;

        public AddressesService(RentABagDbContext context)
        {
            this.context = context;
        }

        public async void CreateAddressAsync(Address address)
        {
            await context.Addresses.AddAsync(address);
            await context.SaveChangesAsync();
        }

        public Address GetAddressById(int id)
        {
            var address = context.Addresses.FirstOrDefault(a => a.Id == id);

            return address;
        }
    }
}
