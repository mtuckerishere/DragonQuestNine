﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuestNine.Models
{
    public class Accolade
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsObtained { get; set; }
        public DateTime DateObtained { get; set; }
        public AccoladeCategory AccoladeCategory { get; set; }
       
    }
}