using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuestNine.Models
{
    public class AccoladeCategory
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public IList<Accolade> Accolades { get; set; } = new List<Accolade>();
    }
}
