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
        Task<AccoladeCategoryResponse> AddAccoladeCategory(AccoladeCategory accoladeCategory);
        Task<AccoladeCategoryResponse> UpdateAccoladeCategory(int accoladeCategoryId, AccoladeCategory accoladeCategory);
        Task<AccoladeCategoryResponse> DeleteAccoladeCategory(int accoladeCategoryId);
        Task<AccoladeCategory> GetAccoladeCategoryById(int accoladeCategoryId);
    }
}
    