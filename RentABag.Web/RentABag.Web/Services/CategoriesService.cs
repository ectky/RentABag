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

        public int CreateCategory(CreateCategoryViewModel vm)
        {
            var category = new Category()
            {
                Description = vm.Description,
                Name = vm.Name
            };

            this.context.Categories.Add(category);
            this.context.SaveChanges();

            int categoryId = category.Id;

            return categoryId;
        }
        
        public void DeleteCategory(Category category)
        {
            this.context.Remove(category);
            this.context.SaveChanges();
        }

        public int EditCategory(CreateCategoryViewModel vm, Category category)
        {
            this.context.Attach(category);

            category.Name = vm.Name;
            category.Description = vm.Description;

            this.context.SaveChanges();

            return category.Id;
        }
        
        public ICollection<CategoryViewModel> GetAllCategories()
        {
            var categories = this.context.Categories
                .To<CategoryViewModel>()
                .ToList();

            return categories;
        }
        
        public Category GetCategoryById(int id)
        {
            var category = this.context.Categories.FirstOrDefault(d => d.Id == id);

            return category;
        }
    }
}
