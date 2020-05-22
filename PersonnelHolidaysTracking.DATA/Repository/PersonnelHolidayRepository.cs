using Microsoft.EntityFrameworkCore;
using PersonnelHolidaysTracking.Core.DTOs;
using PersonnelHolidaysTracking.Core.Models;
using PersonnelHolidaysTracking.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelHolidaysTracking.Data.Repository
{
    public class PersonnelHolidayRepository : Repository<PersonnelHoliday>, IPersonnelHolidayRepository
    {

        private AsistPersonnelTrackingContext _asistPersonnelTrackingContext { get => _context as AsistPersonnelTrackingContext; }

        public PersonnelHolidayRepository(AsistPersonnelTrackingContext context) : base(context)
        {

        }

        public void RemoveWithStatus(PersonnelHoliday entity)
        {
            entity.IsDeleted = true;
          
        }

        public IEnumerable<PersonnelHolidayDto> GetWithIPersonnelHolidays(int Id)
        {
            return _asistPersonnelTrackingContext.PersonnelHolidays.Where(x => x.PersonnelId == Id).Select(x => new PersonnelHolidayDto
            {
                PersonnelHolidayId=x.PersonnelHolidayId,
                Description = x.Description,
                HolidayEndDate = x.HolidayEndDate,
                HolidayStartDate = x.HolidayStartDate,
                 PersonnelId=x.PersonnelId
            }).ToList();
        }
    }
}
