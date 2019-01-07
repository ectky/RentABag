using RentABag.Models;
using RentABag.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.Services.Contracts
{
    public interface IBagsService
    {
        Task<int> CreateBagAsync(CreateBagViewModel vm);
        Bag GetBagById(int id);
        Task<int> EditBagAsync(CreateBagViewModel vm, Bag bag);
        void DeleteBagAsync(Bag bag);
        ICollection<BagViewModel> GetAllBags();
        Bag GetDealOfTheWeek();
        ICollection<Bag> GetBestSellers(int count);
        ICollection<Bag> GetBagsForPage(int page);
        int GetPages();
    }
}
