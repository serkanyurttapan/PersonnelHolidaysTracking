using PersonnelHolidaysTracking.Core.Models;
using PersonnelHolidaysTracking.Core.Repository;
using PersonnelHolidaysTracking.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnelHolidaysTracking.Data.Repository
{
    public class DepartmentRepository :Repository<Department>,IDepartmentRepository
    {
        public DepartmentRepository(AsistPersonnelTrackingContext context) : base(context)
        {
        }

    }
}
