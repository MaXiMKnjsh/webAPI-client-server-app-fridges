using Microsoft.AspNetCore.Mvc;
using WebApiFridges.API.MyIntefaces;
using WebApiFridges.API.MyResponceClasses;
using WebApiFridges.Data;

namespace WebApiFridges.API.Repositories
{
	public class FridgeModelsRepository : IFridgeModelsRepository
	{
		private readonly DataContext dataContext;
		public FridgeModelsRepository(DataContext dataContext)
		{
			this.dataContext = dataContext;
		}
		public IEnumerable<ResponceFridgeModel> GetModels()
		{
			IEnumerable<ResponceFridgeModel> requset = dataContext.FridgeModels.Select(mdl => new ResponceFridgeModel()
			{
				Id = mdl.Id,
				Name = mdl.Name,
				Year = mdl.Year
			}).ToList();

			return requset;
		}
	}
}
