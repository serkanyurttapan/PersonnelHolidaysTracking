using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PersonnelHolidaysTracking.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonnelHolidaysTracking.API.Filter
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ErorDto erorDto = new ErorDto();
                erorDto.Status = 400;
                IEnumerable<ModelError> modelErors = context.ModelState.Values.SelectMany(c => c.Errors);
                modelErors.ToList().ForEach(x =>
                erorDto.Errors.Add(x.ErrorMessage));
                context.Result = new BadRequestObjectResult(erorDto);
            }
        }
    }
}
