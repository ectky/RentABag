using RentABag.Models;
using RentABag.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.Services.Contracts
{
    public interface IDesignersService
    {
        Task<int> CreateDesignerAsync(CreateDesignerViewModel vm);
        Designer GetDesignerById(int id);
        Task<int> EditDesignerAsync(CreateDesignerViewModel vm, Designer designer);
        void DeleteDesignerAsync(Designer designer);
        IQueryable<DesignerViewModel> GetAllDesigners();
        bool ExistsDesignerWithId(int id);
    }
}
