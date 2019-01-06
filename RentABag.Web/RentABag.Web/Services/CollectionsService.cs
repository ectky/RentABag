using RentABag.Models;
using RentABag.Services.Mapping;
using RentABag.Web.Data;
using RentABag.Web.Services.Contracts;
using RentABag.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.Services
{
    public class CollectionsService : ICollectionsService
    {
        private readonly RentABagDbContext context;

        public CollectionsService(RentABagDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateCollectionAsync(CreateCollectionViewModel vm)
        {
            var collection = new Collection()
            {
                Name = vm.Name,
                StartDate = vm.StartDate,
                EndDate = vm.EndDate,
                Bags = new List<Bag>()
            };

            await this.context.Collections.AddAsync(collection);
            await this.context.SaveChangesAsync();

            int collectionId = collection.Id;

            return collectionId;
        }
        
        public async void DeleteCollectionAsync(Collection collection)
        {
            this.context.Remove(collection);
            await this.context.SaveChangesAsync();
        }

        public async Task<int> EditCollectionAsync(CreateCollectionViewModel vm, Collection collection)
        {
            this.context.Attach(collection);

            collection.Name = vm.Name;
            collection.StartDate = vm.StartDate;
            collection.EndDate = vm.EndDate;

            await this.context.SaveChangesAsync();

            return collection.Id;
        }

        public bool ExistsCollectionWithId(int id)
        {
            return this.context.Collections.Any(d => d.Id == id);
        }

        public IQueryable<CollectionViewModel> GetAllCollections()
        {
            var collections = this.context.Collections
                .To<CollectionViewModel>();

            return collections;
        }
        
        public Collection GetCollectionById(int id)
        {
            var collection = this.context.Collections.FirstOrDefault(d => d.Id == id);

            return collection;
        }

        public Collection GetCurrentCollection()
        {
            var dateTimeNow = DateTime.Now;
            var collection = this.context.Collections.FirstOrDefault(c =>
                c.StartDate < dateTimeNow && c.EndDate > dateTimeNow);

            return collection;
        }
    }
}
