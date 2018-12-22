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

        public void CreateAddress(Address address)
        {
            this.context.Addresses.Add(address);
            this.context.SaveChanges();
        }

        public Address GetAddressById(int id)
        {
            var address = this.context.Addresses.FirstOrDefault(a => a.Id == id);

            return address;
        }
    }
}
