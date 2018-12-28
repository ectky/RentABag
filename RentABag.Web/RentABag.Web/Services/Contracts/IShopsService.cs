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
        Task<int> CreateShopAsync(CreateShopViewModel vm);
        Shop GetShopById(int id);
        Task<int> EditShopAsync(CreateShopViewModel vm, Shop shop);
        void DeleteShopAsync(Shop shop);
        IQueryable<ShopViewModel> GetAllShops();
    }
}
