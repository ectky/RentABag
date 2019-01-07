using RentABag.Models;
using RentABag.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Services.Common
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
