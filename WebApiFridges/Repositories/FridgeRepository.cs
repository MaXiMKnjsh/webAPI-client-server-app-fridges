using System;
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

        public bool isModelExist(Guid modelGuid)
        {
			var model = dataContext.FridgeModels.FirstOrDefault(x => x.Id == modelGuid);
			if (model == null)
				return false;

			return true;
		}
        public bool isFridgeExist(Guid guid)
        {
            var fridge = dataContext.Fridges.FirstOrDefault(x => x.Id == guid);
            if (fridge == null)
                return false;

            return true;
        }

        public bool DeleteFridge(Guid guid)
        {
            var fridgeToDelete = dataContext.Fridges.FirstOrDefault(x => x.Id == guid);
            if (fridgeToDelete != null)
            {
                dataContext.Fridges.Remove(fridgeToDelete);
                return Save();
            }
            return false;
        }

        public bool Save()
        {
            int savedCount = dataContext.SaveChanges();
            return savedCount > 0 ? true : false;
        }

        public IEnumerable<ResponceFridges> GetFridgesList()
        {
            // если нет подходящих результатов, то join вернёт таблицу без строк
            IEnumerable<ResponceFridges> responce =
                from fr in dataContext.Fridges
                join frMod in dataContext.FridgeModels
                on fr.ModelId equals frMod.Id
                select new ResponceFridges
                {
                    Guid = fr.Id,
                    Name = fr.Name,
                    OwnerName = fr.OwnerName,
                    Model = frMod.Name,
                    Year = frMod.Year
                };
            return responce;
        }

		public Guid CreateFridge(string name, Guid modelGuid, string? ownerName = null)
		{
            var fridgeToCreate = new Fridge()
            {
                ModelId = modelGuid,
                Name = name,
                OwnerName = ownerName,
			};

            dataContext.Fridges.Add(fridgeToCreate);

            if (!Save()) 
                return Guid.Empty;

			return fridgeToCreate.Id;
		}
	}
}
