using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuestNine.Dtos.Accolades
{
    public class SaveAccoladeCategoryDto
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
