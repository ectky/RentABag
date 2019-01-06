using System;
using System.Collections.Generic;
using System.Text;

namespace RentABag.Models
{
    public class Collection
    {
        public Collection()
        {
            this.Bags = new HashSet<Bag>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual ICollection<Bag> Bags { get; set; }
    }
}
