using DomainLayer.Contract;
using Microsoft.EntityFrameworkCore;
using Persistence.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistence
{
    public class DataSeeding(StoreContext context) : IDataSeeding
    {
        public async Task DataSeed()
        {
            try
            {
                var result = await context.Database.GetPendingMigrationsAsync();
                if (result.Any())
                {
                   await context.Database.MigrateAsync();
                }

                if (!context.productBrands.Any())
                {

                    var items = File.OpenRead(@"..\Infrastructure\Persistence\Data\DataSeed\brands.json");
                    var productBrandList =await JsonSerializer.DeserializeAsync<List<ProductBrand>>(items);
                    if (productBrandList is not null)
                    {
                        await context.AddRangeAsync(productBrandList);
                    }

                }

                if (!context.productTypes.Any())
                {
                    var items = File.OpenRead(@"..\Infrastructure\Persistence\Data\DataSeed\types.json");
                    var productTypeList =await JsonSerializer.DeserializeAsync<List<ProductType>>(items);
                    if (productTypeList is not null)
                    {
                        await context.AddRangeAsync(productTypeList);
                    }
                }

                if (!context.products.Any())
                {
                    var items = File.OpenRead(@"..\Infrastructure\Persistence\Data\DataSeed\products.json");
                    var productList =await JsonSerializer.DeserializeAsync<List<Product>>(items);
                    if (productList is not null)
                    {
                       await context.AddRangeAsync(productList);
                    }
                }
                await context.SaveChangesAsync();
            }
            catch (Exception ex )
            {
                Console.WriteLine(ex.ToString());
            }
            
        }
    }
}
