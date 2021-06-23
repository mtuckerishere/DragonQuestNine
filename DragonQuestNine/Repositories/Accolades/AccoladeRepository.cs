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
    public class AccoladeRepository : BaseRepository, IAccoladeRepository
    {
        public AccoladeRepository(DragonQuestDbContext dragonQuestDbContext) : base(dragonQuestDbContext)
        {

        }

        public async Task<IEnumerable<Accolade>> GetAllAccolades()
        {
            return await _dbContext.Accolades.ToListAsync();
        }

        public async Task<Accolade> GetAccoladeById(int accoladeId)
        {
            return await _dbContext.Accolades.Where(a => a.Id == accoladeId).FirstOrDefaultAsync();
        }
    }
}
