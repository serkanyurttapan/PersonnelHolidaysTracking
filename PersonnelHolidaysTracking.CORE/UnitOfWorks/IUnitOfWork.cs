using PersonnelHolidaysTracking.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelHolidaysTracking.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IPersonnelRepository Personnels { get; }
        IPersonnelHolidayRepository PersonnelHolidays{ get; }
        IDepartmentRepository Departments { get; }
        Task CommitAsync();
        void Commit();
    }
}
