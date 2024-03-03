using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiFridges.Models;
using WebApiFridges.MyIntefaces;
using WebApiFridges.MyResponceClasses;
using WebApiFridges.Repository;

namespace WebApiFridges.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class FridgeProductsController : Controller
	{
		private readonly IFridgeProductsRepository fridgeProductsRepository;
		public FridgeProductsController(IFridgeProductsRepository fridgeProductsRepository)
		{
			this.fridgeProductsRepository = fridgeProductsRepository;
		}

		[HttpPut("{fridgeGuid}")]
		public IActionResult EditProducts([FromBody] IEnumerable<Guid> productsGuids, Guid fridgeGuid)
		{
			if (!fridgeProductsRepository.IsFridgeExist(fridgeGuid))
				return NotFound("Fridge doesn't exist!");

			if (!ModelState.IsValid)
				return BadRequest(ModelState);


			if (!fridgeProductsRepository.EditProducts(productsGuids, fridgeGuid))
			{
				ModelState.AddModelError("", "Something went wrong while saving! (EditProducts)");
				return StatusCode(500, ModelState);
			}

			return Ok("Successfully changed!");
		}

		[HttpGet("{fridgeGuid}")] //apiFridgeProducts/{frId}
		public IActionResult GetProductsList(Guid fridgeGuid)
		{
			if (!fridgeProductsRepository.IsFridgeExist(fridgeGuid))
				return NotFound("Fridge doesn't exist!");

			// метод возвращает либо пустую последовательность, либо заполненную, если есть совпадения
			IEnumerable<ResponceFridgeProducts> products = fridgeProductsRepository.GetProductsList(fridgeGuid);

			if (!products.Any())
				return NoContent();

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(products);
		}

		[HttpDelete("{fridgeProductsId}")]
		public IActionResult RemoveProducts(Guid fridgeProductsId)
		{
			if (!fridgeProductsRepository.IsFridgeProductExist(fridgeProductsId))
				return NotFound();

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (!fridgeProductsRepository.RemoveFridgeProducts(fridgeProductsId))
			{
				ModelState.AddModelError("", "Something went wrong while saving!");
				return StatusCode(500, ModelState);
			}

			return Ok("Successfully removed!");
		}

		[HttpPut]
		public IActionResult UpdateProductsToDefQuant()
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			int savedCount = fridgeProductsRepository.UpdateProductsToDefQuant();

			if (savedCount <= 0)
				return Ok("Was not found to be updated!");

			return Ok($"Successfully updated {savedCount} products!");
		}

		[HttpPost("AddProduct")]
		public IActionResult AddProduct(Guid fridgeGuid, Guid productGuid, int quantity)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (quantity < 0)
			{
				ModelState.AddModelError("", "You can't add this count of products!");
				return BadRequest();
			}

			if (!fridgeProductsRepository.IsProductExist(productGuid) ||
				!fridgeProductsRepository.IsFridgeExist(fridgeGuid))
			{
				ModelState.AddModelError("", "The product or the refrigerator doesn't exist!");
				return StatusCode(400, ModelState);
			}

			if (!fridgeProductsRepository.AddProducts(fridgeGuid, productGuid, quantity))
			{
				ModelState.AddModelError("", "Something went wrong while saving!");
				return StatusCode(500, ModelState);
			}

			return Ok("Successfully created!");
		}

		[HttpPost("AddProducts")]
		public IActionResult AddProducts([FromBody] IEnumerable<Guid> productsGuids, Guid fridgeGuid)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (!fridgeProductsRepository.IsFridgeExist(fridgeGuid) || !fridgeProductsRepository.IsProducstExist(productsGuids))
			{
				ModelState.AddModelError("", "The product or the refrigerator doesn't exist!");
				return StatusCode(400, ModelState);
			}

			if (!fridgeProductsRepository.AddProducts(productsGuids, fridgeGuid))
			{
				ModelState.AddModelError("", "Something went wrong while saving!");
				return StatusCode(500, ModelState);
			}

			return Ok("Successfully created!");
		}
	}
}
