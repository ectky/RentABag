using RentABag.Models;
using RentABag.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.ViewModels
{
    public class IdAndNameViewModel : IMapTo<Category>, IMapTo<Designer>, IMapTo<Shop>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
