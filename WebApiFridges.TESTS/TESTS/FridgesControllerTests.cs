using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiFridges.Controllers;
using WebApiFridges.Repository;
using WebApiFridges.TESTS.Common;

namespace WebApiFridges.TESTS.TESTS
{
    public class FridgesControllerTests : TestCommandBase
    {
        [Fact]
        public void GetFridgesList_GetAndCheck()
        {
            //Arrange
            var fController = new FridgesController(new FridgeRepository(Context));

            //Act
            IActionResult actionResult = fController.GetFridgesList();
            var OkResult = actionResult as OkObjectResult;

            //Assert
            Assert.NotNull(OkResult);
        }

    }
}
