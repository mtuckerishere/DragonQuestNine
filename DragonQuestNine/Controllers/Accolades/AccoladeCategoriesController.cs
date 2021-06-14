using DragonQuestNine.Dtos.Accolade;
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
        private IAccoladeCategoryRepository _accoladeCategoryRepository;
        public AccoladeCategoriesController(IAccoladeCategoryRepository accoladeCategoryRepository)
        {
            _accoladeCategoryRepository = accoladeCategoryRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<AccoladeCategoryDto>))]
        [ProducesResponseType(404)]
        public IActionResult GetAllAccoladeCategories()
        {
            var accoladeCategories = _accoladeCategoryRepository.GetAllAccoladeCategories();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoryList = new List<AccoladeCategoryDto>();

            foreach (var category in accoladeCategories)
            {
                categoryList.Add(new AccoladeCategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    AccoladeType = category.AccoladeType
                });
            }

            return Ok(categoryList);
        }
        [HttpGet("{accoladeCategoryId}")]
        [ProducesResponseType(200, Type = typeof(AccoladeCategoryDto))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetAccoladeCategoryById(int accoladeCategoryId)
        {
            if (!_accoladeCategoryRepository.AccoladeCategoryExists(accoladeCategoryId))
            {
                return NotFound(accoladeCategoryId);
            }

            var accoladeCategory = _accoladeCategoryRepository.GetAccoladeCategoryById(accoladeCategoryId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = new AccoladeCategoryDto
            {
                Id = accoladeCategory.Id,
                Name = accoladeCategory.Name,
                AccoladeType = accoladeCategory.AccoladeType
            };

            return Ok(category);
        }

        [HttpPost]
        public IActionResult CreateAccoladeCategory([FromBody] AccoladeCategory createAccoladeCategory)
        {
            if(createAccoladeCategory == null)
            {
                return BadRequest(createAccoladeCategory);
            }

            var existingAccoladeCategory = _accoladeCategoryRepository.GetAllAccoladeCategories()
                .Where(a => a.Name.Trim().ToUpper() == createAccoladeCategory.Name.Trim().ToUpper());

            if (existingAccoladeCategory != null)
            {
                ModelState.AddModelError("", $"Accolade Category: {createAccoladeCategory.Name}, already exists.");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_accoladeCategoryRepository.CreateAccoladeCategory(createAccoladeCategory))
            {
                ModelState.AddModelError("", $"Something went wrong trying to save {createAccoladeCategory.Name}.");
                return StatusCode(500, ModelState);
            }

            return CreatedAtAction("GetAccoladeCategoryById", new { accoladeCategoryId = createAccoladeCategory.Id }, createAccoladeCategory);
        }
    }
}
