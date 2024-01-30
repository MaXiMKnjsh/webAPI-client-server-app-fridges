using WebApiFridges.Models;
using WebApiFridges.MyResponceClasses;

namespace WebApiFridges.MyIntefaces
{
    public interface IFridgeProductsRepository
    {
        IEnumerable<ResponceFridgeProducts> GetProductsList(Guid fridgeId);
        bool AddProducts(Guid fridgeId, Guid productId, int quantity);
        bool Save();
        bool IsFridgeExist(Guid fridgeId);
        bool IsProductExist(Guid productId);
        bool RemoveFridgeProducts(Guid guid);
        bool IsFridgeProductExist(Guid fridgeProductId);
        int UpdateProductsToDefQuant();
        int SaveWithCount();
    }
}
