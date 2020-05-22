using PersonnelHolidaysTracking.Core.DTOs;
using PersonnelHolidaysTracking.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelHolidaysTracking.Core.Repository
{ 
    public interface IDepartmentRepository :IRepository<Department>
    {
        List<DepartmentDto> GetDepartmentsDto();

        void RemoveWithStatus(Department entity);
    }
}
