using AutoMapper;
using PersonnelHolidaysTracking.Core.DTOs;
using PersonnelHolidaysTracking.Core.Models;

namespace PersonnelHolidaysTracking.Web.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Personnel, PersonnelDto>();
            CreateMap<PersonnelDto, Personnel>();
            CreateMap<PersonnelWithPersonnelHolidayDto, Personnel>();
            CreateMap<Personnel, PersonnelWithPersonnelHolidayDto>();
            CreateMap<PersonnelHolidayDto, PersonnelHoliday>();
            CreateMap<PersonnelHoliday, PersonnelHolidayDto>();
            CreateMap<DepartmentDto, Department>();
            CreateMap<Department, DepartmentDto>();
        }
    }
}
