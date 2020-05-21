using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnelHolidaysTracking.Core.Models
{
    public class PersonnelHoliday
    {
        public int PersonnelHolidayId { get; set; }
        public DateTime HolidayStartDate { get; set; }
        public DateTime HolidayEndDate { get; set; }
        public int PersonnelId { get; set; }
        public bool IsDeleted { get; set; }
        public string Description { get; set; }
        public Personnel Personnel { get; set; }

    }
}
