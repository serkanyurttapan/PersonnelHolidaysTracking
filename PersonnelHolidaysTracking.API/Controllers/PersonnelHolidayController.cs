using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonnelHolidaysTracking.Core.DTOs;
using PersonnelHolidaysTracking.Core.Models;
using PersonnelHolidaysTracking.Core.Services;

namespace PersonnelHolidaysTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnelHolidayController : ControllerBase
    {
        private readonly IPersonnelHolidayService _personnelHolidayService;
        private readonly IMapper _mapper;


       
        public PersonnelHolidayController(IPersonnelHolidayService personnelHolidayService, IMapper mapper)
        {
            _personnelHolidayService = personnelHolidayService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var personnels = await _personnelHolidayService.GetAllAsync();
            return Ok(personnels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
           var personels = await _personnelHolidayService.GetByIdAsync(id);

            return Ok(_mapper.Map<PersonnelHoliday>(personels));
        }
        [HttpPost]
        public async Task<IActionResult> Save(PersonnelHoliday personnelHoliday)
        {
          
            var personnel = await _personnelHolidayService.AddAsync(personnelHoliday);
            return Created("", _mapper.Map<PersonnelHolidayDto>(personnel));
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int Id)
        {
            var category = _personnelHolidayService.GetByIdAsync(Id).Result;
            _personnelHolidayService.Remove(category);

            return NoContent();
        }
        [HttpPut]
        public IActionResult Update(PersonnelHoliday personnelHoliday)
        {
             _personnelHolidayService.Update(personnelHoliday);
            return NoContent();
        }

    }
}