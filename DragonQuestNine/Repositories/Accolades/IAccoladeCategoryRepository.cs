using DragonQuestNine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuestNine.Repositories.Accolades
{
    public interface IAccoladeCategoryRepository
    {
        Task<IEnumerable<AccoladeCategory>> GetAllAccoladeCategories();
        Task AddAccoladeCategory(AccoladeCategory accolageCategory);
        Task<AccoladeCategory> GetAccoladeCategoryById(int accoladeCategoryId);
        void Update(AccoladeCategory accoladeCategory);
    }
}
