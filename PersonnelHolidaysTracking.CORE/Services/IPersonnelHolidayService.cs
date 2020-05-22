using PersonnelHolidaysTracking.Core.DTOs;
using PersonnelHolidaysTracking.Core.Models;
using PersonnelHolidaysTracking.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnelHolidaysTracking.Core.Services
{
    public interface IPersonnelHolidayService : IServices<PersonnelHoliday> 
    {
        void RemoveWithStatus(PersonnelHoliday entity);
        IEnumerable<PersonnelHolidayDto> GetWithIPersonnelHolidays(int Id);

    }
}
