using RentABag.Models;
using RentABag.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.Services.Contracts
{
    public interface IShopsService
    {
        int CreateShop(CreateShopViewModel vm);
        Shop GetShopById(int id);
        int EditShop(CreateShopViewModel vm, Shop shop);
        void DeleteShop(Shop shop);
        ICollection<ShopViewModel> GetAllShops();
    }
}
