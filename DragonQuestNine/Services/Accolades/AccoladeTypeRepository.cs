using DragonQuestNine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuestNine.Services.Accolades
{
    public class AccoladeTypeRepository : IAccoladeTypeRepository
    {
        private readonly DragonQuestDbContext _dragonQuestDbContext;
        public AccoladeTypeRepository(DragonQuestDbContext dragonQuestDbContext)
        {
            _dragonQuestDbContext = dragonQuestDbContext;
        }

        public bool AccoladeTypeExists(int accoladeTypeId)
        {
            return _dragonQuestDbContext.AccoladeTypes.Any(a => a.Id == accoladeTypeId);
        }

        public bool CreateAccoladeType(AccoladeType accoladeType)
        {
            _dragonQuestDbContext.AccoladeTypes.Add(accoladeType);
            return Save();
        }

        public bool DeleteAccoladeType(AccoladeType accoladeType)
        {
            _dragonQuestDbContext.AccoladeTypes.Remove(accoladeType);
            return Save();
        }

        public AccoladeType GetAccoladeTypeById(int accoladeTypeId)
        {
            return _dragonQuestDbContext.AccoladeTypes.FirstOrDefault(a => a.Id == accoladeTypeId);
        }

        public ICollection<AccoladeType> GetAllAccoladeTypes()
        {
            return _dragonQuestDbContext.AccoladeTypes.OrderBy(a => a.Name).ToList();
        }

        public bool Save()
        {
           var isSaved = _dragonQuestDbContext.SaveChanges();
            return isSaved >= 0 ? true : false;
        }

        public bool UpdateAccoladeType(AccoladeType accoladeType)
        {
            _dragonQuestDbContext.AccoladeTypes.Update(accoladeType);
            return Save();
        }
    }
}
