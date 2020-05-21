using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnelHolidaysTracking.Core.DTOs
{
    public class PersonnelWithPersonnelHolidayDto :PersonnelDto
    {
        public ICollection<PersonnelHolidayDto> PersonnelHolidays { get; set; }

    }
}
