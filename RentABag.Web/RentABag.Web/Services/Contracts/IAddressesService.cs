using RentABag.Models;
using RentABag.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.Services
{
    public interface IAddressesService
    {
        void CreateAddressAsync(Address address);
        Address GetAddressById(int id);
    }
}
