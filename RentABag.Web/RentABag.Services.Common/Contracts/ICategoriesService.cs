using RentABag.Models;
using RentABag.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Services.Common
{
    public interface ICategoriesService
    {
        Task<int> CreateCategoryAsync(CreateCategoryViewModel vm);
        Category GetCategoryById(int id);
        Task<int> EditCategoryAsync(CreateCategoryViewModel vm, Category category);
        void DeleteCategoryAsync(Category category);
        IQueryable<CategoryViewModel> GetAllCategories();
        bool ExistsCategoryWithId(int id);
    }
}
