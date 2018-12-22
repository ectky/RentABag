using RentABag.Models;
using RentABag.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.Services.Contracts
{
    public interface ICategoriesService
    {
        int CreateCategory(CreateCategoryViewModel vm);
        Category GetCategoryById(int id);
        int EditCategory(CreateCategoryViewModel vm, Category category);
        void DeleteCategory(Category category);
        ICollection<CategoryViewModel> GetAllCategories();
    }
}
