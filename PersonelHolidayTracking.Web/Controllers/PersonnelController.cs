using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonnelHolidaysTracking.Core.DTOs;
using PersonnelHolidaysTracking.Core.Models;
using PersonnelHolidaysTracking.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonelHolidayTracking.Web.Controllers
{
    public class PersonnelController : Controller
    {
        private readonly IPersonnelService _personnelService;
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public PersonnelController(IPersonnelService personnelService, IMapper mapper, IDepartmentService departmentService)
        {
            _personnelService = personnelService;
            _departmentService = departmentService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var res = _personnelService.GetWithIPersonnelHolidays();
            return View(res);
        }
        public IActionResult Create()
        {

            ViewBag.SysList = _departmentService.GetDepartmentsDto();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Personnel personnel)
        {
            await _personnelService.AddAsync(personnel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int Id)
        {
            var personnel = await _personnelService.GetByIdAsync(Id);

            return View(personnel);
        }
        [HttpPost]
        public IActionResult Update(Personnel personnel)
        {
            _personnelService.Update(personnel);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var personnel = _personnelService.GetByIdAsync(Id).Result;
            _personnelService.RemoveWithStatus(personnel);
            return RedirectToAction("Index");
        }
    }
}