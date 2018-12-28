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
    public class DesignersService : IDesignersService
    {
        private readonly RentABagDbContext context;

        public DesignersService(RentABagDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateDesignerAsync(CreateDesignerViewModel vm)
        {
            var designer = new Designer()
            {
                Name = vm.Name,
                Description = vm.Description
            };

            await this.context.Designers.AddAsync(designer);
            await this.context.SaveChangesAsync();

            int designerId = designer.Id;

            return designerId;
        }

        public async void DeleteDesignerAsync(Designer designer)
        {
            this.context.Remove(designer);
            await this.context.SaveChangesAsync();
        }

        public async Task<int> EditDesignerAsync(CreateDesignerViewModel vm, Designer designer)
        {
            this.context.Attach(designer);

            designer.Name = vm.Name;
            designer.Description = vm.Description;
            designer.Image = vm.Image;

            await this.context.SaveChangesAsync();

            return designer.Id;
        }

        public bool ExistsDesignerWithId(int id)
        {
            return this.context.Designers.Any(d => d.Id == id);
        }

        public IQueryable<DesignerViewModel> GetAllDesigners()
        {
            var designers = this.context.Designers
                .To<DesignerViewModel>();

            return designers;
        }

        public Designer GetDesignerById(int id)
        {
            var designer = this.context.Designers.FirstOrDefault(d => d.Id == id);

            return designer;
        }
    }
}
