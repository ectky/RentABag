﻿using RentABag.Models;
using RentABag.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.ViewModels
{
    public class ReviewViewModel : IMapTo<Review>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime ReviewedOn { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }

        public int? BagId { get; set; }
    }
}