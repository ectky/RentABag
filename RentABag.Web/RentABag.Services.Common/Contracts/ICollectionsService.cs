using RentABag.Models;
using RentABag.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Services.Common
{
    public interface ICollectionsService
    {
        Task<int> CreateCollectionAsync(CreateCollectionOtherViewModel vm);
        Collection GetCollectionById(int id);
        Task<int> EditCollectionAsync(CreateCollectionOtherViewModel vm, Collection collection);
        void DeleteCollectionAsync(Collection collection);
        IQueryable<CollectionViewModel> GetAllCollections();
        bool ExistsCollectionWithId(int id);
        Collection GetCurrentCollection();
    }
}
