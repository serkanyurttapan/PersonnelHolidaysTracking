using PersonnelHolidaysTracking.Core.Repository;
using PersonnelHolidaysTracking.Core.UnitOfWorks;
using PersonnelHolidaysTracking.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelHolidaysTracking.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AsistPersonnelTrackingContext _asistPersonnelTrackingContext;
        private DepartmentRepository _departmentRepository;
        private PersonnelRepository _personnelRepository;
        private PersonnelHolidayRepository _personnelHolidayRepository;
        public IPersonnelRepository Personnels => _personnelRepository = _personnelRepository ?? new PersonnelRepository(_asistPersonnelTrackingContext);

        public IPersonnelHolidayRepository PersonnelHolidays => _personnelHolidayRepository = _personnelHolidayRepository ?? new PersonnelHolidayRepository(_asistPersonnelTrackingContext);

        public IDepartmentRepository Departments => _departmentRepository = _departmentRepository ?? new DepartmentRepository(_asistPersonnelTrackingContext);

        public UnitOfWork(AsistPersonnelTrackingContext appDbContext)
        {
            _asistPersonnelTrackingContext = appDbContext;
        }

        public void Commit()
        {
            _asistPersonnelTrackingContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _asistPersonnelTrackingContext.SaveChangesAsync();
        }
    }
}
