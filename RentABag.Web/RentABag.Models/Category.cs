using System;
using System.Collections.Generic;

namespace RentABag.Models
{
    public class Category
    {
        public Category()
        {
            this.Bags = new HashSet<Bag>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Bag> Bags { get; set; }
    }
}
