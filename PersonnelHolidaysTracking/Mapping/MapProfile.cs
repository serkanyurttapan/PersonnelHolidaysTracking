using AutoMapper;
using PersonnelHolidaysTracking.Core.DTOs;
using PersonnelHolidaysTracking.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonnelHolidaysTracking.API.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Personnel, PersonnelDto>();
            CreateMap<PersonnelDto, Personnel>();
            CreateMap<PersonnelWithPersonnelHolidayDto, Personnel>();
            CreateMap<Personnel, PersonnelWithPersonnelHolidayDto>();
            CreateMap<PersonnelHolidayDto, PersonnelHoliday>();
            CreateMap<PersonnelHoliday, PersonnelHolidayDto>();
        }
    }
}
