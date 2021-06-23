using AutoMapper;
using DragonQuestNine.Dtos.Accolades;
using DragonQuestNine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuestNine.Mapping
{
    public class DtoToModel : Profile
    {
        public DtoToModel()
        {
            CreateMap<SaveAccoladeCategoryDto, AccoladeCategory>();
        }
    }
}
