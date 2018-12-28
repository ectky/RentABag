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
    public class CategoriesService : ICategoriesService
    {
        private readonly RentABagDbContext context;

        public CategoriesService(RentABagDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateCategoryAsync(CreateCategoryViewModel vm)
        {
            var category = new Category()
            {
                Description = vm.Description,
                Name = vm.Name
            };

            await this.context.Categories.AddAsync(category);
            await this.context.SaveChangesAsync();

            int categoryId = category.Id;

            return categoryId;
        }
        
        public async void DeleteCategoryAsync(Category category)
        {
            this.context.Remove(category);
            await this.context.SaveChangesAsync();
        }

        public async Task<int> EditCategoryAsync(CreateCategoryViewModel vm, Category category)
        {
            this.context.Attach(category);

            category.Name = vm.Name;
            category.Description = vm.Description;

            await this.context.SaveChangesAsync();

            return category.Id;
        }

        public bool ExistsCategoryWithId(int id)
        {
            return this.context.Categories.Any(d => d.Id == id);
        }

        public IQueryable<CategoryViewModel> GetAllCategories()
        {
            var categories = this.context.Categories
                .To<CategoryViewModel>();

            return categories;
        }
        
        public Category GetCategoryById(int id)
        {
            var category = this.context.Categories.FirstOrDefault(d => d.Id == id);

            return category;
        }
    }
}
