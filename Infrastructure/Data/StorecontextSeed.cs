using System.Linq;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StorecontextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            if (!context.Products.Any())
            {
                
            }
        }
    }
}