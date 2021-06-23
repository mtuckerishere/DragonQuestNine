using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DragonQuestNine.Models;
using DragonQuestNine.Persistance.Contexts;

namespace DragonQuestNine.Persistance.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly DragonQuestDbContext _dbContext;

        public BaseRepository(DragonQuestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
