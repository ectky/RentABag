using RentABag.Models;
using RentABag.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.Services
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
            await this.context.Addresses.AddAsync(address);
            await this.context.SaveChangesAsync();
        }

        public Address GetAddressById(int id)
        {
            var address = this.context.Addresses.FirstOrDefault(a => a.Id == id);

            return address;
        }
    }
}
