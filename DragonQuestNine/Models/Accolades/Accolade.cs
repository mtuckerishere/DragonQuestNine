using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuestNine.Models
{
    public class Accolade
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual bool IsObtained { get; set; }
        public virtual DateTime? DateObtained { get; set; }

        public int AccoladeCategoryId { get; set; }
        public AccoladeCategory AccoladeCategory { get; set; }
    }
}
