using AutoMapper;
using RentABag.Models;
using RentABag.Services.Common;
using RentABag.Services.Mapping;
using RentABag.ViewModels;
using RentABag.Web.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.Services.Administrator
{
    public class CollectionsService : ICollectionsService
    {
        private readonly RentABagDbContext context;

        public CollectionsService(RentABagDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateCollectionAsync(CreateCollectionOtherViewModel vm)
        {
            var collection = Mapper.Map<CreateCollectionOtherViewModel, Collection>(vm);

            await context.Collections.AddAsync(collection);
            await context.SaveChangesAsync();

            int collectionId = collection.Id;

            return collectionId;
        }

        public async void DeleteCollectionAsync(Collection collection)
        {
            context.Remove(collection);
            await context.SaveChangesAsync();
        }

        public async Task<int> EditCollectionAsync(CreateCollectionOtherViewModel vm, Collection collection)
        {
            context.Attach(collection);

            collection.Name = vm.Name;
            collection.StartDate = vm.StartDate;
            collection.EndDate = vm.EndDate;

            await context.SaveChangesAsync();

            return collection.Id;
        }

        public bool ExistsCollectionWithId(int id)
        {
            return context.Collections.Any(d => d.Id == id);
        }

        public IQueryable<CollectionViewModel> GetAllCollections()
        {
            var collections = context.Collections
                .To<CollectionViewModel>();

            return collections;
        }

        public Collection GetCollectionById(int id)
        {
            var collection = context.Collections.FirstOrDefault(d => d.Id == id);

            return collection;
        }

        public Collection GetCurrentCollection()
        {
            var dateTimeNow = DateTime.Now;
            var collection = context.Collections.FirstOrDefault(c =>
                c.StartDate < dateTimeNow && c.EndDate > dateTimeNow);

            return collection;
        }
    }
}
