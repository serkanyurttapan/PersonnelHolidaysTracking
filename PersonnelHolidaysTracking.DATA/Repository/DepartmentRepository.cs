using Microsoft.EntityFrameworkCore;
using PersonnelHolidaysTracking.Core.DTOs;
using PersonnelHolidaysTracking.Core.Models;
using PersonnelHolidaysTracking.Core.Repository;
using PersonnelHolidaysTracking.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelHolidaysTracking.Data.Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private AsistPersonnelTrackingContext _asistPersonnelTrackingContext { get => _context as AsistPersonnelTrackingContext; }

        public DepartmentRepository(AsistPersonnelTrackingContext context) : base(context)
        {
        }

        public List<DepartmentDto> GetDepartmentsDto()
        {
            var result = _asistPersonnelTrackingContext.Departments.Where(x=>x.IsDeleted!=true).ToList();
            List<DepartmentDto> departmentDtos;
            return departmentDtos = result.Select(x => new DepartmentDto
            {
                DepartmentId = x.DepartmentId,
                DepartmentName = x.DepartmentName
            }).ToList();

        }

        public void RemoveWithStatus(Department entity)
        {
            entity.IsDeleted = true;
        }
    }
}
