using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuestNine.Models
{
    public class AccoladeCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AccoladeType AccoladeType { get; set; }
    }
}
