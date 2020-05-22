using PersonnelHolidaysTracking.Core.DTOs;
using PersonnelHolidaysTracking.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelHolidaysTracking.Core.Repository
{
    public interface IPersonnelRepository :IRepository<Personnel>
    {
        Task<PersonnelDto> GetWithIPersonnelHolidayGetByAsync(int personelId);
        IEnumerable<PersonnelDto> GetWithIPersonnelHolidays();



    }

}
