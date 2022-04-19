using Data.EmployeeData.Entities;
using EmployeeManagement.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;

namespace EmployeeManagement.Filter
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly IModelMetadataProvider _modelMetadataProvider;
        private readonly ILogService _logService;

        public CustomExceptionFilter(IModelMetadataProvider modelMetadataProvider, ILogService logService)
        {
            _modelMetadataProvider = modelMetadataProvider;
            _logService = logService;
        }

        public void OnException(ExceptionContext context)
        {
            var result = new ViewResult { ViewName = "Error" };
            result.ViewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState);
            result.ViewData.Add("Exception", context.Exception);

            ExceptionLogger logger = new ExceptionLogger()
            {
                ExceptionMessage = context.Exception.Message,
                ExceptionStackTrace = context.Exception.StackTrace,
                ControllerName = context.RouteData.Values["controller"].ToString(),
                LogTime = DateTime.Now
            };

            _logService.SaveLog(logger);
            context.ExceptionHandled = true;
            context.Result = result;
        }
    }
}
