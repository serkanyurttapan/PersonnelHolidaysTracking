using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonnelHolidaysTracking.Core.DTOs;
using PersonnelHolidaysTracking.Core.Services;

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


        [HttpGet()]
        public string GetAll()
        {
            return "";
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            PersonnelDto personels = await _personnelService.GetWithIPersonnelHolidayGetByAsync(id);

            return Ok(_mapper.Map<PersonnelDto>(_mapper.Map<PersonnelWithPersonnelHolidayDto>(personels)));
        }
    }
}