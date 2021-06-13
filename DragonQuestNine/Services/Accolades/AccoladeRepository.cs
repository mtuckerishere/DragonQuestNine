using DragonQuestNine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuestNine.Services.Accolades
{
    public class AccoladeRepository : IAccoladeRepository
    {
        private readonly DragonQuestDbContext _dragonQuestDbContext;
        public AccoladeRepository(DragonQuestDbContext dragonQuestDbContext)
        {
            _dragonQuestDbContext = dragonQuestDbContext;
        }
        public bool AccoladeExists(int accoladeId)
        {
            return _dragonQuestDbContext.Accolades.Any(a => a.Id == accoladeId);
        }

        public bool AddAccolade(Accolade accolade)
        {
            _dragonQuestDbContext.Accolades.Add(accolade);
            return Save();
        }

        public bool DeleteAccolade(Accolade accolade)
        {
             _dragonQuestDbContext.Accolades.Remove(accolade);
            return Save();
        }

        public ICollection<Accolade> GetAllAccolades()
        {
            return _dragonQuestDbContext.Accolades.OrderBy(a => a.Name).ToList();
        }

        public bool UpdateAccolade(Accolade accolade)
        {
            _dragonQuestDbContext.Accolades.Update(accolade);
            return Save();
        }

        public bool Save()
        {
            int isSaved = _dragonQuestDbContext.SaveChanges();
            return isSaved >= 0 ? true : false;
        }

        public Accolade GetAccoladeById(int accoladeId)
        {
            Accolade accolade = _dragonQuestDbContext.Accolades.Where(a => a.Id == accoladeId).FirstOrDefault(); ;
            return accolade;
        }
    }
}
