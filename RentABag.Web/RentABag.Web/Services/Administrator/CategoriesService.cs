using RentABag.Models;
using RentABag.Services.Common;
using RentABag.Services.Mapping;
using RentABag.ViewModels;
using RentABag.Web.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.Services.Administrator
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

            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();

            int categoryId = category.Id;

            return categoryId;
        }

        public async void DeleteCategoryAsync(Category category)
        {
            context.Remove(category);
            await context.SaveChangesAsync();
        }

        public async Task<int> EditCategoryAsync(CreateCategoryViewModel vm, Category category)
        {
            context.Attach(category);

            category.Name = vm.Name;
            category.Description = vm.Description;

            await context.SaveChangesAsync();

            return category.Id;
        }

        public bool ExistsCategoryWithId(int id)
        {
            return context.Categories.Any(d => d.Id == id);
        }

        public IQueryable<CategoryViewModel> GetAllCategories()
        {
            var categories = context.Categories
                .To<CategoryViewModel>();

            return categories;
        }

        public Category GetCategoryById(int id)
        {
            var category = context.Categories.FirstOrDefault(d => d.Id == id);

            return category;
        }
    }
}
