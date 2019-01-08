﻿using RentABag.Models;
using RentABag.Services.Common;
using RentABag.Services.Mapping;
using RentABag.ViewModels;
using RentABag.Web.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.Services.Administrator
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

            await context.Designers.AddAsync(designer);
            await context.SaveChangesAsync();

            int designerId = designer.Id;

            return designerId;
        }

        public async void DeleteDesignerAsync(Designer designer)
        {
            context.Remove(designer);
            await context.SaveChangesAsync();
        }

        public async Task<int> EditDesignerAsync(CreateDesignerViewModel vm, Designer designer)
        {
            context.Attach(designer);

            designer.Name = vm.Name;
            designer.Description = vm.Description;
            //designer.Image = vm.Image;

            await context.SaveChangesAsync();

            return designer.Id;
        }

        public bool ExistsDesignerWithId(int id)
        {
            return context.Designers.Any(d => d.Id == id);
        }

        public IQueryable<DesignerViewModel> GetAllDesigners()
        {
            var designers = context.Designers
                .To<DesignerViewModel>();

            return designers;
        }

        public Designer GetDesignerById(int id)
        {
            var designer = context.Designers.FirstOrDefault(d => d.Id == id);

            return designer;
        }
    }
}
