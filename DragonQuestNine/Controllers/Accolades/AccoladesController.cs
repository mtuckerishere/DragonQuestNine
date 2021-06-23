using AutoMapper;
using DragonQuestNine.Dtos.Accolades;
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
        private readonly IAccoladeService _accoladeService;
        private readonly IMapper _mapper;

        public AccoladesController(IAccoladeService accoladeService, IMapper mapper)
        {
            _accoladeService = accoladeService;
            _mapper = mapper;
        }

        //api/accolades
        [HttpGet]

        public async Task<IEnumerable<AccoladeDto>> GetAllAccolades()
        {
            var accolades = await _accoladeService.GetAllAccolades();
            var resources = _mapper.Map<IEnumerable<Accolade>, IEnumerable<AccoladeDto>>(accolades);


            return resources;
        }
        

        //[HttpGet("{accoladeId}", Name= "GetAccoladeById")]
        //[ProducesResponseType(200, Type=typeof(AccoladeDto))]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(404)]
        //public ActionResult GetAllcoladeById(int accoladeId)
        //{
        //    if (!_accoladeRepository.AccoladeExists(accoladeId)){
        //        return NotFound(accoladeId);
        //    }

        //    var accolade = _accoladeRepository.GetAccoladeById(accoladeId);

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var singleAccolade = new AccoladeDto
        //    {
        //        Id = accolade.Id,
        //        Name = accolade.Name,
        //        IsObtained = accolade.IsObtained,
        //        DateObtained = accolade.DateObtained,
        //    };

        //    return Ok(singleAccolade);
        //}

        ////api/accolades
        //[HttpPost]
        //public IActionResult CreateAccolade([FromBody]Accolade accoladeToCreate)
        //{
        //    if (accoladeToCreate == null)
        //    {
        //        return BadRequest(accoladeToCreate);
        //    }

        //    var accolade = _accoladeRepository.GetAllAccolades()
        //        .Where(a => a.Name.Trim().ToUpper() == accoladeToCreate.Name
        //        .Trim().ToUpper()).FirstOrDefault();

        //    if(accolade != null)
        //    {

        //        ModelState.AddModelError("", $"Accolade: {accolade.Name}, already exists.");
        //        return StatusCode(422, ModelState);
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (!_accoladeRepository.AddAccolade(accoladeToCreate))
        //    {
        //        ModelState.AddModelError("", $"Something went wrong trying to save {accoladeToCreate.Name}");
        //        return StatusCode(500, ModelState);
        //    }

        //    return CreatedAtRoute("GetAccoladeById", new { accoladeId = accoladeToCreate.Id}, accoladeToCreate);
        //}
    }
}
