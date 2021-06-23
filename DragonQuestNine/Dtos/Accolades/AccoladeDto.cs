using DragonQuestNine.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuestNine.Dtos.Accolades
{
    public class AccoladeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsObtained { get; set; }
        public DateTime? DateObtained { get; set; }
    }
}
