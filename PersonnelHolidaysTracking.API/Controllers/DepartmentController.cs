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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _departmentService.GetAllAsync();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _departmentService.GetByIdAsync(id);

            return Ok(department);
        }
        [HttpPost]
        public async Task<IActionResult> Save(Department department)
        {
            var result = await _departmentService.AddAsync(department);
            return Created("", _mapper.Map<DepartmentDto>(result));
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int Id)
        {
            var department = _departmentService.GetByIdAsync(Id).Result;
            _departmentService.Remove(department);

            return NoContent();
        }
        [HttpPut]
        public IActionResult Update(Department department)
        {
            _departmentService.Update(department);
            return NoContent();
        }

    }
}