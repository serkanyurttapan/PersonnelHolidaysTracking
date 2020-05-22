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
    public class PersonnelService : Service<Personnel>,IPersonnelService
    {
        public PersonnelService(IUnitOfWork unitOfWork, IRepository<Personnel> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<PersonnelDto> GetWithIPersonnelHolidayGetByAsync(int personelId)
        {
            return await _unitOfWork.Personnels.GetWithIPersonnelHolidayGetByAsync(personelId);

        }
        public IEnumerable<PersonnelDto> GetWithIPersonnelHolidays()
        {
            return _unitOfWork.Personnels.GetWithIPersonnelHolidays();
        }

    }
}
