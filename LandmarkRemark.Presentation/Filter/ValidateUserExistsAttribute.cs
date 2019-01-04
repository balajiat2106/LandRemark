using LandmarkRemark.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandmarkRemark.Presentation.Filter
{
    public class ValidateUserExistsAttribute : TypeFilterAttribute
    {
        public ValidateUserExistsAttribute() : base(typeof(ValidateUserExistsFilterImplementation))
        {

        }
        private class ValidateUserExistsFilterImplementation : IAsyncActionFilter
        {
            private readonly LandmarkRemarkContext _landmarkRemarkContext;

            public ValidateUserExistsFilterImplementation(LandmarkRemarkContext landmarkRemarkContext)
            {
                _landmarkRemarkContext = landmarkRemarkContext;
            }

            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                if (context.ActionArguments.ContainsKey("userId"))
                {
                    int? id = Convert.ToInt32(context.ActionArguments["userId"]);
                    if (id != null)
                    {
                        if (await _landmarkRemarkContext.Users.AllAsync(u => u.Id != id))
                        {
                            context.Result = new NotFoundObjectResult(id);

                            return;
                        }
                    }
                }
                await next();
            }
        }
    }
}
