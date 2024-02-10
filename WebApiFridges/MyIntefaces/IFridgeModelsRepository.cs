using WebApiFridges.API.MyResponceClasses;

namespace WebApiFridges.API.MyIntefaces
{
	public interface IFridgeModelsRepository
	{
		IEnumerable<ResponceFridgeModel> GetModels(); 
	}
}
