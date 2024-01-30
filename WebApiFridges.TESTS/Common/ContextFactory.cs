using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiFridges.Data;

namespace WebApiFridges.TESTS.Common
{
    public static class ContextFactory
    {
        public static Guid fridgeProductsGuid = Guid.Parse("c05d9f92-01b2-4bd5-a65b-234c3bf2ff3e");
        public static Guid productGuid = Guid.Parse("2e4a5961-7910-4eea-ad62-1166440d5f7a");
        public static Guid fridgeGuid = Guid.Parse("9ccd4571-ea2a-4e65-82eb-ad67b17eecc1");
        public static string productName = "NewTestName";
        public static int quantity = 999999;
        public static DataContext Create()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase("InMemoryDatabase")
                .Options;
            var context = new DataContext(options);

            bool a = context.Database.EnsureCreated();

            context.FridgeModels.Add(
                new Models.FridgeModel
                {
                    Id = Guid.Parse("f82162f2-9fc0-47f0-b70e-5fbdb7a51081"),
                    Name = "FridgeModelTestName",
                    Year = null
                }
            );

            context.Fridges.Add(
                new Models.Fridge
                {
                    Id = Guid.Parse("9ccd4571-ea2a-4e65-82eb-ad67b17eecc1"),
                    Name = "FridgeTestName",
                    OwnerName = "OwnerNameTest",
                    ModelId = Guid.Parse("f82162f2-9fc0-47f0-b70e-5fbdb7a51081")
                }
            );

            context.Products.Add(
                new Models.Product
                {
                    Id = Guid.Parse("2e4a5961-7910-4eea-ad62-1166440d5f7a"),
                    Name = "ProductTestName",
                    DefaultQuantity = 5
                }
            );

            context.FridgeProducts.Add(
                new Models.FridgeProducts
                {
                    Id = Guid.Parse("2cf3246b-f6c8-4e4d-88f4-b6ccaeffe63a"),
                    ProductId = Guid.Parse("2e4a5961-7910-4eea-ad62-1166440d5f7a"),
                    FridgeId = Guid.Parse("9ccd4571-ea2a-4e65-82eb-ad67b17eecc1"),
                    Quantity = 10
                }
            );

            context.SaveChanges();
            return context;
        }
        public static void Destroy(DataContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
