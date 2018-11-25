using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.Middlewares
{
    public static class SeedDbMidlewareExtensions
    {
        public static IApplicationBuilder UseSeeder(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SeedDbMiddleware>();
        }
    }
}
