using PersonnelHolidaysTracking.Core.DTOs;
using PersonnelHolidaysTracking.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnelHolidaysTracking.Core.Repository
{
    public interface IPersonnelHolidayRepository :IRepository<PersonnelHoliday>
    {
        void RemoveWithStatus(PersonnelHoliday entity);
        IEnumerable<PersonnelHolidayDto> GetWithIPersonnelHolidays(int Id);

    }
}
