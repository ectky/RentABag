using RentABag.Models;

namespace RentABag.Services.Common
{
    public interface IAddressesService
    {
        void CreateAddressAsync(Address address);
        Address GetAddressById(int id);
    }
}
