using DragonQuestNine.Models;
using DragonQuestNine.Repositories.Accolades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuestNine.Services.Accolades
{
    public class AccoladeService : IAccoladeService
    {
        private readonly IAccoladeRepository _accoladeRepository;
        public AccoladeService(IAccoladeRepository accoladeRepository)
        {
            _accoladeRepository = accoladeRepository;
        }

        public async Task<IEnumerable<Accolade>> GetAllAccolades()
        {
            return await _accoladeRepository.GetAllAccolades();
        }

        public async Task<Accolade> GetAccoladeById(int accoladeId)
        {
            return await _accoladeRepository.GetAccoladeById(accoladeId);
        }
    }
}
