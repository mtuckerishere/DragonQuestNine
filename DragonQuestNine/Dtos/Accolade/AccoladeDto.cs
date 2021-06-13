using DragonQuestNine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuestNine.Dtos.Accolade
{
    public class AccoladeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsObtained { get; set; }
        public DateTime DateObtained { get; set; }
        public AccoladeCategory AccoladeCategory { get; set; }
    }
}
