using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonnelHolidaysTracking.Core.DTOs;
using PersonnelHolidaysTracking.Core.Models;
using PersonnelHolidaysTracking.Core.Repository;
using PersonnelHolidaysTracking.Core.Services;

namespace PersonelHolidayTracking.Web.Controllers
{


    public class PersonnelHolidayController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPersonnelService _personnelService;
        private readonly IPersonnelHolidayService _personnelHolidayService;

        public PersonnelHolidayController(IMapper mapper, IPersonnelHolidayService personnelHolidayService, IPersonnelService personnelService)
        {
            _personnelHolidayService = personnelHolidayService;
            _personnelService = personnelService;
            _mapper = mapper;

        }

        public IActionResult Index(int Id)
        {
            var res = _personnelHolidayService.GetWithIPersonnelHolidays(Id);
            TempData["Id"] = Id;
            return View(res);
        }
        [HttpPost]
        public async Task<IActionResult> Create(PersonnelHolidayDto personnelHoliday)
        {
            personnelHoliday.PersonnelId = Convert.ToInt32(TempData["Id"]);
            PersonnelDto personnelDto = _personnelService.GetWithIPersonnelHolidayGetByAsync(personnelHoliday.PersonnelId);
           
            if (_personnelService.GetControl(personnelDto, personnelHoliday)) //aynı departmandan girilen tarihler arasında personel iznini sorgular
            {
                await _personnelHolidayService.AddAsync(_mapper.Map<PersonnelHoliday>(personnelHoliday));
            }
            return RedirectToAction("Index", "Personnel");
        }
        public IActionResult Create()
        {
            return View();
        }

    }
}