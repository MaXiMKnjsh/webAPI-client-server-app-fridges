namespace WebApiFridges.MyIntefaces
{
    public interface IProductRepository
    {
        bool Save();
        bool ProductUpdate(Guid newProductId, string newProductName, int newQuantity);
        bool IsProductExist(Guid productId);
    }
}
