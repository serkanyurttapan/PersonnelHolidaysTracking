using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnelHolidaysTracking.Core.DTOs
{
    public class ErorDto
    {
        public ErorDto()
        {
            Errors = new List<string>();
        }
        public List<string> Errors { get; set; }
        public int Status { get; set; }
    }
}
