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

namespace PersonelHolidayTracking.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
         private readonly IMapper _mapper;

        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var result = _departmentService.GetDepartmentsDto();
            return View(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            await _departmentService.AddAsync(department);

            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Update(int Id)
        {
            var personnel = await _departmentService.GetByIdAsync(Id);

            return View(personnel);
        }
        [HttpPost]
        public IActionResult Update(Department department)
        {
            _departmentService.Update(department);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var department = _departmentService.GetByIdAsync(Id).Result;
            _departmentService.RemoveWithStatus(department);
            return RedirectToAction("Index");
        }
    }
}  