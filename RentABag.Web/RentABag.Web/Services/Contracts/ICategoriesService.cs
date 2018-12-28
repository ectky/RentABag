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
        Task<int> CreateCategoryAsync(CreateCategoryViewModel vm);
        Category GetCategoryById(int id);
        Task<int> EditCategoryAsync(CreateCategoryViewModel vm, Category category);
        void DeleteCategoryAsync(Category category);
        IQueryable<CategoryViewModel> GetAllCategories();
        bool ExistsCategoryWithId(int id);
    }
}
