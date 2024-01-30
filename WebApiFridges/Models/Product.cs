namespace WebApiFridges.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? DefaultQuantity { get; set; }
        // навигационное свойство
        public ICollection<FridgeProducts> FridgeProducts { get; set; }
    }
}
