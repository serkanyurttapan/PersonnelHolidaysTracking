using Microsoft.EntityFrameworkCore;
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

        public async Task<PersonnelDto> GetWithIPersonnelHolidayGetByAsync(int personelId)
        {

            Personnel personnels = await _asistPersonnelTrackingContext.Personnels.Where(x => x.IsDeleted != true).Include(x => x.PersonnelHolidays).SingleOrDefaultAsync(x => x.PersonnelId == personelId);

            var days = (from p in personnels.PersonnelHolidays

                        select new
                        {
                            p.HolidayEndDate,
                            p.HolidayStartDate
                        }
                          );
            int totalDay = 0;
            foreach (var item in days)
            {
                TimeSpan ts = (item.HolidayEndDate - item.HolidayStartDate);
                totalDay += Math.Abs(ts.Days) + 2;

            }
            int deserveDay = (DateTime.Now.Year - personnels.WorkStartDate.Year) < 6 ? 14 : 20;

            int reaminingDay = deserveDay - totalDay;

            IEnumerable<PersonnelHolidayDto> personnelHolidayDtos = from p in personnels.PersonnelHolidays

                                                                    select new PersonnelHolidayDto()
                                                                    {
                                                                        PersonnelHolidayId = p.PersonnelId
                                                                    };

            PersonnelWithPersonnelHolidayDto personnelSpecial = new PersonnelWithPersonnelHolidayDto()
            {
                PersonnelFirstName = personnels.PersonnelFirstName,
                PersonnelHolidays = personnelHolidayDtos.ToList(),
                PersonnelId = personnels.PersonnelId,
                ReaminingDay = reaminingDay
            };
            return personnelSpecial;
        }

        public IEnumerable<PersonnelDto> GetWithIPersonnelHolidays()
        {
            var personnelWithPersonnelHolidays = new List<PersonnelWithPersonnelHolidayDto>();
            IList<Personnel> personnels = _asistPersonnelTrackingContext.Personnels.Where(x=>x.IsDeleted!=true).Include(x => x.PersonnelHolidays).ToList();

            foreach (var personnel in personnels)
            {
                var days = (from p in personnel.PersonnelHolidays

                            select new
                            {
                                p.HolidayEndDate,
                                p.HolidayStartDate
                            }
                           );
                int totalDay = 0;
                foreach (var item in days)
                {
                    TimeSpan ts = (item.HolidayEndDate - item.HolidayStartDate);
                    totalDay += Math.Abs(ts.Days) + 2;

                }
                int deserveDay = (DateTime.Now.Year - personnel.WorkStartDate.Year) < 6 ? 14 : 20;

                int reaminingDay = deserveDay - totalDay;

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
                    Department =_asistPersonnelTrackingContext.Departments.Where(x=>x.DepartmentId==personnel.DepartmentId).FirstOrDefault().DepartmentName
                
                };
               
                personnelWithPersonnelHolidays.Add(personnelSpecial);
            }

            return personnelWithPersonnelHolidays;

        }

        public void RemoveWithStatus(Personnel entity)
        {
            entity.IsDeleted = true;
             
        }
    }
}
