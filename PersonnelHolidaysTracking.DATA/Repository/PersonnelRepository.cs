using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using PersonnelHolidaysTracking.Core.DTOs;
using PersonnelHolidaysTracking.Core.Models;
using PersonnelHolidaysTracking.Core.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelHolidaysTracking.Data.Repository
{
    public class PersonnelRepository : Repository<Personnel>, IPersonnelRepository
    {
        private AsistPersonnelTrackingContext _asistPersonnelTrackingContext { get => _context as AsistPersonnelTrackingContext; }

        public PersonnelRepository(AsistPersonnelTrackingContext context) : base(context)
        {

        }

        public PersonnelDto GetWithIPersonnelHolidayGetByAsync(int personelId)
        {
            PersonnelWithPersonnelHolidayDto personnelSpecial = new PersonnelWithPersonnelHolidayDto();

            List<PersonnelHoliday> personnelHolidays = _asistPersonnelTrackingContext.PersonnelHolidays.Where(x => x.IsDeleted != true).Include(x => x.Personnel).ToList();
            IEnumerable<IGrouping<int, PersonnelHoliday>> personnelGrouping = personnelHolidays.GroupBy(x => x.PersonnelId);
            foreach (var personnelGroupItem in personnelGrouping)
            {
                Personnel personnel = new Personnel();

                int num = 0;
                foreach (var holiday in personnelGroupItem)
                {
                    personnel = holiday.Personnel;
                    TimeSpan timeSpan = holiday.HolidayEndDate - holiday.HolidayStartDate;
                    num += Math.Abs(timeSpan.Days);

                }
                int deserveDay = (DateTime.Now.Year - personnel.WorkStartDate.Year) < 6 ? 14 : 20;
                int reaminingDay = deserveDay - num;

                IEnumerable<PersonnelHolidayDto> personnelHolidayDtos = from p in personnel.PersonnelHolidays

                                                                        select new PersonnelHolidayDto()
                                                                        {
                                                                            PersonnelHolidayId = p.PersonnelId
                                                                        };

                personnelSpecial = new PersonnelWithPersonnelHolidayDto()
                {
                    PersonnelFirstName = personnel.PersonnelFirstName,
                    PersonnelLastName = personnel.PersonnelLastName,
                    PersonnelHolidays = personnelHolidayDtos.ToList(),
                    PersonnelId = personnel.PersonnelId,
                    ReaminingDay = reaminingDay,
                    Department = _asistPersonnelTrackingContext.Departments.Where(x => x.DepartmentId == personnel.DepartmentId).FirstOrDefault().DepartmentName

                };

            }

            return personnelSpecial;
        }

        public IEnumerable<PersonnelDto> GetWithIPersonnelHolidays()
        {
            var personnelWithPersonnelHolidays = new List<PersonnelWithPersonnelHolidayDto>();

            List<PersonnelHoliday> personnelHolidays = _asistPersonnelTrackingContext.PersonnelHolidays.Where(x => x.IsDeleted != true).Include(x => x.Personnel).ToList();
            IEnumerable<IGrouping<int, PersonnelHoliday>> personnelGrouping = personnelHolidays.GroupBy(x => x.PersonnelId);
            foreach (var personnelGroupItem in personnelGrouping)
            {
                Personnel personnel = new Personnel();

                int num = 0;
                foreach (var holiday in personnelGroupItem)
                {
                    personnel = holiday.Personnel;
                    TimeSpan timeSpan = holiday.HolidayEndDate - holiday.HolidayStartDate;
                    num += Math.Abs(timeSpan.Days);

                }
                int deserveDay = (DateTime.Now.Year - personnel.WorkStartDate.Year) < 6 ? 14 : 20;
                int reaminingDay = deserveDay - num;

                IEnumerable<PersonnelHolidayDto> personnelHolidayDtos = from p in personnel.PersonnelHolidays

                                                                        select new PersonnelHolidayDto()
                                                                        {
                                                                            PersonnelHolidayId = p.PersonnelId
                                                                        };

                PersonnelWithPersonnelHolidayDto personnelSpecial = new PersonnelWithPersonnelHolidayDto()
                {
                    PersonnelFirstName = personnel.PersonnelFirstName,
                    PersonnelLastName = personnel.PersonnelLastName,
                    PersonnelHolidays = personnelHolidayDtos.ToList(),
                    PersonnelId = personnel.PersonnelId,
                    ReaminingDay = reaminingDay,
                    Department = _asistPersonnelTrackingContext.Departments.Where(x => x.DepartmentId == personnel.DepartmentId).FirstOrDefault().DepartmentName

                };

                personnelWithPersonnelHolidays.Add(personnelSpecial);
            }

            return personnelWithPersonnelHolidays;
        }
        public void RemoveWithStatus(Personnel entity)
        {
            entity.IsDeleted = true;

        }
        public bool GetControl(PersonnelDto personnelDto, PersonnelHolidayDto personnelHoliday)
        {
            TimeSpan ts = (personnelHoliday.HolidayEndDate - personnelHoliday.HolidayStartDate);
            int totalDay = Math.Abs(ts.Days);


            if (personnelHoliday.HolidayStartDate <= personnelHoliday.HolidayEndDate)
            {
                if (personnelDto.ReaminingDay < totalDay)
                {
                    return false;
                }
                var appointmentNoShow = (from p in _asistPersonnelTrackingContext.Personnels

                                         join o in _asistPersonnelTrackingContext.Departments on p.PersonnelId equals o.DepartmentId

                                         join ph in _asistPersonnelTrackingContext.PersonnelHolidays on p.PersonnelId equals ph.PersonnelId

                                         select p.PersonnelId == personnelHoliday.PersonnelId
                                          && ph.HolidayStartDate >= personnelHoliday.HolidayStartDate
                                          && ph.HolidayEndDate >= personnelHoliday.HolidayEndDate);


                if (appointmentNoShow.Contains(true))
                {
                    return false;
                }
                else return true;
            }
            return false;
        }
    }
}
