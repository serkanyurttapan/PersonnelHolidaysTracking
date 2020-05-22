using PersonnelHolidaysTracking.Core.DTOs;
using PersonnelHolidaysTracking.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelHolidaysTracking.Core.Services
{
    public interface IDepartmentService : IServices<Department>
    {
        IList<DepartmentDto> GetDepartmentsDto();
        void RemoveWithStatus(Department entity);
    }
}
