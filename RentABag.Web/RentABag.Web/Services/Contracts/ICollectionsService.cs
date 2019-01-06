using RentABag.Models;
using RentABag.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.Services.Contracts
{
    public interface ICollectionsService
    {
        Task<int> CreateCollectionAsync(CreateCollectionViewModel vm);
        Collection GetCollectionById(int id);
        Task<int> EditCollectionAsync(CreateCollectionViewModel vm, Collection collection);
        void DeleteCollectionAsync(Collection collection);
        IQueryable<CollectionViewModel> GetAllCollections();
        bool ExistsCollectionWithId(int id);
        Collection GetCurrentCollection();
    }
}
