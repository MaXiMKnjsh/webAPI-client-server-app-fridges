using Microsoft.AspNetCore.Mvc;
using WebApiFridges.Models;
using WebApiFridges.MyIntefaces;
using WebApiFridges.MyResponceClasses;
using WebApiFridges.Repository;

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

		[HttpDelete("{fridgeGuid}")]
		public IActionResult DeleteFridge(Guid fridgeGuid)
		{
			if (!fridgeRepository.isFridgeExist(fridgeGuid))
				return NotFound();

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (!fridgeRepository.DeleteFridge(fridgeGuid))
			{
				ModelState.AddModelError("", "Something went wrong while saving!");
				return StatusCode(500, ModelState);
			}

			return Ok("Successfully removed!");
		}

		[HttpPost]
		public IActionResult AddFridge(string name, string ownerName, Guid modelGuid)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (!fridgeRepository.isModelExist(modelGuid))
				return NotFound();

			if (!fridgeRepository.CreateFridge(name, ownerName, modelGuid))
			{
				ModelState.AddModelError("", "Something went wrong while saving!");
				return StatusCode(500, ModelState);
			}

			return Ok("Successfully added!");
		}
	}
}
