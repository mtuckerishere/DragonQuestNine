using AutoMapper;
using DragonQuestNine.Dtos.Accolades;
using DragonQuestNine.Extensions;
using DragonQuestNine.Models;
using DragonQuestNine.Services.Accolades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuestNine.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AccoladeCategoriesController : Controller
    {
        private readonly IAccoladeCategoryService _accoladeCategoryService;
        private readonly IMapper _mapper;

        public AccoladeCategoriesController(IAccoladeCategoryService accoladeCategoryService, IMapper mapper)
        {
            _accoladeCategoryService = accoladeCategoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AccoladeCategoryDto>> GetAllAccoladeCategories()
        {

            var accoladeCategories = await _accoladeCategoryService.GetAllAccoladeCategories();
            var resources = _mapper.Map<IEnumerable<AccoladeCategory>, IEnumerable<AccoladeCategoryDto>>(accoladeCategories);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccoladeCategory([FromBody] SaveAccoladeCategoryDto createAccoladeCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var accoladeCategory = _mapper.Map<SaveAccoladeCategoryDto, AccoladeCategory>(createAccoladeCategory);
            var result = await _accoladeCategoryService.AddAccoladeCategory(accoladeCategory);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var accoladeCategoryDto = _mapper.Map<AccoladeCategory, AccoladeCategoryDto>(result.AccoladeCategory);

            return Ok(accoladeCategoryDto);
            
        }
    }
}

    

    //[HttpGet("{accoladeCategoryId}", Name = "GetAccoladeCategoryById")]
    //[ProducesResponseType(200, Type = typeof(AccoladeCategoryDto))]
    //[ProducesResponseType(404)]
    //[ProducesResponseType(400)]
    //public IActionResult GetAccoladeCategoryById(int accoladeCategoryId)
    //{
    //    if (!_accoladeCategoryRepository.AccoladeCategoryExists(accoladeCategoryId))
    //    {
    //        return NotFound(accoladeCategoryId);
    //    }

    //    var accoladeCategory = _accoladeCategoryRepository.GetAccoladeCategoryById(accoladeCategoryId);

    //    if (!ModelState.IsValid)
    //    {
    //        return BadRequest(ModelState);
    //    }

    //    var category = new AccoladeCategoryDto
    //    {
    //        Id = accoladeCategory.Id,
    //        Name = accoladeCategory.Name,
    //        Accolade =  { Id = accoladeCategory.Accolade.Id, DateObtained = accoladeCategory.Accolade.DateObtained, IsObtained = accoladeCategory.Accolade.IsObtained, Name = accoladeCategory.Accolade.Name}
    //    };

    //    return Ok(category);
    //}

    //[HttpPost]
    //public IActionResult CreateAccoladeCategory([FromBody] AccoladeCategory createAccoladeCategory)
    //{
    //    if(createAccoladeCategory == null)
    //    {
    //        return BadRequest(createAccoladeCategory);
    //    }

    //    var existingAccoladeCategory = _accoladeCategoryRepository.GetAllAccoladeCategories()
    //        .Where(a => a.Name.Trim().ToUpper() == createAccoladeCategory.Name.Trim().ToUpper()).FirstOrDefault();
    //    Console.Write(existingAccoladeCategory);

    //    if (existingAccoladeCategory != null)
    //    {
    //        ModelState.AddModelError("", $"Accolade Category: {createAccoladeCategory.Name}, already exists.");
    //        return StatusCode(422, ModelState);
    //    }

    //    if (!ModelState.IsValid)
    //    {
    //        return BadRequest(ModelState);
    //    }

    //    if (!_accoladeCategoryRepository.CreateAccoladeCategory(createAccoladeCategory))
    //    {
    //        ModelState.AddModelError("", $"Something went wrong trying to save {createAccoladeCategory.Name}.");
    //        return StatusCode(500, ModelState);
    //    }

    //    return CreatedAtAction("GetAccoladeCategoryById", new { accoladeCategoryId = createAccoladeCategory.Id }, createAccoladeCategory);

    
