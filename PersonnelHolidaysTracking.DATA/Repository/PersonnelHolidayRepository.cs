using Microsoft.EntityFrameworkCore;
using PersonnelHolidaysTracking.Core.DTOs;
using PersonnelHolidaysTracking.Core.Models;
using PersonnelHolidaysTracking.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelHolidaysTracking.Data.Repository
{
    public class PersonnelHolidayRepository : Repository<PersonnelHoliday>, IPersonnelHolidayRepository
    {

        private AsistPersonnelTrackingContext _asistPersonnelTrackingContext { get => _context as AsistPersonnelTrackingContext; }

        public PersonnelHolidayRepository(AsistPersonnelTrackingContext context) : base(context)
        {

        }
     
    }
}
