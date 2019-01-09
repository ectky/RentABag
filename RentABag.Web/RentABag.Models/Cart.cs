using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RentABag.Models
{
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }

        public string CartId { get; set; }

        public DateTime DateCreated { get; set; }

        public int BagId { get; set; }

        public virtual Bag Bag { get; set; }

        public DateTime GetDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public int RentalDays { get; set; }
    }
}
