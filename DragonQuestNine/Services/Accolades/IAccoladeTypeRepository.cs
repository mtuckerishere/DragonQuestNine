using DragonQuestNine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuestNine.Services.Accolades
{
    public interface IAccoladeTypeRepository
    {
        public ICollection<AccoladeType> GetAllAccoladeTypes();
        public AccoladeType GetAccoladeTypeById(int accoladeTypeId);
        public bool AccoladeTypeExists(int accoladeTypeId);
        public bool CreateAccoladeType(AccoladeType accoladeType);
        public bool DeleteAccoladeType(AccoladeType accoladeType);
        public bool UpdateAccoladeType(AccoladeType accoladeType);
        public bool Save();
    }
}
