using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonnelHolidaysTracking.Core.DTOs;
using PersonnelHolidaysTracking.Core.Models;
using PersonnelHolidaysTracking.Core.Services;
using System.Threading.Tasks;

namespace PersonnelHolidaysTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnelController : ControllerBase
    {
        private readonly IPersonnelService _personnelService;
        private readonly IMapper _mapper;
        public PersonnelController(IPersonnelService personnelService, IMapper mapper)
        {
            _personnelService = personnelService;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var personnels = await _personnelService.GetAllAsync();
            return Ok(personnels);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            PersonnelDto personels =  _personnelService.GetWithIPersonnelHolidayGetByAsync(id);

            return Ok(_mapper.Map<PersonnelWithPersonnelHolidayDto>(personels));
        }
        [HttpPost]
        public async Task<IActionResult> Save(Personnel personnel)
        {
            var newPersonel = await _personnelService.AddAsync(personnel);
            return Created("", _mapper.Map<Personnel>(newPersonel));
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int Id)
        {
            var category = _personnelService.GetByIdAsync(Id).Result;
            _personnelService.Remove(category);

            return NoContent();
        }
        [HttpPut]
        public IActionResult Update(Personnel personnel)
        {
            var category = _personnelService.Update(_mapper.Map<Personnel>(personnel));
            return NoContent();
        }
    }
}