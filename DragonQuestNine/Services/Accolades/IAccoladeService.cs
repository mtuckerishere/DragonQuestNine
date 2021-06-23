using DragonQuestNine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuestNine.Services.Accolades
{
    public interface IAccoladeService
    {
        Task<IEnumerable<Accolade>> GetAllAccolades();
        Task<Accolade> GetAccoladeById(int accoladeId);
    }
}
