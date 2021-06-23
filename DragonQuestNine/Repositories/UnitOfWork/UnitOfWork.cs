using DragonQuestNine.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuestNine.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DragonQuestDbContext _dragonQuestDbContext;

        public UnitOfWork(DragonQuestDbContext dragonQuestDbContext)
        {
            _dragonQuestDbContext = dragonQuestDbContext;
        }

        public async Task CompleteAsync()
        {
            await _dragonQuestDbContext.SaveChangesAsync();
        }
    }
}
