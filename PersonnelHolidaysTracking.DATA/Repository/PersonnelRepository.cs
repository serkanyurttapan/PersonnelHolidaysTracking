using Microsoft.EntityFrameworkCore;
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

            Personnel personnels = await _asistPersonnelTrackingContext.Personnels.Include(x => x.PersonnelHolidays).SingleOrDefaultAsync(x => x.PersonnelId == personelId);

            int sumHoliday = personnels.PersonnelHolidays.Sum(x => x.HolidayEndDate.Day - x.HolidayStartDate.Day);

            int deserveDay = (DateTime.Now.Year - personnels.WorkStartDate.Year) < 6 ? 14 : 20;

            int reaminingDay = deserveDay - sumHoliday;

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

    }
}
