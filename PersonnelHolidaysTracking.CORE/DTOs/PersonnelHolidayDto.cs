using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnelHolidaysTracking.Core.DTOs
{
    public class PersonnelHolidayDto
    {
        public int PersonnelHolidayId { get; set; }
        public string Description { get; set; }
        public DateTime HolidayStartDate { get; set; }
        public DateTime HolidayEndDate { get; set; }
    }
}
