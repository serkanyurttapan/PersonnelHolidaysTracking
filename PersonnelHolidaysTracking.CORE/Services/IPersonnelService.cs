﻿using PersonnelHolidaysTracking.Core.DTOs;
using PersonnelHolidaysTracking.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelHolidaysTracking.Core.Services
{
    public interface IPersonnelService : IServices<Personnel>
    {
        PersonnelDto GetWithIPersonnelHolidayGetByAsync(int personelId);
        IEnumerable<PersonnelDto> GetWithIPersonnelHolidays();
        void RemoveWithStatus(Personnel entity);
        bool GetControl(PersonnelDto personnelDto, PersonnelHolidayDto personnelHoliday);

    }
}
