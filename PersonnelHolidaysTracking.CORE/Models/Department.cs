using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Text;

namespace PersonnelHolidaysTracking.Core.Models
{
   public class Department
    {
        public Department()
        {
            Personnels = new Collection<Personnel>();
        }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Personnel> Personnels { get; set; }
    }
}
