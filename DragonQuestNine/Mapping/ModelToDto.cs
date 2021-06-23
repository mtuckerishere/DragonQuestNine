using AutoMapper;
using DragonQuestNine.Dtos.Accolades;
using DragonQuestNine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuestNine.Mapping
{
    public class ModelToDto : Profile
    {
        public ModelToDto()
        {
            CreateMap<Accolade, AccoladeDto>();
            CreateMap<AccoladeCategory, AccoladeCategoryDto>();
        }
    }
}
