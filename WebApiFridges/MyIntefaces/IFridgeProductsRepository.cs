using WebApiFridges.API.MyResponceClasses;
using WebApiFridges.Models;
using WebApiFridges.MyResponceClasses;

namespace WebApiFridges.MyIntefaces
{
    public interface IFridgeProductsRepository
    {
        IEnumerable<ResponceFridgeProducts> GetProductsList(Guid fridgeId);
        bool AddProducts(Guid fridgeId, Guid productId, int quantity);
		bool AddProducts(IEnumerable<Guid> guids, Guid fridgeGuid);
		bool IsProducstExist(IEnumerable<Guid> productsGuids);
		bool Save();
        bool IsFridgeExist(Guid fridgeId);
        bool IsProductExist(Guid productId);
        bool RemoveFridgeProducts(Guid guid);
        bool IsFridgeProductExist(Guid fridgeProductId);
        int UpdateProductsToDefQuant();
        bool EditProducts(IEnumerable<ResponceFridgeProductsToEdit> productsGuids, Guid fridgeGuid);
        bool Clear(Guid fridgeGuid);
		int SaveWithCount();
    }
}
