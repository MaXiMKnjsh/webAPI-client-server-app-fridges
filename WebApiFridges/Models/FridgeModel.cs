using WebApiFridges.Models;

namespace WebApiFridges.Models
{
    public class FridgeModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; }
        // навигационное свойство
        public ICollection<Fridge> Fridges { get; set; }
    }
}
