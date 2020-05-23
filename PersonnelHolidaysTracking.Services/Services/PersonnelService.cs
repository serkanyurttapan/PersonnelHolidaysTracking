using PersonnelHolidaysTracking.Core.DTOs;
using PersonnelHolidaysTracking.Core.Models;
using PersonnelHolidaysTracking.Core.Repository;
using PersonnelHolidaysTracking.Core.Services;
using PersonnelHolidaysTracking.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelHolidaysTracking.Service.Services
{
    public class PersonnelService : Service<Personnel>, IPersonnelService
    {
        public PersonnelService(IUnitOfWork unitOfWork, IRepository<Personnel> repository) : base(unitOfWork, repository)
        {
        }

        public bool GetControl(PersonnelDto personnelDto, PersonnelHolidayDto personnelHoliday)
        {
            return _unitOfWork.Personnels.GetControl(personnelDto,personnelHoliday);
        }

        public PersonnelDto GetWithIPersonnelHolidayGetByAsync(int personelId)
        {
            return _unitOfWork.Personnels.GetWithIPersonnelHolidayGetByAsync(personelId);

        }
        public IEnumerable<PersonnelDto> GetWithIPersonnelHolidays()
        {
            return _unitOfWork.Personnels.GetWithIPersonnelHolidays();
        }

        public void RemoveWithStatus(Personnel entity)
        {
            _unitOfWork.Personnels.RemoveWithStatus(entity);
            _unitOfWork.Commit();
        }

    }
}
