using Microsoft.AspNetCore.Mvc;
using WebApiFridges.Models;
using WebApiFridges.MyIntefaces;
using WebApiFridges.MyResponceClasses;

namespace WebApiFridges.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // атрибут, определяющий маршрут контроллера api/FridgeProducts
    public class FridgesController : Controller
    {
        private readonly IFridgeRepository fridgeRepository;
        public FridgesController(IFridgeRepository fridgeRepository)
        {
            this.fridgeRepository = fridgeRepository;
        }

        [HttpGet]
        public IActionResult GetFridgesList()
        {
            IEnumerable<ResponceFridges> fridges = fridgeRepository.GetFridgesList();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!fridges.Any())
                return NotFound();

            return Ok(fridges);
        }
    }
}
