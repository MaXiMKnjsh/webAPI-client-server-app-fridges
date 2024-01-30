using WebApiFridges.Data;
using WebApiFridges.Models;
using WebApiFridges.MyIntefaces;
using WebApiFridges.MyResponceClasses;

namespace WebApiFridges.Repository
{
    public class FridgeRepository : IFridgeRepository
    {
        private readonly DataContext dataContext;
        public FridgeRepository(DataContext context)
        {
            this.dataContext = context;
        }

        public IEnumerable<ResponceFridges> GetFridgesList()
        {
            // если нет подходящих результатов, то join вернёт таблицу без строк
            IEnumerable<ResponceFridges> query =
                from fr in dataContext.Fridges
                join frMod in dataContext.FridgeModels
                on fr.ModelId equals frMod.Id
                select new ResponceFridges
                {
                    Guid = fr.Id,
                    Name = fr.Name,
                    OwnerName=fr.OwnerName,
                    Model=frMod.Name,
                    Year = frMod.Year
                };
            return query;
        }
    }
}
