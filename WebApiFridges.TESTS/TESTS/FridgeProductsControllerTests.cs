using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using WebApiFridges.Controllers;
using WebApiFridges.Data;
using WebApiFridges.Models;
using WebApiFridges.MyIntefaces;
using WebApiFridges.Repository;
using WebApiFridges.TESTS.Common;

namespace WebApiFridges.TESTS.TESTS
{
    public class FridgeProductsControllerTests : TestCommandBase
    {
        [Fact]
        public void GetProductsList_GetTableDataAndAssert()
        {
            //Arrange
            var fridgeProductsGuid = ContextFactory.fridgeProductsGuid;
            var productGuid = ContextFactory.productGuid;
            var fridgeGuid = ContextFactory.fridgeGuid;
            var quantity = 5;

            Context.FridgeProducts.Add(new FridgeProducts()
            {
                Id = fridgeProductsGuid,
                ProductId = productGuid,
                Quantity = quantity,
                FridgeId = fridgeGuid
            });
            Context.SaveChanges();

            var fpController = new FridgeProductsController(new FridgeProductsRepository(Context));
            ICollection<FridgeProducts> fridgeProductsTable = Context.FridgeProducts.ToList();

            //Act
            IActionResult actionResult = fpController.GetProductsList(fridgeGuid);
            var OkResult = actionResult as OkObjectResult;

            //Assert
            Assert.NotNull(OkResult);
        }
        [Fact]
        public void RemoveProducts_RemoveTableAndCheck()
        {
            //Arrange
            var fpController = new FridgeProductsController(new FridgeProductsRepository(Context));

            //Act

            //использую guid уже существующего элемента в таблице
            IActionResult actionResult = fpController.RemoveProducts(Guid.Parse("2cf3246b-f6c8-4e4d-88f4-b6ccaeffe63a"));
            var OkResult = actionResult as OkObjectResult;

            //Assert
            Assert.NotNull(OkResult);
        }

        [Fact]
        public void UpdateProductsToDefQuant_UpdateAndCheck()
        {
            //Arrange
            var fpController = new FridgeProductsController(new FridgeProductsRepository(Context));

            //Act
            IActionResult actionResult = fpController.UpdateProductsToDefQuant();
            var OkResult = actionResult as OkObjectResult;

            //Assert
            Assert.NotNull(OkResult);
        }

        [Fact]
        public void AddProducts_AddProdAndCheck()
        {
            //Arrange
            var fpController = new FridgeProductsController(new FridgeProductsRepository(Context));

            //Act
            IActionResult actionResult = fpController.AddProducts(ContextFactory.fridgeGuid, ContextFactory.productGuid, ContextFactory.quantity);
            var OkResult = actionResult as OkObjectResult;

            //Assert
            Assert.NotNull(OkResult);

        }
    }
}