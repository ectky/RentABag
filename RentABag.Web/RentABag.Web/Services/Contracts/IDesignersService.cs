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
        int CreateDesigner(CreateDesignerViewModel vm);
        Designer GetDesignerById(int id);
        int EditDesigner(CreateDesignerViewModel vm, Designer designer);
        void DeleteDesigner(Designer designer);
        ICollection<DesignerViewModel> GetAllDesigners();
    }
}
