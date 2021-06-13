using DragonQuestNine.Services.Accolades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuestNine.Controllers
{
    public class AccoladeCategoryController : Controller
    {
        private IAccoladeCategoryRepository _accoladeCategoryRepository;
        public AccoladeCategoryController(IAccoladeCategoryRepository accoladeCategoryRepository)
        {
            _accoladeCategoryRepository = accoladeCategoryRepository;
        }
    }
}
