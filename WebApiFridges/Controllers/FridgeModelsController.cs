using Microsoft.AspNetCore.Mvc;
using WebApiFridges.API.MyIntefaces;
using WebApiFridges.API.MyResponceClasses;

namespace WebApiFridges.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class FridgeModelsController : Controller
	{
		private readonly IFridgeModelsRepository fridgeModelsRepository;
		public FridgeModelsController(IFridgeModelsRepository fridgeModelsRepository) { 
			this.fridgeModelsRepository = fridgeModelsRepository;
		}

		[HttpGet]
		public IActionResult GetModels()
		{
			IEnumerable<ResponceFridgeModel> request = fridgeModelsRepository.GetModels();

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (!request.Any())
				return StatusCode(204,ModelState);

			return Ok(request);
		}
	}
}
