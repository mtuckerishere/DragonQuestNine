using DragonQuestNine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuestNine.Services.Accolades
{
    public interface IAccoladeRepository
    {
        public ICollection<Accolade> GetAllAccolades();
        public Accolade GetAccoladeById(int accoladeId);
        public bool AddAccolade(Accolade accolade);
        public bool UpdateAccolade(Accolade accolade);
        public bool DeleteAccolade(Accolade accoladeId);
        public bool AccoladeExists(int accoladeId);
        public bool Save();
    }
}
