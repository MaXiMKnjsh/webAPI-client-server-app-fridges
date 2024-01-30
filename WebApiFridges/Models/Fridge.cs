using WebApiFridges.Models;

namespace WebApiFridges.Models
{
    public class Fridge
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? OwnerName { get; set; }
        public Guid ModelId { get; set; }
        // навигационные свойства
        public FridgeModel FridgeModel { get; set; }
        public ICollection<FridgeProducts> FridgeProducts { get; set; }
    }
}
