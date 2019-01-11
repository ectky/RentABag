using Microsoft.EntityFrameworkCore;
using RentABag.Web.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentABag.Services.Tests
{
    public static class StaticMethods
    {
        public static RentABagDbContext GetDb()
        {
            var dbOptions = new DbContextOptionsBuilder<RentABagDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var dbContext = new RentABagDbContext(dbOptions);
            return dbContext;
        }
    }
}
