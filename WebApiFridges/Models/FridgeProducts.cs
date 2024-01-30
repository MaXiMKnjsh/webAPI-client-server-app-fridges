namespace WebApiFridges.Models
{
    public class FridgeProducts
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid FridgeId { get; set; }
        public int Quantity { get; set; }
        // навигационные свойства
        public Product Products { get; set; }
        public Fridge Fridge { get; set; }

    }
}
