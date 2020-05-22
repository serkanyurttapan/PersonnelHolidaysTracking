using PersonnelHolidaysTracking.Core.DTOs;
using PersonnelHolidaysTracking.Core.Models;
using PersonnelHolidaysTracking.Core.Repository;
using PersonnelHolidaysTracking.Core.Services;
using PersonnelHolidaysTracking.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnelHolidaysTracking.Service.Services
{
    public class PersonnelHolidayService :Service<PersonnelHoliday>,IPersonnelHolidayService
    {
        public PersonnelHolidayService(IUnitOfWork unitOfWork,IRepository<PersonnelHoliday> repository) :base(unitOfWork,repository)
        {
        }

        public IEnumerable<PersonnelHolidayDto> GetWithIPersonnelHolidays(int Id)
        {
           return _unitOfWork.PersonnelHolidays.GetWithIPersonnelHolidays(Id);
        }

        public void RemoveWithStatus(PersonnelHoliday entity)
        {
            _unitOfWork.PersonnelHolidays.RemoveWithStatus(entity);
            _unitOfWork.Commit();
        }
    }
}
