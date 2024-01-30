using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiFridges.Controllers;
using WebApiFridges.Repository;
using WebApiFridges.TESTS.Common;
using Xunit.Sdk;

namespace WebApiFridges.TESTS.TESTS
{
    public class ProductControllerTests : TestCommandBase
    {
        [Fact]
        public void UpdateProduct_UpdateAndCheck()
        {
            //Arrange
            var pController = new ProductController(new ProductRepository(Context));

            //Act
            IActionResult actionResult = pController.UpdateProduct(ContextFactory.productGuid, ContextFactory.productName, ContextFactory.quantity);
            var OkResult = actionResult as OkObjectResult;

            //Assert
            Assert.NotNull(OkResult);
        }

    }
}
