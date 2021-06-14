using DragonQuestNine.Dtos.Accolade;
using DragonQuestNine.Models;
using DragonQuestNine.Services.Accolades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuestNine.Controllers.Accolades
{
    [Route("/api/[controller]")]
    [ApiController]
    public class AccoladeTypesController : Controller
    {
        private IAccoladeTypeRepository _accoladeTypeRepository;

        public AccoladeTypesController(IAccoladeTypeRepository accoladeTypeRepository)
        {
            _accoladeTypeRepository = accoladeTypeRepository;
        }
        [HttpGet("{accoladeTypeId}")]
        public IActionResult GetAccoladeTypeById(int accoladeTypeId)
        {
            if (!_accoladeTypeRepository.AccoladeTypeExists(accoladeTypeId))
            {
                return NotFound(accoladeTypeId);
            }

            var accoladeType = _accoladeTypeRepository.GetAccoladeTypeById(accoladeTypeId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accoladeTypeDto = new AccoladeTypeDto
            {
                Id = accoladeType.Id,
                Name = accoladeType.Name
            };

            return Ok(accoladeTypeDto);
        }

        [HttpPost]
        public IActionResult CreateNewAccoladeType([FromBody]AccoladeType accoladeTypeToCreate)
        {
            if(accoladeTypeToCreate == null)
            {
                return BadRequest(accoladeTypeToCreate);
            }

            var accoladeType = _accoladeTypeRepository.GetAllAccoladeTypes()
                .Where(a => a.Name.Trim().ToUpper() == accoladeTypeToCreate.Name.Trim().ToUpper());

            if(accoladeType != null)
            {
                ModelState.AddModelError("", $"Accolate Type: {accoladeTypeToCreate.Name} already exists.");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_accoladeTypeRepository.CreateAccoladeType(accoladeTypeToCreate))
            {
                ModelState.AddModelError("", $"Something went wrong trying to save {accoladeTypeToCreate.Name}.");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetAccoladeTypeById", new { accoladeTypeId = accoladeTypeToCreate.Id }, accoladeTypeToCreate);
        }

    }
}
