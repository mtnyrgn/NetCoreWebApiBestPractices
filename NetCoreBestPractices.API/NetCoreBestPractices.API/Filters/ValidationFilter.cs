using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetCoreBestPractices.API.DTO.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreBestPractices.API.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                //Modelde herhangi bir hata varsa buraya girecek
                ErrorDto error = new ErrorDto();

                error.Status = 400; //client hatası olduğu için 400 kodu dönmeliyim.
                IEnumerable<ModelError> modelErrors = context.ModelState.Values.SelectMany(s => s.Errors);

                modelErrors.ToList().ForEach(err =>
                {
                    error.Errors.Add(err.ErrorMessage); //Birden fazla hata varsa listeye ekliyorum
                });

                context.Result = new BadRequestObjectResult(error);
            }
        }
    }
}
