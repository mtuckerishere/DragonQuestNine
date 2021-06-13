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
    [Route("/api/[controller]")]
    [ApiController]
    public class AccoladesController : Controller
    {
        private IAccoladeRepository _accoladeRepository;
        public AccoladesController(IAccoladeRepository accoladeRepository)
        {
            _accoladeRepository = accoladeRepository;
        }

        //api/accolades
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<AccoladeDto>))]
        [ProducesResponseType(400)]

        public IActionResult GetAllAccolades()
        {
            var accolades = _accoladeRepository.GetAllAccolades().ToList();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accoladeList = new List<AccoladeDto>();

            foreach (var accolade in accolades)
            {
                accoladeList.Add(new AccoladeDto
                {
                    Id = accolade.Id,
                    Name = accolade.Name,
                    IsObtained = accolade.IsObtained,
                    DateObtained = accolade.DateObtained,
                    AccoladeCategory = accolade.AccoladeCategory
                });
            }
            return Ok(accoladeList);
        }

        [HttpGet("{accoladeId}")]
        [ProducesResponseType(200, Type=typeof(AccoladeDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult GetAllcoladeById(int accoladeId)
        {
            if (!_accoladeRepository.AccoladeExists(accoladeId)){
                return NotFound(accoladeId);
            }

            var accolade = _accoladeRepository.GetAccoladeById(accoladeId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var singleAccolade = new AccoladeDto
            {
                Id = accolade.Id,
                Name = accolade.Name,
                IsObtained = accolade.IsObtained,
                DateObtained = accolade.DateObtained,
                AccoladeCategory = accolade.AccoladeCategory
            };

            return Ok(singleAccolade);
        }

        //api/accolades
        [HttpPost]
        public IActionResult CreateAccolade([FromBody]Accolade accoladeToCreate)
        {
            if (accoladeToCreate == null)
            {
                return BadRequest(accoladeToCreate);
            }

            var accolade = _accoladeRepository.GetAllAccolades()
                .Where(a => a.Name.Trim().ToUpper() == accoladeToCreate.Name
                .Trim().ToUpper()).FirstOrDefault();

            if(accolade != null)
            {
                ModelState.AddModelError("", $"Accolade: {accolade.Name}, already exists.");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_accoladeRepository.AddAccolade(accoladeToCreate))
            {
                ModelState.AddModelError("", $"Something went wrong trying to save {accoladeToCreate.Name}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetAccoladeById", new { accoladeId = accoladeToCreate.Id}, accoladeToCreate);
        }
    }
}
