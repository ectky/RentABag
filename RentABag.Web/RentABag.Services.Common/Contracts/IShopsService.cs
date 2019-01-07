using RentABag.Models;
using RentABag.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Services.Common
{
    public interface IShopsService
    {
        Task<int> CreateShopAsync(CreateShopViewModel vm);
        Shop GetShopById(int id);
        Task<int> EditShopAsync(CreateShopViewModel vm, Shop shop);
        void DeleteShopAsync(Shop shop);
        IQueryable<ShopViewModel> GetAllShops();
    }
}
