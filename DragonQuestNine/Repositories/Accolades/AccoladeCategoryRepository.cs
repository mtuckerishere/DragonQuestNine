using DragonQuestNine.Models;
using DragonQuestNine.Persistance.Contexts;
using DragonQuestNine.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuestNine.Repositories.Accolades
{
    public class AccoladeCategoryRepository : BaseRepository, IAccoladeCategoryRepository
    {
        public AccoladeCategoryRepository(DragonQuestDbContext dragonQuestDbContext) : base(dragonQuestDbContext)
        {

        }

        public async Task<IEnumerable<AccoladeCategory>> GetAllAccoladeCategories()
        {
            return await _dbContext.AccoladeCategories.ToListAsync();
        }

        public async Task<AccoladeCategory> GetAccoladeCategoryById(int accoladeCategoryId)
        {
            return await _dbContext.AccoladeCategories.FindAsync(accoladeCategoryId);
        }

        public async Task AddAccoladeCategory(AccoladeCategory accoladeCategory)
        {
            await _dbContext.AccoladeCategories.AddAsync(accoladeCategory);
        }

        public void UpdateAccoladeCategory(AccoladeCategory accoladeCategory)
        {
            _dbContext.AccoladeCategories.Update(accoladeCategory);
        }

        public void DeleteAccoladeCategory(AccoladeCategory accoladeCategory)
        {
            _dbContext.AccoladeCategories.Remove(accoladeCategory);
        }

    }
}
