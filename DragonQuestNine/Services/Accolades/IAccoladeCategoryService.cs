using DragonQuestNine.Dtos.Accolades;
using DragonQuestNine.Models;
using DragonQuestNine.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuestNine.Services.Accolades
{
    public interface IAccoladeCategoryService
    {
        Task<IEnumerable<AccoladeCategory>> GetAllAccoladeCategories();
        Task<SaveAccoladeCategoryResponse> AddAccoladeCategory(AccoladeCategory accoladeCategory);
        Task<SaveAccoladeCategoryResponse> UpdateAccoladeCategory(int accoladeCategoryId, AccoladeCategory accoladeCategory);
        Task<AccoladeCategory> GetAccoladeCategoryById(int accoladeCategoryId);
    }
}
    