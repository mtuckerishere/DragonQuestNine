using DragonQuestNine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuestNine.Services.Accolades
{
    public class AccoladeCategoryRepository: IAccoladeCategoryRepository
    {
        private readonly DragonQuestDbContext _dragonQuestDbContext;
        public AccoladeCategoryRepository(DragonQuestDbContext dragonQuestDbContext)
        {
            _dragonQuestDbContext = dragonQuestDbContext;
        }
        public ICollection<AccoladeCategory> GetAllAccoladeCategories()
        {
            return _dragonQuestDbContext.AccoladeCategories.OrderBy(a => a.Name == a.Name).ToList();
        }

        public AccoladeCategory GetAccoladeCategoryById(int accoladeCategoryId)
        {
            return _dragonQuestDbContext.AccoladeCategories.FirstOrDefault(a => a.Id == accoladeCategoryId);
        }

        public bool AccoladeCategoryExists(int accoladeCategoryId)
        {
            return _dragonQuestDbContext.AccoladeCategories.Any(a => a.Id == accoladeCategoryId);
        }

        public bool CreateAccoladeCategory(AccoladeCategory accoladeCategory)
        {
            _dragonQuestDbContext.AccoladeCategories.Add(accoladeCategory);
            return Save();
        }

        public bool DeleteAccoladeCategory(AccoladeCategory accoladeCategory)
        {
            _dragonQuestDbContext.AccoladeCategories.Remove(accoladeCategory);
            return Save();
        }

        public bool Save()
        {
            var isSaved = _dragonQuestDbContext.SaveChanges();
            return isSaved >= 0 ? true : false;
        }

        public bool UpdateAccoladeCategory(AccoladeCategory accoladeCategory)
        {
            _dragonQuestDbContext.AccoladeCategories.Update(accoladeCategory);
            return Save();
        }
    }
}
