using DragonQuestNine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuestNine.Repositories.Accolades
{
    public interface IAccoladeRepository
    {
        public Task<IEnumerable<Accolade>> GetAllAccolades();
        public Task<Accolade> GetAccoladeById(int accoladeId);
    }
}
