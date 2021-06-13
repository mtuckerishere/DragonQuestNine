using DragonQuestNine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuestNine.Services.Accolades
{
    public interface IAccoladeCategoryRepository
    {
        public ICollection<AccoladeCategory> GetAllAccoladeCategories();
        public AccoladeCategory GetAccoladeCategoryById(int accoladeCategoryId);
        public bool AccoladeCategoryExists(int accoladeCategoryId);
        public bool DeleteAccoladeCategory(AccoladeCategory accoladeCategory);
        public bool CreateAccoladeCategory(AccoladeCategory accoladeCategory);
        public bool UpdateAccoladeCategory(AccoladeCategory accoladeCategory);
        public bool Save();
    }
}
