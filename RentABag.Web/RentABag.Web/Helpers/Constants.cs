using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.Helpers
{
    public static class Constants
    {
        public const string homeControllerName = "Home";
        public const string userRole = "User";
        public const string administratorRole = "Administrator";
        public const string errorName = "Error";
        public const string detailsName = "Details";
        public const string bagName = "Bag";
        public const string categoryName = "Category";
        public const string designerName = "Designer";
        public const string collectionName = "Collection";
        public const string shopName = "Shop";
        public const string defaultName = "default";
        public const string successfulMessage = "Your message was sent successfully.";
        public const string bagDetails = "/" + bagName + "/" + detailsName;
        public const string shopDetails = "/" + shopName + "/" + detailsName;
        public const string designerDetails = "/" + designerName + "/" + detailsName;
        public const string categoryDetails = "/" + categoryName + "/" + detailsName;
    }
}
