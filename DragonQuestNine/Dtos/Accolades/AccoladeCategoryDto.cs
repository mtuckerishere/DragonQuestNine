using DragonQuestNine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuestNine.Dtos.Accolades
{
    public class AccoladeCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int AccoladeId { get; set; }
        public Accolade Accolade { get; set; }
    }
}
