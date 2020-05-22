using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PersonnelHolidaysTracking.Core.Models
{
    public class Personnel
    {
        public Personnel()
        {
            PersonnelHolidays = new Collection<PersonnelHoliday>();
        }
        public int PersonnelId { get; set; }
        public string PersonnelFirstName { get; set; }
        public string PersonnelLastName { get; set; }
        public DateTime WorkStartDate { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<PersonnelHoliday> PersonnelHolidays { get; set; }
    }
}
