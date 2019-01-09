using System;
using System.Collections.Generic;
using System.Text;

namespace RentABag.ViewModels
{
    public class CreateCartViewModel
    {
        public int Id { get; set; }

        public DateTime GetDate { get; set; }

        public DateTime ReturnDate { get; set; }
    }
}
