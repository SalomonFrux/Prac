using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StorecontextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {

            try
            {

           
             if (!context.ProductBrands.Any())
            {
                var ProductBrandsJson = File.ReadAllText("../Infrastructure/Data/DataSeed/brands.json");

        var ProductBrandsJsonList =  JsonSerializer.Deserialize<List<ProductBrand>>(ProductBrandsJson);

                foreach (var item in ProductBrandsJsonList)
                {
                    context.ProductBrands.Add(item);
                }
                await  context.SaveChangesAsync();
             }

            
         if (!context.ProductTypes.Any())
            {
                var ProductTypesJson = File.ReadAllText("../Infrastructure/Data/DataSeed/types.json");
                
                var ProductTypesJsonList = 
                JsonSerializer.Deserialize<List<ProductType>>(ProductTypesJson);

                foreach (var item in ProductTypesJsonList)
                {
                    context.ProductTypes.Add(item);
                }
              await  context.SaveChangesAsync();
             }

             if (!context.Products.Any())
            {
                var productsJson = File.ReadAllText("../Infrastructure/Data/DataSeed/products.json");
                var productsJsonList = JsonSerializer.Deserialize<List<Products>>(productsJson);

                foreach (var item in productsJsonList)
                {
                    context.Products.Add(item);
                }
              await  context.SaveChangesAsync();
             }


               }
            catch (Exception ex)
            {
                var logger =  loggerFactory.CreateLogger<StorecontextSeed>();
                logger.LogError(ex.Message);
               
            }

            
        }
    }
}