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

        public int CreateDesigner(CreateDesignerViewModel vm)
        {
            var designer = new Designer()
            {
                FullName = vm.FullName,
                Description = vm.Description
            };

            this.context.Designers.Add(designer);
            this.context.SaveChanges();

            int designerId = designer.Id;

            return designerId;
        }

        public void DeleteDesigner(Designer designer)
        {
            this.context.Remove(designer);
            this.context.SaveChanges();
        }

        public int EditDesigner(CreateDesignerViewModel vm, Designer designer)
        {
            this.context.Attach(designer);

            designer.FullName = vm.FullName;
            designer.Description = vm.Description;
            designer.Image = vm.Image;

            this.context.SaveChanges();

            return designer.Id;
        }

        public bool ExistsDesignerWithId(int id)
        {
            return this.context.Designers.Any(d => d.Id == id);
        }

        public ICollection<DesignerViewModel> GetAllDesigners()
        {
            var designers = this.context.Designers
                .To<DesignerViewModel>()
                .ToList();

            return designers;
        }

        public Designer GetDesignerById(int id)
        {
            var designer = this.context.Designers.FirstOrDefault(d => d.Id == id);

            return designer;
        }
    }
}
