using RentABag.Models;
using RentABag.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentABag.Services.Common
{
    public interface IBagsService
    {
        Task<int> CreateBagAsync(CreateBagOtherViewModel vm);
        Bag GetBagById(int id);
        Task<int> EditBagAsync(CreateBagOtherViewModel vm, Bag bag);
        void DeleteBagAsync(Bag bag);
        ICollection<BagViewModel> GetAllBags();
        Bag GetDealOfTheWeek();
        ICollection<Bag> GetBestSellers(int count);
        ICollection<Bag> GetBagsForPage(int page);
        int GetPages();
    }
}
